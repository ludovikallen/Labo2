using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurProjectile : MonoBehaviour
{
    //Le modèle de projectile que cette instance de ContrôleurProjectile contrôle
    //À setter à l'extérieur de cette classe
    public Projectile ProjectileModèle { get; set; }
   
    void Start()
    {
        GetComponentInChildren<ControleurCouleur>().ChangerCouleur(ProjectileModèle.Couleur);
        Destroy(gameObject, 1);
    }

    void Update()
    {
        ProjectileModèle.MettreÀJour(transform);
    }
}
