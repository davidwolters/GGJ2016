using UnityEngine;
using System.Collections;

public class Player_CarrySheep : MonoBehaviour 
{
	[SerializeField] private Vector3 relativeSheepPos;
	[SerializeField] private Vector3 relativeSheepRot;
	[SerializeField] private Vector3 relativePutDownSheepPos;
	[SerializeField] private PlayerType player;
	[SerializeField] private float minTimeUntilDrop;
	[SerializeField] private float maxTimeUntilDrop;

	private float timeUntilDropTimer = 0;

	private Quaternion relativeSheepQuat;

	private Transform sheep;

	public static bool carryingSheep1 = false;
	public static bool carryingSheep2 = false;

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
			if (Input.GetKeyDown (Player_Controls.pickUpSheep (player)))
			{
				DropSheep ();
			}
		}

		if (timeUntilDropTimer > 0)
		{
			timeUntilDropTimer -= Time.deltaTime;
			if (timeUntilDropTimer <= 0)
			{
				timeUntilDropTimer = 0;
				if (sheep != null)
				{
					DropSheep ();
				}
			}

		}


	}

	void OnCollisionStay (Collision coll)
	{
		if (coll.collider.tag == "Sheep")
		{
			if (Input.GetKeyDown (Player_Controls.pickUpSheep (player)))
			{
				SetCarrySheep (coll.transform, player);
				spaceDown = true;
			}
		}
	}


	public void SetCarrySheep (Transform sheep, PlayerType player)
	{
		print ("Carry sheep"); 
		if (this.player == player)
		{
			this.sheep = sheep;
			this.sheep.SetParent (transform);
			this.sheep.localPosition = relativeSheepPos;
			this.sheep.localRotation = relativeSheepQuat;
			this.sheep.GetComponent <Sheep_Ai> ().enabled = false;
			this.sheep.GetComponent <Rigidbody> ().isKinematic = true;
		}
		timeUntilDropTimer = Random.Range (minTimeUntilDrop, maxTimeUntilDrop);
	}

	void DropSheep ()
	{
		sheep.GetComponent <Sheep_Ai> ().enabled = true;
		sheep.GetComponent <CapsuleCollider> ().enabled = true;
		this.sheep.GetComponent <Rigidbody> ().isKinematic = false;
		sheep.GetComponent <NavMeshAgent> ().enabled = true;



		sheep.localPosition = relativePutDownSheepPos;
		sheep.SetParent (null);
		sheep = null;	
		carryingSheep = false;
	}
}
