using UnityEngine;
using System.Collections;

public class Player_MovementScript : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private Camera cam;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdatePosition ();
		UpdateRotation (); 

	}

	void UpdatePosition ()
	{
		float horMov = Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime;
		float verMov = Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime;
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
