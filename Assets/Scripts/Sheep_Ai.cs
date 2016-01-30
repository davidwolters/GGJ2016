using UnityEngine;
using System.Collections;

public class Sheep_Ai : MonoBehaviour {
	
	// Speed, etc
	public float acceleration = 2f;
	public float deceleration = 60f;
	public float closeEnoughMeters = 4f;
	
	
	
	// The navmesh agent.
	private NavMeshAgent agent;
	
	// The filed we will be navigating on.
	[SerializeField] private GameObject arena;
	
	// The max and min of arena.
	private Mesh mesh;
	
	// Old pos, to make sure we have some action going on.
	private Vector3 oldPos = new Vector3 ();
	
	// The destination.
	private Vector3 dest = new Vector3 ();
	
	// The distance that is required.
	public int mandatoryDistance = 2;
	
	// For debug.
	public GameObject block;
	void Start ()
	{
		// Get referacnes.
		agent = GetComponent <NavMeshAgent> ();
		mesh = arena.GetComponent<MeshFilter>().mesh;
		DoNewPos ();
		
		// Begin move cycle.
		agent.SetDestination(dest);
	}

	void OnEnable ()
	{
		print ("ENABLICUS");
		DoNewPos ();
		agent.SetDestination(dest);

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
		
		// Debug.
		Instantiate (block, dest, Quaternion.identity);

		
	}
	
	void Update ()
	{

		// Check if we are in dest.
		if (Vector3.Distance(dest, transform.position) <= 1)
		{
		
			
			DoNewPos ();
			
			// Set the path.
			agent.SetDestination(dest);
		
			print (dest);
		}
		
		if (agent)
     {
 
       // speed up slowly, but stop quickly
       if (agent.hasPath)
         agent.acceleration = (agent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
 
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
