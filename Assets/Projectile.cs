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
        Vitesse = vitesse;
        Direction = direction;
        Couleur = couleur;
        PositionLocale = position;
    }

    public void MettreÀJour(Transform transform)
    {
        if (Direction.x == 0 && Direction.y == 0)
        {
            transform.position += new Vector3(0.7f * Vitesse, 0, 0);
        }
        else
        {
            transform.position += new Vector3(Direction.x * Vitesse, Direction.y * Vitesse, 0);
        }

    }
}
