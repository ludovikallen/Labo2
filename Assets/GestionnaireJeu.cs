using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionnaireJeu : MonoBehaviour
{
    private GameObject joueur1;
    private GameObject joueur2;


    void Awake()
    {
        joueur1 = Instantiate(Resources.Load<GameObject>("Prefabs/Joueur"));
        joueur2 = Instantiate(Resources.Load<GameObject>("Prefabs/Joueur"));

        joueur1.GetComponent<ControleurJoueur>().JoueurModele = Joueur.Joueur1;
        joueur2.GetComponent<ControleurJoueur>().JoueurModele = Joueur.Joueur2;
    }

    void Update()
    {

    }
}
