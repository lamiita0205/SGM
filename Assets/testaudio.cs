using UnityEngine;
using System.Collections;

public class testaudio : MonoBehaviour {
    public AudioClip crhas;
    private AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(crhas, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
