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

    void Start()
    {
        rend = GetComponentsInChildren<Renderer>();
        rend[1].material.color = GetJoueurModele().Couleur;
        transform.position = GetJoueurModele().PositionLocale;
        joueurModele.OnCouleurChangée += (s, e) => rend[1].material.color = GetJoueurModele().Couleur;
        joueurModele.OnPositionChangée += (s, e) => transform.position = GetJoueurModele().PositionLocale;
    }
    void Update()
    {
        SetIntrantsManette(GetJoueurModele().RetournerIntrantManette());
        var déplacement = new Vector2(Input.GetAxis(GetIntrantsManette()[0]), Input.GetAxis(GetIntrantsManette()[1]));
        GetJoueurModele().Déplacer(ref déplacement);
    }
}
