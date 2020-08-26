using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	Animator a;
	CharacterController co;
	AudioSource au;

	//Sound played when firing
	public AudioClip au_shot;

	//Maximum size of the magazine
	public int magSize = 7;
	//Bullets currently in the magazine
	public int mag;

	//Define what type of reload the weapon uses
	public enum ReloadType {
		Magazine,
		Single
	}
	//Magazine: all bullets are loaded at once
	//Single: bullets are loaded one at a time. Reloads take longer but can be interrupted
	public ReloadType loadType;

	//Rate of fire
	public float rof = 0.1f;
	//Used to keep track of when we can shoot
	float shotTimer;

	//Is the weapon automatic or semi-auto
	//True: Weapon will fire as long as the trigger is held down
	//False: Weapon will fire once only when the trigger is pressed
	public bool automatic = false;

	//Used to tell the animation controller which states to switch to
	bool aiming;
	bool jumping;
	bool reloading;

	//Current speed. Used to tell the animation controller which movement animation to play
	float curSpeed;

	//How fast the speed value will change
	public float acceleration = 4;

	//Casing object to be instantiated
	public GameObject casing;
	//Where the casing should be spawned
	public Transform casingSpawn;
	//The relative force to be applied to the casing's rigidbody
	public Vector3 casingForce;

	//Particles for muzzle flash
	ParticleSystem[] ps;

	// Use this for initialization
	void Start () {
		a = gameObject.GetComponentInChildren<Animator> ();
		au = gameObject.GetComponent<AudioSource> ();

		mag = magSize;

		ps = gameObject.GetComponentsInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		//If the shot timer is greater than zero, reduce it by 1 per second
		if (shotTimer > 0)
			shotTimer -= Time.deltaTime;

		//Get the character controller if there is none
		if (co == null)
			co = gameObject.GetComponentInParent<CharacterController> ();

		//Calculate the movement speed
		//The target speed is 0 by default
		int targetSpeed = 0;
		//Change it to 1 if there is input
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
			targetSpeed = 1;
			//And to 2 if we are sprinting
			if (Input.GetKey(KeyCode.LeftShift)) {
				targetSpeed = 2;
			}
		}

		//If we are not sprinting
		if (targetSpeed != 2) {
			//Check if we should be aiming
			aiming = Input.GetKey (KeyCode.Mouse1);

			//Shooting logic
			if (mag > 0) {
				if (automatic) {
					//If the trigger is held and we can shoot
					if (Input.GetKey (KeyCode.Mouse0) && shotTimer <= 0) {
						//Play the shoot animation
						Shoot ();

						//Set the time in which we can't shoot again
						shotTimer = rof;
					}
				} else {
					//If the trigger is pulled and we can shoot
					if (Input.GetKeyDown (KeyCode.Mouse0) && shotTimer <= 0) {
						//Play the shoot animation
						Shoot ();

						//Set the time in which we can't shoot again
						shotTimer = rof;
					}
				}
			}
		} else {
			//If we are sprinting, we are not allowed to aim
			aiming = false;
		}

		//Check if we are jumping
		jumping = Input.GetKey (KeyCode.Space);

		//Reload logic
		if (loadType == ReloadType.Magazine) {
			//Check if we should be reloading
			reloading = Input.GetKey (KeyCode.R);
		} else {
			//Start reloading when the R key is pressed
			if (Input.GetKey (KeyCode.R)) {
				reloading = true;
			}
			//We want to keep reloading if the key is released, however

			//If there magazine is full, or there are any interruptions, stop reloading
			if (mag == magSize || Input.GetKey (KeyCode.Mouse0) || Input.GetKey (KeyCode.Mouse1)) {
				reloading = false;
			}

			//The current ammo is increased by animation events
		}

		//Lerp the movement animation speed to the target speed
		curSpeed = Mathf.Lerp(curSpeed, targetSpeed, Time.deltaTime * acceleration);

		//Set the animation parameters
		a.SetBool ("aiming", aiming);
		a.SetFloat("curSpeed",curSpeed);
		a.SetBool ("jumping", jumping);
		a.SetBool ("reloading", reloading);

		//If there a character controller, check if we are grounded
		if (co != null)
			a.SetBool ("grounded", co.isGrounded);
		else
			a.SetBool ("grounded", true);
	}

	void Shoot () {
		//Play the correct shooting animation
		if (aiming)
			a.CrossFade ("AimShoot", 0.02f, 0, 0);
		else
			a.CrossFade ("Shoot", 0.02f, 0, 0);

		//Reduce ammo
		if (mag > 0)
			mag--;

		//Play the shot sound if there is one
		if (au_shot != null && au != null)
			au.PlayOneShot (au_shot);

		//Emit particles for muzzle flash
		for (int i = 0;i < ps.Length;i++) {
			ps[i].Emit (10);
		}
	}

	public void LoadMag () {
		//Refil the magazine
		mag = magSize;

		//Update the empty magazine animation
		NoAmmo (false);
	}

	public void LoadSingle () {
		//Add ammo
		mag++;
	}

	public void Eject () {
		//If there is no ammo left, activate the appropriate animation
		if (mag == 0) {
			NoAmmo (true);
		}

		//If there is a casing and a casing spawn point
		if (casing != null && casingSpawn != null) {
			//Instantiate the casing at the spawn point's position
			GameObject c = (GameObject)Instantiate (casing, casingSpawn.position, casingSpawn.rotation);
			//Apply force to the casing's rigidbody
			c.GetComponent<Rigidbody> ().AddForce (casingSpawn.transform.TransformDirection(casingForce*Random.Range(0.9f,1.1f)));
			//Mag the casing a child of the player
			//This will prevent the casing from going through the weapon when the player is shooting and moving at the same time
			//The casing has a script that will automatically unparent it from the player after a short time
			c.transform.SetParent (transform);
		}
	}


	public void NoAmmo (bool s) {
		//In some weapons, there is an animation to show that the magazine is empty
		//This animation is being played constantly on the second layer of the animation controller
		//This layer will override the base layer

		//This function's purpose is to switch the layer on and off by changing the weight
		if (s)
			a.SetLayerWeight (1, 1);
		else
			a.SetLayerWeight (1, 0);
	}
}
