using UnityEngine;
using System.Collections;

public class ScareCrow_Behaviour : MonoBehaviour 
{

	[SerializeField] private ParticleSystem ps;

	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter (Collision coll)
	{
		rb.constraints = RigidbodyConstraints.FreezeAll;
		ps.loop = false;
		ps.Stop ();
	}
}
