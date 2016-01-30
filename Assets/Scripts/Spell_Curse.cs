using UnityEngine;
using System.Collections;

public class Spell_Curse : MonoBehaviour {

	[SerializeField] private float speed = 6f;

	
	
	
	
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
			// Make sheeps crazy.
		}
		else if (spellType == SpellType.spawn)
		{
			Instantiate ( Resources.Load ("Sheep"));
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
