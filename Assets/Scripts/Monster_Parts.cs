using UnityEngine;
using System.Collections;

public class Monster_Parts : MonoBehaviour {

    public GameObject explosion;
    public float deathTimer = 5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            deathTimer -= Time.deltaTime;
            if (deathTimer < 0)
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }
    }

