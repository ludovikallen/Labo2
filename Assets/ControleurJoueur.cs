using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ControleurJoueur : MonoBehaviour
{
    public Joueur joueurModele;
    public GameObject canonModele;
    int frameDerniereBalle = 0;
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


    void Start()
    {
        //
        if (joueurModele != null)
        {
            GetComponentInChildren<ControleurCouleur>().ChangerCouleur(joueurModele.Couleur);
            //

            transform.position = JoueurModele.PositionLocale;

            canonModele = Instantiate(GestionnairePrefabs.PrefabCanon, transform.position, Quaternion.identity, transform);
            
            joueurModele.OnCouleurChangée += (s, e) => GetComponentInChildren<ControleurCouleur>().ChangerCouleur(joueurModele.Couleur);
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
            float composanteX = Input.GetAxis(IntrantsManette[2]);
            float composanteY = Input.GetAxis(IntrantsManette[3]);
            var tirer = Input.GetAxis(IntrantsManette[4]);
            float angleRadian = Mathf.Atan2(composanteY, composanteX);
            canonModele.transform.rotation = Quaternion.Euler(0, 0, angleRadian * Mathf.Rad2Deg - 90);
            if (tirer == 1)
            {
                if (Time.frameCount - 30 > frameDerniereBalle || frameDerniereBalle == 0)
                {
                    var direction = new Vector2(composanteX, composanteY);
                    joueurModele.Attaquer(direction);
                    frameDerniereBalle = Time.frameCount;
                }
            }
        }
    }
}
