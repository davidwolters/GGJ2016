using UnityEngine;
using System.Collections;

public class Player_Spell : MonoBehaviour {

	[SerializeField] private KeyCode spell1 = KeyCode.Alpha1;
	[SerializeField] private KeyCode spell2 = KeyCode.Alpha2;
	[SerializeField] private KeyCode spell3 = KeyCode.Alpha3;
	[SerializeField] private KeyCode spell4 = KeyCode.Alpha4;
	private int spell;
	public Player_Points points;

	public GameObject playerSheep;
	public GameObject enemySheep;

	public GameObject playerGround;
	public GameObject enemyGround;
	
	public GameObject enemyObject;
	
	public GameObject crusherBlock;
	
	public SpellType spellType;
	public enum SpellType {
		
		unknown,
		freeze,
		spawn,
		crazy_sheeps,
		wall_block
		
	}
	
	// For every key.
	void Update () {
		if (Input.GetKey(spell1))
			DoSpell(0);
		if (Input.GetKey(spell2))
			DoSpell(1);
		if (Input.GetKey(spell3))
			DoSpell(2);
		if (Input.GetKey(spell4))
			DoSpell(3);
			
	}
	
	
	void DoSpell(int spell)
	{
		SetCurseById(spell);
		DoSpell();
	}
	
	// Perform the spell / curse.
	void DoSpell()
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
				
				return;
				
				
			}
			else if (spellType == SpellType.freeze)
			{
				
				enemyObject.GetComponent<Player_Movement>().Freeze(7);
				return;
			}
			else if (spellType == SpellType.spawn)
			{
			
				print ("SPAWN");
				Mesh mesh = enemyGround.GetComponent<MeshFilter>().sharedMesh;
				
				Vector3 center = (mesh.bounds.center) + enemyGround.transform.position;
				
			
				GameObject sheep = (GameObject) Instantiate ( enemySheep, center, transform.rotation);
				
				
				sheep.GetComponent<Sheep_Ai>().enabled = false;
				sheep.GetComponent<Sheep_Ai>().arena = enemyGround;
				sheep.GetComponent<Sheep_Ai>().enabled = true;
				
				
				return;
				
			}
			else if (spellType == SpellType.wall_block)
			{
				Mesh mesh = playerGround.GetComponent<MeshFilter>().sharedMesh;
				//Max of arena
				Vector3 max = TranslateBoundVec(mesh.bounds.max, playerGround.transform.lossyScale) + playerGround.transform.position;
			
				// Min of arena
				Vector3 min = TranslateBoundVec(mesh.bounds.min, playerGround.transform.lossyScale) + playerGround.transform.position;
			
				
				Vector3 pos = RandomVector (max, min);
				
				// DIRTY ALERT!
				pos.z = 0;
				
				Instantiate (crusherBlock, pos, Quaternion.identity);
				return;
		
			}
	}
	
	// Set the curse/spell by id.	
	public void SetCurseById( int id)
	{
		print ("Mana is: "+points.mana);
		if (id == 0 && points.mana >= 5)
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
		else if (id == 2 && points.mana >= 1)
		{
			points.mana -= 1;
			spellType = SpellType.spawn;
			return;
		}
		else if (id == 3 && points.mana >= 3)
		{
			points.mana -= 3;
			spellType = SpellType.wall_block;
			return;
		}
		
	}
	
	// Good functions!
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
