using UnityEngine;
using System.Collections;

public class Sheep_Ai : MonoBehaviour {
	
	// Speed, etc
	public float acceleration = 2f;
	public float deceleration = 60f;
	
	public float phaseAcceleration = 2f;
	public float phaseDeceleration = 60f;
	
	public float closeEnoughMeters = 4f;
	
	
	[HideInInspector] public bool sacrified = false;

	// The navmesh agent.
	private NavMeshAgent agent;
	
	// The filed we will be navigating on.
	[HideInInspector] public GameObject arena;


	[SerializeField] private float phaseSeconds = 0f;
	
	[SerializeField] private float phaseSpeed = 200f;
	
	[SerializeField] private float speed = 20f;

	[SerializeField] private float riseSpeed = 3f;

	[SerializeField] private float riseTurnSpeed = 3f;

	[SerializeField] private float lightSpeed = 1f;

	[SerializeField] private float targetRiseY = 20f;

	[SerializeField] private ParticleSystem ps;

	// The max and min of arena.
	private Mesh mesh;

	private Light light;
	
	
	// Old pos, to make sure we have some action going on.
	private Vector3 oldPos = new Vector3 ();
	
	// The destination.
	private Vector3 dest = new Vector3 ();
	
	// The distance that is required.
	public int mandatoryDistance = 2;
	
    
	
	void Start ()
	{
		
		// Get referacnes.
		agent = gameObject.GetComponent <NavMeshAgent> ();
		mesh = arena.GetComponent<MeshFilter>().sharedMesh;
		light = GetComponent <Light> ();
		light.intensity = 0f;
		DoNewPos ();
		if (agent)
		// Begin move cycle.
			agent.SetDestination(dest);
	}
	void OnEnable ()
	{
		Start();
	}
	
	void OnCollisionStay (Collision coll)
	{
		int oldMandatoryDistance = mandatoryDistance;
		if (coll.gameObject != arena && arena)
		{
			OnEnable();
		}
		mandatoryDistance = oldMandatoryDistance;
	}
	
	void DoNewPos ()
	{
		
		//Max of arena
		Vector3 max = TranslateBoundVec(mesh.bounds.max, arena.transform.lossyScale) + arena.transform.position;
		
		// Min of arena
		Vector3 min = TranslateBoundVec(mesh.bounds.min, arena.transform.lossyScale) + arena.transform.position;
		
		// The center, not used anymore.
		//Vector3 center = (mesh.bounds.center) + transform.position;
		
		// Reset the dest.
		dest = new Vector3();
		
		// Allowed tries.	
		int tries = 1000;
		
		// The amount we have tried.	
		int tried = 0;

		// Generate a new random vector untill the mandatoryDistance is achived.
		while (((Vector3.Distance(dest, new Vector3() )== 0) || Vector3.Distance(oldPos, transform.position) < 3 || Vector3.Distance(dest, transform.position) < mandatoryDistance) )
		{
			// Calculate the distance.
			dest = RandomVector(max, min);
			if (tries > tried)
				break;
			tried++;
			
		}
		
		// Set old pos.			
		oldPos = dest;

		
	}
	
	
	public void Phase (int seconds)
	{
		phaseSeconds = seconds;
		GetComponent <Rigidbody> ().isKinematic = true;
		
		gameObject.GetComponent<NavMeshAgent>().speed = phaseSpeed;
		ps.loop = true;
		ps.Play ();
		
	}
	
	void Update ()
	{
		ps.transform.position = transform.position;
		if (sacrified)
		{
			light.intensity += lightSpeed * Time.deltaTime;
			agent.enabled = false;
			transform.position += Vector3.up * riseSpeed * Time.deltaTime;
			transform.Rotate (0, riseTurnSpeed * Time.deltaTime, 0);
			GetComponent <Rigidbody> ().isKinematic = true;
			GetComponent <BoxCollider> ().enabled = false;

			if (transform.position.y >= targetRiseY)
			{
				GameObject.Destroy (gameObject);
			}
		} else
		{
			// Check if we are in dest.
			if (Vector3.Distance(dest, transform.position) <= 1)
			{


				DoNewPos ();

				// Set the path.
				agent.SetDestination(dest);

			}

			if (agent.enabled)
			{

				// speed up slowly, but stop quickly
				if (agent.hasPath)

				if (phaseSeconds <= 0)
				{
					if (ps.isPlaying)
						ps.Stop ();
					GetComponent <Rigidbody> ().isKinematic = false;
					agent.acceleration = (agent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
					gameObject.GetComponent<NavMeshAgent>().speed = speed;

				}
				else
				{
					agent.acceleration = (agent.remainingDistance < closeEnoughMeters) ? phaseDeceleration : phaseAcceleration;
					phaseSeconds -= Time.deltaTime;
				}
			}
		}


		
	}
	
	// Good function
	Vector3 TranslateBoundVec (Vector3 a, Vector3 b)
	{
		return new Vector3 (a.x * b.x, a.y * b.y, a.z * b.z);
	}
	
	
	public static Vector3 RandomVector (Vector3 start, Vector3 end)
	{
		Vector3 v = new Vector3();
		v.x = Random.Range(start.x, end.x);
		v.y = Random.Range(start.y, end.y);
		v.z = Random.Range(start.z, end.z);
		
		
		return v;
		
   	}
}
