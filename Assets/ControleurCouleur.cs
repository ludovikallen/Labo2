using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurCouleur : MonoBehaviour
{

    Material Matériel { get; set; }

    void Awake()
    {
       Matériel = GetComponent<MeshRenderer>().material;
    }

    public void ChangerCouleur(Color nouvelleCouleur)
    {
        Matériel.color = nouvelleCouleur;
    }
}