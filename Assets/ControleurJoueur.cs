using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurJoueur : MonoBehaviour
{
    public Joueur joueurModele;

    public Joueur JoueurModele
    {
        get => joueurModele;
        set
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
    }

    private string[] intrantsManette;

    private string[] IntrantsManette
    {
        get => intrantsManette;
        set
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
    }

    Renderer[] rend = new Renderer[] { };

    void Start()
    {
        //
        if (joueurModele != null)
        {
            GetComponentInChildren<ControleurCouleur>().ChangerCouleur(joueurModele.Couleur);
            //

            transform.position = JoueurModele.PositionLocale;

            Instantiate(GestionnairePrefabs.PrefabCanon, transform.position, Quaternion.identity, transform);

            joueurModele.OnCouleurChangée += (s, e) => GetComponentInChildren<ControleurCouleur>().ChangerCouleur(joueurModele.Couleur); ;
            joueurModele.OnPositionChangée += (s, e) => transform.position = JoueurModele.PositionLocale;
        }

    }
    void Update()
    {
        if (joueurModele != null)
        {
            IntrantsManette = JoueurModele.RetournerIntrantManette();
            var déplacement = new Vector2(Input.GetAxis(IntrantsManette[0]), Input.GetAxis(IntrantsManette[1]));
            JoueurModele.Déplacer(ref déplacement);
        }

    }
}
