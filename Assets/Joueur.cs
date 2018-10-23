using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur
{
    public static readonly Joueur Joueur1 = new Joueur(Color.blue, "Horizontal1", "Vertical1", "RHorizontal1", "RVertical1", "Shoot1");
    public static readonly Joueur Joueur2 = new Joueur(Color.red, "Horizontal2", "Vertical2", "RHorizontal2", "RVertical2", "Shoot2");
    public event EventHandler OnPositionChangée;
    public event EventHandler OnCouleurChangée;
    public Color couleur;
    public Vector2 positionLocale = new Vector2(UnityEngine.Random.Range(2, 3), 0);
    //cette propriété est une référence au modèle de canon qu’un modèle de joueur possède
    //quoi?
    public Canon  Canon { get; set; }
    public string[] InstrantsManette = new string[5];



    public Color Couleur
    {
        get { return couleur; }
        set
        {
            couleur = value;

            OnCouleurChangée?.Invoke(this, EventArgs.Empty);
        }
    }
    public Vector2 PositionLocale
    {
        get { return positionLocale; }
        set
        {
            positionLocale = value;

            OnPositionChangée?.Invoke(this, EventArgs.Empty);
        }
    }

    
    private Joueur(Color couleur, string intrantViserX, string intrantViserY, string intrantDeplacerX, string intrantDeplacerY, string intrantTirer)
    {
        ChangerCouleur(ref couleur);
        AjouterIntrantsManette(intrantViserX, intrantViserY, intrantDeplacerX, intrantDeplacerY, intrantTirer);
    }
    public void Déplacer(ref Vector2 déplacement)
    {
        PositionLocale += déplacement;
    }
    public void ChangerCouleur(ref Color couleurActuelle)
    {
        Couleur = couleurActuelle;
    }
    public void AjouterIntrantsManette(string intrantViserX, string intrantViserY, string intrantDeplacerX, string intrantDeplacerY, string intrantTirer)
    {
        InstrantsManette[0] = intrantViserX;
        InstrantsManette[1] = intrantViserY;
        InstrantsManette[2] = intrantDeplacerX;
        InstrantsManette[3] = intrantDeplacerY;
        InstrantsManette[4] = intrantTirer;
    }
    //ici qui a ete fait
    public void Attaquer(Vector2 direction)
    {
        Canon.Tirer(ref direction);
    }
    public ref string[] RetournerIntrantManette()
    {
        if (InstrantsManette.Length < 2)
            throw new ArgumentNullException();
        return ref InstrantsManette;
    }

}
