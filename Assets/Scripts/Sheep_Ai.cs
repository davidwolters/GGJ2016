using UnityEngine;
using System.Collections;

public class Sheep_Ai : MonoBehaviour {
	
	// The navmesh agent.
	private NavMeshAgent agent;
	[SerializeField] private GameObject arena;
	
	public float maxNewDestInterval = 4;
	public float minNewDestInterval = 2;
	
	public int mandatoryDistance = 2;
	
	private float timeUntillNewDest = 0;
	void Start ()
	{
		agent = GetComponent <NavMeshAgent> ();
	}
	void Update ()
	{
		if (timeUntillNewDest <= 0)
		{
		
			Vector3 dest = new Vector3();
			
			// Generate a new random vector untill the mandatoryDistance is achived.
			while ( Vector3.Distance(dest, transform.position) < mandatoryDistance )
			{
				// Calculate the distance.
				dest = RandomVector(arena.transform.position - (arena.transform.localScale), arena.transform.position + (arena.transform.localScale) );
			}
			
			// Set the path.
			agent.SetDestination(dest);
			
			// Set the time untill next random dest.
			timeUntillNewDest = Random.Range(minNewDestInterval ,maxNewDestInterval);
		}
		else
		{
			
			timeUntillNewDest-=Time.deltaTime;
			
		}
	}
	
	
	public static Vector3 RandomVector (Vector3 start, Vector3 end)
	{
		Vector3 v = new Vector3();
		v.x = Random.Range(start.x, end.x);
		//v.y = Random.Range(start.y, end.y);
		v.z = Random.Range(start.z, end.z);
		return v;
		
      }

	
}
