using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float turnSpeed;
	[SerializeField] private Camera cam;
	[SerializeField] private PlayerType player;


	void Start ()
	{
		
	}
	
	void Update () 
	{
		
		UpdatePosition ();
		
		//UpdateRotation (); 

	}

	void UpdatePosition ()
	{
		float localMoveSpeed = moveSpeed; // this is used because if the player is shooting, we slow down the speed
		localMoveSpeed /= (Util.Shooting (player)) ? 2f : 1;

		float rawMoveHor = 0;
		float rawMoveVer = 0;

		if (Input.GetKey (Player_Controls.forward (player)))
		{
			rawMoveHor = 1;
		} 
		if (Input.GetKey (Player_Controls.backward (player)))
		{
			rawMoveHor = -1;
		} 
		if (Input.GetKey (Player_Controls.left (player)))
		{
			rawMoveVer = 1;
		} 
		if (Input.GetKey (Player_Controls.right (player)))
		{
			rawMoveVer = -1;
		} 
		Vector3 moveVector3 = rawMoveHor * moveSpeed * Time.deltaTime * transform.forward;
		transform.position += moveVector3;

		transform.Rotate (0, -rawMoveVer * turnSpeed * Time.deltaTime, 0);
	}

	void UpdateRotation ()
	{
		
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit))
		{
			Vector3 lookPoint = hit.point;
			lookPoint.y = transform.position.y;
			transform.LookAt (lookPoint);
		}
		

	}

}
