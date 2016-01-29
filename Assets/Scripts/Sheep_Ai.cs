using UnityEngine;
using System.Collections;

public class Sheep_Ai : MonoBehaviour {
	
	private NavMeshAgent agent;
	[SerializeField] private GameObject arena;
	void Start ()
	{
		agent = GetComponent <NavMeshAgent> ();
	}
	void Update ()
	{
		Vector3 dest = RandomVector(arena.transform.position - (arena.transform.localScale), arena.transform.position + (arena.transform.localScale) );
		agent.SetDestination(dest);
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
