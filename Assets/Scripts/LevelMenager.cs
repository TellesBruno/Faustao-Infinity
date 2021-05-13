using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenager : MonoBehaviour {

	public GameObject sergio;
	public GameObject gilberto;

	public int sergios;
	public int sergiosHorda;
	public int metaMalandro;

	private float nextMalandro;
	public float spawDeley;

	public bool boss;

	public GameObject[] sergiosNaTela;

	void Start (){
	}

	void FixedUpdate () {
		if (boss == false) {
			CriaSergios ();
		}
		if (metaMalandro == sergiosHorda) {
			CriaBarros ();
		}
	}

	void CriaSergios(){
		sergiosNaTela = GameObject.FindGameObjectsWithTag ("Malandro");

		if ((sergiosNaTela.Length < sergios)&&(sergiosHorda>=metaMalandro)) {
			nextMalandro = Time.time + spawDeley;
			Instantiate (sergio, new Vector3 (Random.Range (-3, 3), 5, 0), Quaternion.identity);
			metaMalandro++;
		}
	}
	void CriaBarros(){
		Instantiate (gilberto, new Vector3 (0f, 3.22f, 0f), Quaternion.identity);
		metaMalandro = 0;
		sergiosHorda += 10;
		sergios += 1;
		boss = true;
	}
}
