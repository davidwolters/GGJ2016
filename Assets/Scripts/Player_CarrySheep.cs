using UnityEngine;
using System.Collections;

public class Player_CarrySheep : MonoBehaviour 
{
	[SerializeField] private Vector3 relativeSheepPos;
	[SerializeField] private Vector3 relativeSheepRot;
	[SerializeField] private Vector3 relativePutDownSheepPos;

	private Quaternion relativeSheepQuat;

	private Transform sheep;

	public static bool carryingSheep = false;

	private bool spaceDown = false;


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
			carryingSheep = true;
			if (Input.GetAxisRaw (Player_Controls.sheepPickup) > 0)
			{
				sheep.localPosition = relativePutDownSheepPos;
				sheep.SetParent (null);
				sheep = null;
				carryingSheep = false;
			}
		}

		if (Input.GetAxisRaw (Player_Controls.sheepPickup) == 0)
		{
			spaceDown = false;
		}
	}

	void OnCollisionStay (Collision coll)
	{
		if (coll.collider.tag == "Sheep")
		{
			if (Input.GetAxisRaw (Player_Controls.sheepPickup) > 0 && !spaceDown)
			{
				SetCarrySheep (coll.transform);
				spaceDown = true;
			}
		}
	}


	public void SetCarrySheep (Transform sheep)
	{
		this.sheep = sheep;
		this.sheep.SetParent (transform);
		this.sheep.localPosition = relativeSheepPos;
		this.sheep.localRotation = relativeSheepQuat;

	}
}
