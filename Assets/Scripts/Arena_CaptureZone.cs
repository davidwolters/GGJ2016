using UnityEngine;
using System.Collections;

public class Arena_CaptureZone : MonoBehaviour {

	public string target;

	[SerializeField] private Player_Points points;

	ParticleSystem particles;


	// Use this for initialization
	void Start () 
	{
		//GameObject Explosion = (GameObject)Instantiate(Resources.Load("Explosion"), transform.position, new Quaternion());
		//particles = Explosion.GetComponent<ParticleSystem>();
	}
	
	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.tag.Equals(target))
		{
			points.Point += 1;
			ExplodeEffect(coll.transform.position);
			GameObject.Destroy(coll.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ExplodeEffect(Vector3 pos) {

        

		//particles.Play();
		
        //Destroy(gameObject, s.duration);
		
		//Destroy (Explosion, particles.duration);
    }

	
}
