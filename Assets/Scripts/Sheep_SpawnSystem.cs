using UnityEngine;
using System.Collections;

public class Sheep_SpawnSystem : MonoBehaviour 
{
	[SerializeField] private GameObject[] spawnPoints;

	[SerializeField] private GameObject[] spawnObjects;
	[SerializeField] private GameObject ground1;
	[SerializeField] private GameObject ground2;
	[SerializeField] private float minSpawnTime;
	[SerializeField] private float maxSpawnTime;


	float currentTimer = 0f;

	// Use this for initialization
	void Start () 
	{
		print ("asdfasdf"); 
		currentTimer = GetSpawnTime ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		print (currentTimer); 
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

		GameObject sheepObj = (GameObject) Instantiate (spawnObjects[index], spawnPoints[RevertSpawn (index)].transform.position, spawnPoints[GetSpawn ()].transform.rotation);
		Sheep_Ai sheep = sheepObj.GetComponent <Sheep_Ai> ();
		sheep.arena = (index == 0) ? ground1 : ground2;
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
