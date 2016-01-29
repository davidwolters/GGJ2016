using UnityEngine;
using System.Collections;

public class Player_Webshoot : MonoBehaviour 
{
	[SerializeField] private float shootSpeed;
	[SerializeField] private float maxWebScale;
	[SerializeField] private float minWebScale;
	[SerializeField] private float origShootColldown = 0.3f;
	[SerializeField] private Transform hitBall;

	[HideInInspector] public static bool shooting = false;

	public bool canShoot = true;

	private float shootCoolDown = 0.0f;

	private Renderer renderer;
	private Renderer ballRenderer;

	void Start () 
	{
		renderer = GetComponent <Renderer> ();
		ballRenderer = hitBall.GetComponent <Renderer> ();
	}
	
	void Update () 
	{
		
		if (((Input.GetAxisRaw (Player_Controls.shoot) > 0) || shooting) && shootCoolDown == 0f && !Player_CarrySheep.carryingSheep && canShoot)
		{
			shooting = true;
			if (transform.localScale.y <= maxWebScale)
			{
				renderer.enabled = true;
				ballRenderer.enabled = true;
				ShootWeb (shootSpeed * Time.deltaTime);
				MoveObj (shootSpeed * Time.deltaTime * 2, hitBall);
				shooting = true;
				canShoot = true;
			} else
			{
				canShoot = false;
				//shooting = false;
				shootCoolDown = origShootColldown;

			}
		}

		if (!canShoot)
		{
			
			if (transform.localScale.y > minWebScale)
			{
				ShootWeb ((-shootSpeed * Time.deltaTime));
				MoveObj (-shootSpeed * Time.deltaTime * 2, hitBall);

			} else
			{
				print ("SHOOTING ENABLED"); 
				canShoot = true;
				shooting = false;
				renderer.enabled = false;
				ballRenderer.enabled = false;
			}
		}

		if (shootCoolDown > 0)
		{
			shootCoolDown -= Time.deltaTime;
			if (shootCoolDown < 0.01f)
			{
				shootCoolDown = 0;
			}
		}

	}


	void ShootWeb (float speed)
	{
		transform.localScale = Util.Scale (new Vector3 (0, speed, 0), transform.localScale);
		MoveObj (speed, transform);
	}

	void MoveObj (float speed, Transform moveObj)
	{
		moveObj.Translate (0, speed, 0);
	}


	void OnTriggerEnter (Collider other)
	{
		print ("On trigger enter"); 
		canShoot = false;


		//other.GetComponent <CapsuleCollider> ().enabled = false;

		//shooting = false;
	}
}
