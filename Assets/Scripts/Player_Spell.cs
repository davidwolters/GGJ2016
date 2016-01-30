using UnityEngine;
using System.Collections;

public class Player_Spell : MonoBehaviour {

	[SerializeField] private KeyCode spell1 = KeyCode.Alpha1;
	[SerializeField] private KeyCode spell2 = KeyCode.Alpha2;
	[SerializeField] private KeyCode spell3 = KeyCode.Alpha3;
	[SerializeField] private KeyCode spell4 = KeyCode.Alpha4;
	private int spell;
	[SerializeField] private Player_Points points;

	// Update is called once per frame
	void Update () {
	
		/*Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			Vector3 lookPoint = hit.point;
			//lookPoint.y = transform.position.y;
			//transform.LookAt (lookPoint);
			
			
			
		}
		*/
		if (Input.GetKey(spell1))
			DoSpell(1);
		if (Input.GetKey(spell2))
			DoSpell(2);
		if (Input.GetKey(spell3))
			DoSpell(3);
		if (Input.GetKey(spell4))
			DoSpell(4);
			
	}
	void DoSpell(int spell)
	{
		
		GameObject curse = (GameObject) Instantiate(Resources.Load("Curse"), transform.position, transform.rotation);
		
		Spell_Curse spell_curse = curse.GetComponent<Spell_Curse>();
		
		spell_curse.SetCurseById (spell);
	}
}
