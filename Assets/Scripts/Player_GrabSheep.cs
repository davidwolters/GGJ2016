using UnityEngine;
using System.Collections;

public class Player_GrabSheep : MonoBehaviour 
{
	[SerializeField] private Vector3 relativeSheepPos;
	[SerializeField] private Vector3 relativeSheepRot;
	[SerializeField] private Player_CarrySheep carryScript;



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
			if (!Player_Webshoot.shooting)
			{
				sheep.SetParent (null);
				carryScript.SetCarrySheep (sheep);
				sheep = null;
			}
		}
	}


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == sheepTag && Player_Webshoot.shooting)
		{
			print ("TRI"); 
			sheep = other.transform;
			other.transform.SetParent (transform);
			other.transform.localRotation = relativeSheepQuat;
			other.transform.localPosition = relativeSheepPos;

		}
	}
}
