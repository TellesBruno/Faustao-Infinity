using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocaScript : MonoBehaviour {

	public float cocaSpeed;
	public GameObject colisaoMalandro;
	public GameObject colisaoSergio;

	void FixedUpdate () {
		transform.Translate (0, cocaSpeed, 0);
		colisaoMalandro = GameObject.FindGameObjectWithTag ("Malandro");
		colisaoSergio = GameObject.FindGameObjectWithTag ("Sergio");
	}

	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
