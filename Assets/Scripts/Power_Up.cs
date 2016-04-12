using UnityEngine;
using System.Collections;

public class Power_Up : MonoBehaviour {

	// Use this for initialization
    private float timer = 0f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision collision)
    {
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
