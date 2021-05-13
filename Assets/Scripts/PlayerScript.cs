using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public bool churraqueira;

	public float speed;
	public float fireRate;
	private float backup_fireRate;
	private float nextFire;
	public float timerChurras;

	public AudioSource tiroCoca;
	public Transform tiroSpaw;
	public GameObject tiro;

	void Start (){
		backup_fireRate = fireRate;
	}

	void FixedUpdate () {
		if (Time.time < timerChurras) {
			if (churraqueira == true) {
				fireRate = 0.05f;
			}
		} else { 
			fireRate = backup_fireRate;
		}

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (tiro, tiroSpaw.position, tiroSpaw.rotation);
		}
		if (transform.position.x >= -3.2) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Translate (-speed, 0, 0);
			}
		}
		if (transform.position.x <= 3.2) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Translate (+speed, 0, 0);
			}
		}
		if (transform.position.y <= 4.2) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Translate (0, +speed, 0);
			}
		}
		if (transform.position.y  >= -4.2) {
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Translate (0, -speed, 0);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D testeColisao){
		if (testeColisao.gameObject.tag != "Coca") {
			GameOver ();
		}
	}

	void GameOver (){
		Destroy (this.gameObject);
		SceneManager.LoadScene (2);
	}
}
