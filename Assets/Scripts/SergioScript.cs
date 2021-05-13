using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SergioScript : MonoBehaviour {

	public float serSpeed;
	public GameObject raieie;


	void Start () {
	}

	void FixedUpdate () {
		transform.Translate (0, serSpeed, 0);
	}

	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D colisaoTiro){
		if (colisaoTiro.gameObject.tag == "Coca") {
			Instantiate (raieie, new Vector2 (0, 0), Quaternion.identity);
			Destroy (colisaoTiro.gameObject);
			Destroy (this.gameObject);
		}
	}
}
