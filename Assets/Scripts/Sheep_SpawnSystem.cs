using UnityEngine;
using System.Collections;

public class Sheep_SpawnSystem : MonoBehaviour 
{
	[SerializeField] private GameObject[] spawnPoints;

	[SerializeField] private GameObject[] spawnObjects;
	[SerializeField] private float minSpawnTime;
	[SerializeField] private float maxSpawnTime;

	float currentTimer = 0f;

	// Use this for initialization
	void Start () 
	{
		currentTimer = GetSpawnTime ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentTimer > 0)
		{
			 
			currentTimer -= Time.deltaTime;
			if (currentTimer <= 0)
			{
				SpawnSheep ();
				currentTimer = GetSpawnTime ();
			}
		}

	}


	float GetSpawnTime ()
	{
		return Random.Range (minSpawnTime, maxSpawnTime);
	}

	void SpawnSheep ()
	{
		int index = GetSpawn ();

		Instantiate (spawnObjects[index], spawnPoints[RevertSpawn (index)].transform.position, spawnPoints[GetSpawn ()].transform.rotation);
		print ("SPAWN OBJECT"); 
	}

	int GetSpawn (){
		return Random.Range (0, 2);

	}

	int RevertSpawn (int i)
	{
		switch (i)
		{
		case 1:
			return 0;
			break;
		case 0:
			return 1;
			break;
		}
		return 0;
	}

}
