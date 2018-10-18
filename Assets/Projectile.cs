using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile
{
    const int FacteurDommage = 2;
    public event EventHandler OnPositionChangée;

    float Vitesse { get; set; }
    Vector2 Direction { get; set; }
    public float Dommage => Vitesse * FacteurDommage;
    public Color Couleur { get; private set; }

    Vector2 positionLocale;
    public Vector2 PositionLocale
    {
        get { return positionLocale; }
        private set
        {
            positionLocale = value;
            OnPositionChangée?.Invoke(this, EventArgs.Empty);
        }
    }

    public Projectile(Vector2 position, float vitesse, Vector2 direction,Color couleur)
    {
        //à compléter
    }

    public void MettreÀJour()
    {
        //boolshit
        PositionLocale += new Vector2(2, 2);//à compléter
    }
}
