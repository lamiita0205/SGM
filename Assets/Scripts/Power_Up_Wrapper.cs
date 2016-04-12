using UnityEngine;

public class Power_Up_Wrapper : MonoBehaviour {

	// Use this for initialization
    private float timer = 0f;
    private bool flag = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (timer > 0)
	    {
	        timer -= Time.deltaTime;
	    }
	    else if (flag)
	    {
	        flag = false;
	        transform.GetChild(0).gameObject.SetActive(true);
	    }
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && !flag)
        {
            timer = 20f;
            flag = true;
        }
    }
}
