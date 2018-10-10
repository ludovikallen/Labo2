using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionnaireJeu : MonoBehaviour
{ 
    void Awake()
    {
        GameObject.Find("Joueur1").GetComponent<ControleurJoueur>().SetJoueurModele(Joueur.Joueur1);
        GameObject.Find("Joueur2").GetComponent<ControleurJoueur>().SetJoueurModele(Joueur.Joueur2);
    }

    void Update()
    {
        
    }
}
