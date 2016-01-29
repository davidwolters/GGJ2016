using UnityEngine;
using System.Collections;

public class Sheep_Ai : MonoBehaviour {
	
	private NavMeshAgent agent;
	[SerializeField] private GameObject arena;
	
	public float maxNewDestInterval = 4;
	public float minNewDestInterval = 2;
	
	private float timeUntillNewDest = 0;
	void Start ()
	{
		agent = GetComponent <NavMeshAgent> ();
	}
	void Update ()
	{
		if (timeUntillNewDest <= 0)
		{
		
			Vector3 dest = RandomVector(arena.transform.position - (arena.transform.localScale), arena.transform.position + (arena.transform.localScale) );
			agent.SetDestination(dest);
			timeUntillNewDest = Random.Range(minNewDestInterval ,maxNewDestInterval);
		}
		else
		{
			
			timeUntillNewDest-=Time.deltaTime;
			
		}
		//agent.
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
