using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgmanScript : MonoBehaviour {

	public float burgmanSpeed;
	public GameObject colisaoPlayer;

	void FixedUpdate () {
		transform.Translate (0, burgmanSpeed, 0);
		colisaoPlayer = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
