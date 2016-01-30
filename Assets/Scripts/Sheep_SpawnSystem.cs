using UnityEngine;
using System.Collections.Generic;

public class Sheep_SpawnSystem : MonoBehaviour 
{
	[SerializeField] private GameObject[] spawnPoints;

	[SerializeField] private GameObject[] spawnObjects;
	[SerializeField] private GameObject ground1;
	[SerializeField] private GameObject ground2;
	[SerializeField] private float minSpawnTime;
	[SerializeField] private float maxSpawnTime;
	[SerializeField] private int maxSidesInRow = 2;
	[SerializeField] private int maxSheepInGame = 20;
	[SerializeField] private int minimumMaxSheepInGame = 5;
	[SerializeField] private float timeUntilLevelUp = 5;
	[SerializeField] private int levelUpSheepDecreaseAmount = 1;

	private float levelUpTimer;

	private List <GameObject> spawnedSheep = new List <GameObject> ();
	private int sheepInGame = 0;

	private int currentMaxSheepInGame = 0;

	float currentTimer = 0f;

	int currentSide = 0;
	int sideInRow = 0;
	// Use this for initialization
	void Start () 
	{
		currentTimer = GetSpawnTime ();
		currentSide = Random.Range (0, 2);
		currentMaxSheepInGame = maxSheepInGame;
		levelUpTimer = timeUntilLevelUp;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetSheepInGame ();
		if (currentTimer > 0)
		{
			 
			currentTimer -= Time.deltaTime;
			if (currentTimer <= 0)
			{
				if (sheepInGame < currentMaxSheepInGame)
				{
					SpawnSheep ();
				}
				currentTimer = GetSpawnTime ();

			}
		}
		levelUpTimer -= Time.deltaTime;
		if (levelUpTimer <= 0)
		{
			if (currentMaxSheepInGame > minimumMaxSheepInGame)
			{
				currentMaxSheepInGame -= levelUpSheepDecreaseAmount;
				levelUpTimer = timeUntilLevelUp;
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

		GameObject sheepObj = (GameObject) Instantiate (spawnObjects[index], spawnPoints[RevertSpawn (index)].transform.position, spawnPoints[index].transform.rotation);
		Sheep_Ai sheep = sheepObj.GetComponent <Sheep_Ai> ();
		sheep.arena = (index == 0) ? ground1 : ground2;
		spawnedSheep.Add (sheepObj);
	}

	int GetSpawn ()
	{
		int side = 0;
		/*if (sideInRow < maxSidesInRow)
		{
			side = Random.Range (0, 2);
			if (side == currentSide)
			{
				sideInRow++;
			} else
			{
				sideInRow = 0;
			}
		} else
		{
			sideInRow = 0;
			switch (currentSide)
			{
			case 0:
				side = 1;
				break;
			case 1:
				side = 0;
				break;
			}
		}*/
		switch (currentSide)
		{
		case 0:
			side = 1;
			break;
		case 1:
			side = 0;
			break;
		}

		currentSide = side;
		return side;
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

	void GetSheepInGame ()
	{
		GameObject[] sheep1 = GameObject.FindGameObjectsWithTag("Player1Sheep");
		GameObject[] sheep2 = GameObject.FindGameObjectsWithTag("Player2Sheep");
		sheepInGame = sheep1.Length + sheep2.Length;
	}

}
