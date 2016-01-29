using UnityEngine;
using System.Collections;

public class Sheep_Ai : MonoBehaviour {
	
	// The maximum time between turns.
	public float turnMaxTime = 3;

	// The minimum time between turns.
	public float turnMinTime = 2;
	
	// Time untill the next rotate. Deincreaments every frame.
	private float timeUntillRotate;
	
	// The speed of the AI.
	[SerializeField] private float speed = 1; 
	
	// The area that the AI is not allowed to leave.
	[SerializeField] private GameObject arena;
	
	// Unneeded referance to rigid body.
	private Rigidbody rg;
	
	// If we need to go to center.
	private bool reroute = false;
	
	void Start () {
	
		// Grav the referance.
		rg = gameObject.GetComponent<Rigidbody>();
	}
	
	void OnTriggerExit (Collider coll)
	{
		// In case we are colliding with the border then go home.
		if (coll.gameObject == arena)
		{

			// Look at the center so that we don't fall off.
			gameObject.transform.LookAt(arena.transform);
			
			// We can't do normal movements anymore.
			reroute = true;
		}
	}
	
	void OnTriggerEnter (Collider coll)
	{
		// check if we are inside the arena again.
		if (coll.gameObject == arena)
		{
			
			// We can now continue with standard movements.
			reroute = false;
			
			// To make sure that AI doesn't get stuck while trying to escape a border.
			timeUntillRotate = turnMaxTime;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Check if rotate or go forward.
		if (timeUntillRotate <=0)
		{
			
			
			// If we are not going outisde. Then rotate.
			if (reroute != true)
			{
				// Calculate a new rotation.
				int rota = Random.Range(0, 360);
				
				// Append the new rotation.
				gameObject.transform.Rotate(0, rota, 0);
			}
			
			// Calculate the next time we rotate.
			timeUntillRotate = Random.Range (turnMinTime, turnMaxTime);
		}
		else
		{  
			// Continue going forward.
			gameObject.transform.position+=transform.forward * Time.deltaTime * speed;
			
			// Decrease timer untill rotation.
			timeUntillRotate-= Time.deltaTime;
		}
	}
}
