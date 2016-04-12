using UnityEngine;
using System.Collections;

public class Bullet_Detonator : MonoBehaviour {

	// Use this for initialization
    private float lifespan = 1.0f;
    public GameObject remains;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    lifespan -= Time.deltaTime;
	    if (lifespan <= 0)
	    {
	        Explode();
	    }
	}

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
