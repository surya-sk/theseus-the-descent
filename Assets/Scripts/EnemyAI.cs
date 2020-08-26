///<summary>
///The script that controls most of the enemy behavior, from when to start chasing to when to start attacking the player
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, ISaveable
{

    [SerializeField]Transform target;
    [SerializeField] float chaseRadius = 10f;
    [SerializeField] float turnSpeed = 5f;
   // [SerializeField] AudioSource walkSound;
    [SerializeField] AudioSource runSound;
    [SerializeField] AudioSource attackSFX;
    [SerializeField] AudioSource breathSFX;
    [SerializeField] AudioSource growlSFX;
    NavMeshAgent navMeshAgent;
    float distanceToTarget;
    bool hasDetected = false;
    EnemyHealth enemyHealth;
    float timeSinceLastSawPlayer;
    Vector3 initialPosition;
    Animator animator;
    bool hasBeenHit = false;
    //[SerializeField] Waypoint waypoint;
    //int currWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        enemyHealth = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialPosition = gameObject.transform.position;
        animator = GetComponent<Animator>();
        //navMeshAgent.stoppingDistance = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.EnemyIsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        DecideAction();
    }

    /// <summary>
    /// Decide what to do with player at each frame
    /// </summary>
    private void DecideAction()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        //print(timeSinceLastSawPlayer);
        if (hasDetected)
        {
            Engage();
        }
        if (distanceToTarget <= chaseRadius || hasBeenHit)
        {
            hasDetected = true;
            if(timeSinceLastSawPlayer > 0.13)
                hasBeenHit = false;
        }
        else if (distanceToTarget > chaseRadius && !hasBeenHit && timeSinceLastSawPlayer > 0.13)
        {
            hasDetected = false;
            navMeshAgent.SetDestination(initialPosition);
            if (Vector3.Distance(gameObject.transform.position, initialPosition) < 3 && !enemyHealth.EnemyIsDead())
            {
                animator.SetTrigger("Idle");
            }
            
        }
    }

    /// <summary>
    /// Faces towards the target when provoked 
    /// </summary>
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        breathSFX.Play();
    }

    /// <summary>
    /// starts chasing the target 
    /// Triggers the appropritate animations 
    /// </summary>
    private void StartChase()
    {
        if (growlSFX.isPlaying == false)
        {
            growlSFX.Play();
        }
        Move(target.position);
    }

    private void Move(Vector3 position)
    {
        animator.SetBool("Attack", false);
        animator.SetTrigger("Move");
        if (!enemyHealth.EnemyIsDead())
        {
            navMeshAgent.SetDestination(position);
        }
        if (runSound.isPlaying == false)
        {
            runSound.Play();
        }
    }

    /// <summary>
    /// starts to attck the target by triggering the attack bool
    /// </summary>
    private void StartAttack()
    {
        animator.SetBool("Attack", true);
        if(attackSFX.isPlaying == false && FindObjectOfType<PlayerHealth>().PlayerIsDead() == false)
        {
            attackSFX.Play();
        }
    }

    /// <summary>
    /// When the target is in range, engage
    /// </summary>
    private void Engage()
    {
        timeSinceLastSawPlayer = 0;
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            StartChase();
        }
        else if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
            StartAttack();
        }
        timeSinceLastSawPlayer += Time.deltaTime;
    
    }

    public void OnBeingHit()
    {
        hasBeenHit = true;
    }

   /* Turned out to be impractical. Might revisit
    * private void LoopWaypoints()
    {
        Vector3 nextPosition = gameObject.transform.position;
        if(waypoint!= null)
        {
            if(Vector3.Distance(gameObject.transform.position, waypoint.GetPosition(currWaypoint)) < 1f)
            {
                currWaypoint = waypoint.GetNextIndex(currWaypoint);
            }
        }
        Move(nextPosition);
    } */

    /// <summary>
    /// Purely for visual feedback during development. No impact on actual game
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, chaseRadius);
    }

    public object CaptureState()
    {
        return new SerializableVector3(transform.position);
    }

    public void RestoreState(object state)
    {
        SerializableVector3 position = (SerializableVector3)state;
        GetComponent<NavMeshAgent>().enabled = false;
        transform.position = position.ConvertToVector();
        GetComponent<NavMeshAgent>().enabled = true;
    }
}
