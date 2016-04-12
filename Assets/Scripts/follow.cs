using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {

    public AudioClip Crash;
    Transform player_trans;
    public GameObject explosion;
    public GameObject remains;
    private float speed = 8f, movespeed = 5.0f;
    private float health = 100f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    // Use this for initialization
    void Awake ()
    {
        player_trans = GameObject.FindGameObjectWithTag("Player").transform;
        source = GetComponent<AudioSource>();
      
    }
	
	// Update is called once per frame
	void Update ()
	{
	    health += Time.deltaTime*5;
	    if (health > 100)
	        health = 100;
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player_trans.position-transform.position, out hit))
        {
            if (hit.transform.tag == "Player")
            { 

                //GetComponent<Rigidbody>().MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player_trans.position - transform.position), speed * Time.deltaTime));
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player_trans.position - transform.position), speed * Time.deltaTime);

                //GetComponent<Rigidbody>().MovePosition(transform.forward * movespeed * Time.deltaTime);
                transform.position += transform.forward * movespeed * Time.deltaTime;
                if (transform.position.y > 2.5)
                {
                    //GetComponent<Rigidbody>().MovePosition(transform.up * movespeed * Time.deltaTime);
                    transform.position -= transform.up * movespeed * Time.deltaTime;
                }
                if (transform.position.y < 1.8)
                {
                    //GetComponent<Rigidbody>().MovePosition(transform.up * -movespeed * Time.deltaTime);
                    transform.position += transform.up * movespeed * Time.deltaTime;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position -= transform.forward * Time.deltaTime;
         
          float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(Crash);

            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Projectile")
        {

            Debug.Log("we are here2fs");
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(Crash,0.5f);

            health -= 150;
            if (health <= 0)
            {
                Debug.Log("we are here");
                Transform t = gameObject.transform;
              
                Destroy(gameObject);
                Instantiate(remains, t.position, t.rotation);
                Debug.Log("we are here129738yt");

            }
        }
    }
}
