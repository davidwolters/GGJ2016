using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 10;
	private float currentMoveSpeed = 10;
	private float currentTurnSpeed = 10;
	[SerializeField] private float turnSpeed = 180;
	[SerializeField] private Camera cam;
	[SerializeField] private PlayerType player;
	private float oldSpeed;
	private float oldRotateSpeed;
	void Start ()
	{
		currentTurnSpeed = turnSpeed;
		currentMoveSpeed = moveSpeed;
	}
	
	void Update () 
	{
		
		UpdatePosition ();
		
		//UpdateRotation (); 

	}

	public void Freeze(float seconds)
	{
		
		// S
		oldSpeed = moveSpeed;
		currentMoveSpeed = oldSpeed / 10;
		
		// R
		oldRotateSpeed = turnSpeed;
		currentTurnSpeed = oldRotateSpeed / 10;
		
		
		Invoke ("UnFreeze", seconds);
	}

	void UnFreeze ()
	{
		currentMoveSpeed = oldSpeed;
		currentTurnSpeed = oldRotateSpeed;
	}
	void UpdatePosition ()
	{
		float localMoveSpeed = currentMoveSpeed; // this is used because if the player is shooting, we slow down the speed
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
		Vector3 moveVector3 = rawMoveHor * currentMoveSpeed * Time.deltaTime * transform.forward;
		transform.position += moveVector3;

		transform.Rotate (0, -rawMoveVer * currentTurnSpeed * Time.deltaTime, 0);
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
