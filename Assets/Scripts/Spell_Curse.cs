using UnityEngine;
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
	
	
	public SpellType spellType;
	public enum SpellType {
		
		freeze,
		spawn,
		crazy_sheeps,
		wall_block
		
	}

	Rigidbody rg;

	// Use this for initialization
	void Start () {
	
		rg = GetComponent<Rigidbody>();
		
		playerSheep = curser.GetComponent<Player_Spell>().playerSheep;
		enemySheep = curser.GetComponent<Player_Spell>().enemySheep;
		playerArena = curser.GetComponent<Player_Spell>().playerArena;
		enemyArena = curser.GetComponent<Player_Spell>().enemyArena;
		
	
	}
	
	void OnCollisionEnter (Collision coll)
	{
		
		
		if (spellType == SpellType.crazy_sheeps)
		{
			// Make sheeps crazy.
		}
		else if (spellType == SpellType.freeze)
		{
			// Make sheeps crazy.
		}
		else if (spellType == SpellType.spawn)
		{
			GameObject sheep = (GameObject) Instantiate ( enemySheep, transform.position, transform.rotation);
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
		print ("SET CURSE!" + id );
		if (id == 0)
			spellType = SpellType.crazy_sheeps;
		if (id == 1)
			spellType = SpellType.freeze;
		if (id == 2)
			spellType = SpellType.spawn;
		if (id == 3)
			spellType = SpellType.wall_block;
	}
}
