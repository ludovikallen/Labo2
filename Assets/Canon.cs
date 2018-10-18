using System;
using UnityEngine;

public class CanonTirerEventArgs : EventArgs
{
    public Projectile ProjectileTirer { get; private set; }
    public CanonTirerEventArgs(Projectile projectile)
    {
        ProjectileTirer = projectile;
    }
}

public class Canon 
{
    const float VitesseProjectileTiré = .5f;

    public event EventHandler<CanonTirerEventArgs> OnTirer;

    Joueur Propriétaire { get; set; }
    public Canon(Transform positionDeTire, Joueur propriétaire)
    {
        PositionDeTire = positionDeTire;
        Propriétaire = propriétaire;
        Propriétaire.Canon = this;
    }

    public Transform PositionDeTire { get; set; }
    public void Tirer(ref Vector2 direction)
    {
      OnTirer?.Invoke(this, new CanonTirerEventArgs(new Projectile(PositionDeTire.position, VitesseProjectileTiré, direction, Propriétaire.Couleur)));
    }
}

