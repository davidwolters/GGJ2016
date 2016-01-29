using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private Camera cam;

	void Start ()
	{
		
	}
	
	void Update () 
	{
		
			UpdatePosition ();
		
		UpdateRotation (); 

	}

	void UpdatePosition ()
	{
		float localMoveSpeed = moveSpeed; // this is used because if the player is shooting, we slow down the speed
		localMoveSpeed /= (Player_Webshoot.shooting) ? 2f : 1;

		float horMov = Input.GetAxisRaw ("Horizontal") * localMoveSpeed * Time.deltaTime;
		float verMov = Input.GetAxisRaw ("Vertical") * localMoveSpeed * Time.deltaTime;
		transform.position += (horMov * Vector3.right + verMov * Vector3.forward);

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
