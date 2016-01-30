﻿using UnityEngine;
using System.Collections;

public class Spell_Curse : MonoBehaviour {

	[SerializeField] private float speed = 6f;

	[HideInInspector ]public GameObject curser;

	// The enemy you want to hit.
	private GameObject enemySheep;
	
	// The one who threw this curse.
	private GameObject playerSheep;
	
	private GameObject enemyArena;
	
	private GameObject playerArena;
	
	private GameObject enemyObject;
	
	public SpellType spellType;
	public enum SpellType {
		
		unknown,
		freeze,
		spawn,
		crazy_sheeps,
		wall_block
		
	}

	Rigidbody rg;

	
	public void GetRef (GameObject curser)
	{
		
		this.curser = curser;
		
		rg = gameObject.GetComponent<Rigidbody>();
		
		playerSheep = curser.GetComponent<Player_Spell>().playerSheep;
		enemySheep = curser.GetComponent<Player_Spell>().enemySheep;
		playerArena = curser.GetComponent<Player_Spell>().playerArena;
		enemyArena = curser.GetComponent<Player_Spell>().enemyArena;
		enemyObject = curser.GetComponent<Player_Spell>().enemyObject;
	}
	
	void OnCollisionEnter (Collision coll)
	{
		
		
		if (spellType == SpellType.crazy_sheeps)
		{
			// Make sheeps crazy.
			
			GameObject [] sheeps = GameObject.FindGameObjectsWithTag(playerSheep.tag);
			
			foreach (GameObject element in sheeps)
			{
    			// For each
				element.GetComponent<Sheep_Ai>().Phase(2);
			}
			
			GameObject.Destroy ( gameObject );
			
			
		}
		else if (spellType == SpellType.freeze)
		{
			
			enemyObject.GetComponent<Player_Movement>().Freeze(7);
			GameObject.Destroy ( gameObject );
		}
		else if (spellType == SpellType.spawn)
		{
		
			print ("SPAWN");
			Mesh mesh = enemyArena.GetComponent<MeshFilter>().sharedMesh;
			
			Vector3 center = (mesh.bounds.center) + enemyArena.transform.position;
			
		
			GameObject sheep = (GameObject) Instantiate ( enemySheep, center, transform.rotation);
			
			
			sheep.GetComponent<Sheep_Ai>().enabled = false;
			sheep.GetComponent<Sheep_Ai>().arena = enemyArena;
			sheep.GetComponent<Sheep_Ai>().enabled = true;
			
			
			GameObject.Destroy(this.gameObject);
			
		}
		else if (spellType == SpellType.wall_block)
		{
			// Make sheeps crazy.
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		rg.velocity = transform.forward * speed;
		
	
	}
	
	public void SetCurseById( int id)
	{
		Player_Points points = curser.GetComponent<Player_Spell>().points;
		print ("Mana is: "+points.mana);
		if (id == 0 && points.mana >= 1)
		{
			points.mana -= 1;
			spellType = SpellType.crazy_sheeps;
			return;
		}
		else if (id == 1 && points.mana >= 3)
		{
			points.mana -= 3;
			spellType = SpellType.freeze;
			return;
		}
		else if (id == 2 && points.mana >= 5)
		{
			points.mana -= 5;
			spellType = SpellType.spawn;
			return;
		}
		else if (id == 3 && points.mana >= 2)
		{
			points.mana -= 2;
			spellType = SpellType.wall_block;
			return;
		}
		else
		{
			GameObject.Destroy(this.gameObject);
		}
		
		
	}
}
