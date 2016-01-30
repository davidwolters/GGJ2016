using UnityEngine;
using System.Collections;

public class Arena_CaptureZone : MonoBehaviour {

	public string target;
	[SerializeField] private Player_Points points;
	// Use this for initialization
	void Start () {
	
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
		GameObject Explosion = (GameObject)Instantiate(Resources.Load("Explosion"), pos, new Quaternion());

        
        ParticleSystem s = Explosion.GetComponent<ParticleSystem>();
		
		s.Play();
		
        Destroy(gameObject, s.duration);
		
		Destroy (Explosion, s.duration);
    }
	
}
