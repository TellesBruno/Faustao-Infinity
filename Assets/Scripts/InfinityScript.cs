using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityScript : MonoBehaviour {

	public PlayerScript _player;

	public GameObject churrasAudio;

	public float gemsSpeed;
	public float duracao;

	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript>();
	}

	void FixedUpdate () {
		transform.Translate (0, gemsSpeed, 0);
	}

	void OnTriggerEnter2D (Collider2D _var){
		if (_var.gameObject.tag == "Player") {
			_player.timerChurras = Time.time + duracao;
			_player.churraqueira = true;
			Instantiate (churrasAudio, new Vector2 (0, 0), Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
