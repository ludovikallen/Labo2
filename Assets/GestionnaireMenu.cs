using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionnaireMenu : MonoBehaviour
{
    void Start()
    {
        Button[] tabButton = GetComponentsInChildren<Button>();

        for (int i = 0; i < tabButton.Length; i++)
        {
            int i2 = i;
            tabButton[i2].onClick.AddListener(() => SceneManager.LoadScene(i2 + 1));
        }
        
    }
}
	
