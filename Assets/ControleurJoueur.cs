using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurJoueur : MonoBehaviour
{
    private Joueur joueurModele;

    public Joueur GetJoueurModele()
    {
        return joueurModele;
    }

    public void SetJoueurModele(Joueur value)
    {
        try
        {
            joueurModele = value;
        }
        catch (Exception)
        {
            throw new ArgumentNullException("Ceci est null");
        }
    }

    private string[] intrantsManette;

    private string[] GetIntrantsManette()
    {
        return intrantsManette;
    }

    private void SetIntrantsManette(string[] value)
    {
        try
        {
            intrantsManette = value;
        }
        catch (Exception)
        {
            throw new ArgumentNullException("Ceci est null");
        }
    }

    Renderer[] rend = new Renderer[] { };
    void Start() => rend = GetComponentsInChildren<Renderer>();
    void Update()
    {
        rend[1].material.color = GetJoueurModele().Couleur;
        SetIntrantsManette(GetJoueurModele().RetournerIntrantManette());
        var déplacement = new Vector2(Input.GetAxis(GetIntrantsManette()[0]), Input.GetAxis(GetIntrantsManette()[1]));
        GetJoueurModele().Déplacer(ref déplacement);
        transform.position = GetJoueurModele().PositionLocale;
    }
}
