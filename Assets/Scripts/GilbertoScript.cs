using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GilbertoScript : MonoBehaviour {

	public bool dir;
	public bool esq;

	public float speed;
	public float nextFire;
	public float fireRate;

	public int nTiros;
	public int nTirosMax;
	public int gilbertoHP;

	public Transform burgmanSpaw;
	public GameObject burgman;
	public GameObject putavida;
	public GameObject gems;
	public LevelMenager _lmSergioSpaw;

	public AudioSource kacinao;
	public AudioSource bsuzuk;

	void Start () {
		nTiros = 0;
		gilbertoHP = 10;
		_lmSergioSpaw = GameObject.FindGameObjectWithTag ("Controlador").GetComponent<LevelMenager>();
		kacinao.Play ();
	}

	void FixedUpdate () {
		if (gilbertoHP == 0) {
			_lmSergioSpaw.boss = false;
			Instantiate (putavida, new Vector2 (0,0), Quaternion.identity);
			Instantiate (gems, burgmanSpaw.position, burgmanSpaw.rotation);
			Destroy (this.gameObject);
		} else {
			if (nTiros <= nTirosMax) {
				SpawShot1 ();
			} else {
				SpawShot2 ();
			}
			if (dir == true) {
				transform.Translate (+speed, 0, 0);
			}
			if (esq == true) {
				transform.Translate (-speed, 0, 0);
			}
			if (transform.position.x >= 2.5) {
				dir = false;
				esq = true;
			}
			if (transform.position.x <= -2.5) {
				dir = true;
				esq = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D colisaoTiro){
		if (colisaoTiro.gameObject.tag == "Coca") {
			Destroy (colisaoTiro.gameObject);
			gilbertoHP--;
		}
	}

	void SpawShot1 (){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate; 
			Instantiate (burgman, new Vector3 (burgmanSpaw.position.x-1,burgmanSpaw.position.y,0 ), Quaternion.AngleAxis(45, Vector3.back )); // angulo -45
			Instantiate (burgman, burgmanSpaw.position, burgmanSpaw.rotation);// angulo 0
			Instantiate (burgman, new Vector3 (burgmanSpaw.position.x+1,burgmanSpaw.position.y,0 ), Quaternion.AngleAxis(45, Vector3.forward ));// angulo +45
			nTiros++;
		}
	}

	void SpawShot2 (){
		if (Time.time > nextFire) {
			bsuzuk.Play ();
			nextFire = Time.time + fireRate; 
			Instantiate (burgman, new Vector3 (burgmanSpaw.position.x-2,burgmanSpaw.position.y,0 ), Quaternion.AngleAxis(45, Vector3.back )); // angulo -45
			Instantiate (burgman, new Vector3 (burgmanSpaw.position.x-1,burgmanSpaw.position.y,0 ), Quaternion.AngleAxis(25, Vector3.back )); // angulo -25
			Instantiate (burgman, burgmanSpaw.position, burgmanSpaw.rotation);// angulo 0
			Instantiate (burgman, new Vector3 (burgmanSpaw.position.x+1,burgmanSpaw.position.y,0 ), Quaternion.AngleAxis(25, Vector3.forward ));// angulo +25
			Instantiate (burgman, new Vector3 (burgmanSpaw.position.x+2,burgmanSpaw.position.y,0 ), Quaternion.AngleAxis(45, Vector3.forward ));// angulo +45
			nTiros = 0;
		}
	}
}
