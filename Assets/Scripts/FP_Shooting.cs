using UnityEngine;
using System.Collections;
using System.Security.AccessControl;

public class FP_Shooting : MonoBehaviour
{
    public AudioClip miniGunShot;

    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private float bulletImpulse = 3000f;

    public GameObject bullet_prefab;

	// Use this for initialization
	void Awake () {

        source = GetComponent<AudioSource>();
        
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))
	    {
            Camera cam = Camera.main;
           
            GameObject theBullet = (GameObject) Instantiate(bullet_prefab, cam.transform.position+ cam.transform.forward, cam.transform.rotation);
	        theBullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward*bulletImpulse, ForceMode.Impulse);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(miniGunShot, 0.5f);

        }
	}
}
