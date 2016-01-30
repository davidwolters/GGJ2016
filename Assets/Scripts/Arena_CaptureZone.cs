using UnityEngine;
using System.Collections;

public class Arena_CaptureZone : MonoBehaviour {

	public string target;

	[SerializeField] private Player_Points points;



	// Use this for initialization
	void Start () 
	{

	}
	
	void OnCollisionStay (Collision coll)
	{
		print ("trigger: " + coll.transform.tag+ ", =? " + target); 
		if (coll.gameObject.tag.Equals(target))
		{
			
			points.Point += 1;
			ExplodeEffect(coll.transform.position);


			print ("U IS DEAD"); 

			GameObject.Destroy(coll.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void ExplodeEffect(Vector3 pos) {

        

		//particles.Play();
		
        //Destroy(gameObject, s.duration);
		
		//Destroy (Explosion, particles.duration);
    }

	
}
