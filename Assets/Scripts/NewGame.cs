using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	void FixedUpdate (){
		if (Input.GetKey (KeyCode.R)) { 
			SceneManager.LoadScene (1);
		}
	}
}
