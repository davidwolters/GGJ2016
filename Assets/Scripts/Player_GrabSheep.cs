using UnityEngine;
using System.Collections;

public class Player_GrabSheep : MonoBehaviour 
{
	
	[SerializeField] private Player_CarrySheep carryScript;
	[SerializeField] private Player_Webshoot shootScript;




	private string sheepTag = "Sheep";

	private Transform sheep;


	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (sheep != null)
		{
			if (!(Util.Shooting (shootScript.player)))
			{
				this.GetComponent <Collider> ().enabled = true;
				sheep.SetParent (null);
				carryScript.SetCarrySheep (sheep, shootScript.player);
				sheep = null;
			}
		}
	}
	 

	void OnTriggerEnter (Collider other)
	{
		if (other.tag.EndsWith (sheepTag) && Util.Shooting (shootScript.player))
		{
			sheep = other.transform;
			other.transform.SetParent (transform);
			other.GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
			other.GetComponent <Rigidbody> ().isKinematic = true;
			this.GetComponent <Collider> ().enabled = false;


		}

		shootScript.canShoot = false;


	}
}
