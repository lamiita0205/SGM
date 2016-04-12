using UnityEngine;
using System.Collections;

public class Remains_Cleanup : MonoBehaviour {

	// Use this for initialization
    private float deathTimer = 6;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        deathTimer -= Time.deltaTime;
        if (deathTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
