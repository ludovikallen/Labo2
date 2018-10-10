using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
    public class Joueur
{
    public static readonly Joueur Joueur1 = new Joueur(Color.blue, "Horizontal1", "Vertical1");
    public static readonly Joueur Joueur2 = new Joueur(Color.red, "Horizontal2", "Vertical2");
    public event EventHandler OnPositionChangée;
    public event EventHandler OnCouleurChangée;
    public Color Couleur { get; private set; }
    public Vector2 PositionLocale { get; private set; } = new Vector2(UnityEngine.Random.Range(2, 3), 0);

    public string[] InstrantsManette =  new string[2];


    private Joueur(Color couleur, string intrantX, string intrantY)
    {
        ChangerCouleur(ref couleur);
        AjouterIntrantsManette(intrantX,intrantY);
    }
    public void Déplacer(ref Vector2 déplacement)
    {
        PositionLocale += déplacement;
    }
    public void ChangerCouleur(ref Color couleur)
    {
        Couleur = couleur;
    }
    public void AjouterIntrantsManette(string intrantX, string intrantY)
    {
        InstrantsManette[0] = intrantX;
        InstrantsManette[1] = intrantY;
    }

    public string[] RetournerIntrantManette()
    {
        return InstrantsManette;
    }

}
