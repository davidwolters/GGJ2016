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
	void FixedUpdate () 
	{
		if (Input.GetKeyDown(spell1))
			DoSpell(0);
		if (Input.GetKeyDown(spell2))
			DoSpell(1);
		if (Input.GetKeyDown(spell3))
			DoSpell(3);
		if (Input.GetKeyDown(spell4));
			//DoSpell(3);
			
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
			
			GameObject [] sheeps = GameObject.FindGameObjectsWithTag(playerSheep.transform.tag);
			//sheeps [sheeps.Length - 1] = null;
			//sheeps [sheeps.Length - 2] = null;
			//sheeps [sheeps.Length - 3] = null;


			print (sheeps.Length + ", : " + playerSheep.tag);
			if (sheeps.Length > 0 + 3)
			{
				foreach (GameObject element in sheeps)
				{
					if (element.activeSelf && element != null)
					{
						if (element.GetComponent <Sheep_Ai> () != null)
						{
							element.GetComponent <Sheep_Ai> ().Phase (7);
						}
					}
				}
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

			pos.y = 30;
			
			Instantiate (crusherBlock, pos, Quaternion.identity);
			return;
	
		}
	}
	
	// Set the curse/spell by id.	
	public void SetCurseById(int id)
	{
		spellType = SpellType.unknown;
		if (id == 0 && points.mana >= 40)
		{
			print (HasSheep ()); 
			if (HasSheep ())
			{
				points.mana -= 40;
				spellType = SpellType.crazy_sheeps;
			}
		}
		else if (id == 1 && points.mana >= 30)
		{
			points.mana -= 30;
			spellType = SpellType.freeze;
		}
		else if (id == 2 && points.mana >= 10)
		{
			points.mana -= 10;
			spellType = SpellType.spawn;
		}
		else if (id == 3 && points.mana >= 30)
		{
			points.mana -= 30;
			spellType = SpellType.wall_block;
		}
		print ("Mana is: " + points.mana);
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


	bool HasSheep ()
	{
		GameObject[] sheep = GameObject.FindGameObjectsWithTag (playerSheep.tag);
		print (sheep.Length);
		return sheep.Length - 3 > 0;
	}
	
}
