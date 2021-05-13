using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IeIeScript : MonoBehaviour {

	private float fimAudio;
	public float durasaoAudio;

	void Start () {
		AudioPlay ();
		fimAudio = Time.time + durasaoAudio;
	}

	void FixedUpdate(){
		if (Time.time > fimAudio) {
			Destroy (this.gameObject);
		}
	}

	public void AudioPlay (){
		AudioSource raie = GetComponent<AudioSource> ();
		raie.Play ();
	}
}
