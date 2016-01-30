using UnityEngine;
using System.Collections;

public class Player_GrabSheep : MonoBehaviour 
{
	[SerializeField] private Vector3 relativeSheepPos;
	[SerializeField] private Vector3 relativeSheepRot;
	[SerializeField] private Player_CarrySheep carryScript;
	[SerializeField] private Player_Webshoot shootScript;



	private Quaternion relativeSheepQuat;

	private string sheepTag = "Sheep";

	private Transform sheep;


	// Use this for initialization
	void Start ()
	{
		relativeSheepQuat = Quaternion.Euler (relativeSheepRot);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (sheep != null)
		{
			if (!(Util.Shooting (shootScript.player)))
			{
				sheep.SetParent (null);
				carryScript.SetCarrySheep (sheep, shootScript.player);
				sheep = null;
			}
		}
	}
	 

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == sheepTag && Util.Shooting (shootScript.player))
		{
			sheep = other.transform;
			other.transform.SetParent (transform);
			other.transform.localRotation = relativeSheepQuat;
			other.transform.localPosition = relativeSheepPos;
			other.GetComponent <NavMeshAgent> ().enabled = false;


		}


	}
}
