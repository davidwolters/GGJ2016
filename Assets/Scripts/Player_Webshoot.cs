using UnityEngine;
using System.Collections;

public class Player_Webshoot : MonoBehaviour 
{
	[SerializeField] private float shootSpeed;
	[SerializeField] private float maxWebScale;
	[SerializeField] private float minWebScale;
	[SerializeField] private float origShootColldown = 0.3f;
	[SerializeField] private Transform hitBall;
	public PlayerType player = PlayerType.PLAYER1;

	[HideInInspector] public static bool shooting1 = false;
	[HideInInspector] public static bool shooting2 = false;

	public bool canShoot = true;

	private float shootCoolDown = 0.0f;

	private Renderer renderer;
	private Renderer ballRenderer;

	private AudioSource source;


	void Start () 
	{
		renderer = GetComponent <Renderer> ();
		ballRenderer = hitBall.GetComponent <Renderer> ();
		source = GetComponent <AudioSource> ();
	}
	
	void Update () 
	{
		if ((((Input.GetKeyDown (Player_Controls.shoot (player))) || Util.Shooting (player)) && shootCoolDown == 0f && !Player_CarrySheep.carryingSheep && canShoot))
		{
			if (Input.GetKeyDown (Player_Controls.shoot (player)))
			{
				source.Play ();
			}

			shooting1 = player == PlayerType.PLAYER1;
			shooting2 = player == PlayerType.PLAYER2;
			if (transform.localScale.y <= maxWebScale)
			{

				renderer.enabled = true;
				ballRenderer.enabled = true;
				ShootWeb (shootSpeed * Time.deltaTime);
				MoveObj (shootSpeed * Time.deltaTime * 2, hitBall);
				shooting1 = player == PlayerType.PLAYER1;
				shooting2 = player == PlayerType.PLAYER2;
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
				canShoot = true;
				if (player == PlayerType.PLAYER1)
				{
					shooting1 = false;
				} else 
				{
					shooting2 = false;
				}

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
		canShoot = false;


		//other.GetComponent <CapsuleCollider> ().enabled = false;

	}
}
