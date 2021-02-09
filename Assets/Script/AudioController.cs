using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioClip Shot;
    public AudioClip Clay;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void GunSE(){
        audioSource.PlayOneShot(Shot);
    }

    public void ClaySE(){
        audioSource.PlayOneShot(Clay);
    }
}
