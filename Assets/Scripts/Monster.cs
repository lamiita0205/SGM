using System;
using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    public GameObject explosion;
    private bool isDead = false;
    private float deathTimer = 0f;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
	    {
	        deathTimer -= Time.deltaTime;
	        if (deathTimer < 0)
	        {
	            Destroy(gameObject);
	            Instantiate(explosion, transform.position, Quaternion.identity);
	        }
	    }
	}
    
}
