using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionnaireRetourMenu : MonoBehaviour {

	void Start () {
		GetComponentInChildren<Button>().onClick.AddListener(() => SceneManager.LoadScene(0));
	}
	
}
