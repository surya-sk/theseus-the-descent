using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSFX : MonoBehaviour
{
    [SerializeField] AudioSource walkSound;
    [SerializeField] AudioSource runSound;
    [SerializeField] AudioSource exhaleFX;
    //[SerializeField] AudioClip exhaleClip;
    Rigidbody body;
    float timePastSinceRun;
    // Start is called before the first frame update
    void Start()
    {
        timePastSinceRun = 0;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (body.velocity.magnitude > 2 && body.velocity.magnitude < 10 && walkSound.isPlaying == false) 
        {
            walkSound.Play();
            if(timePastSinceRun > 22)
            {
                timePastSinceRun--;
                exhaleFX.Play();
            }
            else if(timePastSinceRun < 5)
            {
                exhaleFX.Stop();
            }
           
        }
        if (body.velocity.magnitude > 10 && runSound.isPlaying == false)
        {
            timePastSinceRun++;
            runSound.Play();
        }
        
    }

 
}
