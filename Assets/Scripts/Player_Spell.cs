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
		
		RaycastHit hit;
		
		// TODO: Use a case.
		if (spell == 1)
		{
			Vector3 fwd = transform.forward;
			//TransformDirection(Vector3.forward);
        	if (Physics.Raycast(transform.position, fwd, out hit, 10) )
			{
				
				print("There is something in front of the object!");
				print (hit.transform.gameObject.name);
			}
			
		}
		else if (spell == 2)
		{
			
		}
	}
}
