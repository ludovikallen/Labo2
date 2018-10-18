using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurCanon : MonoBehaviour
{
    [SerializeField]
    Transform transformSortieProjectile;

    public Canon CanonModèle { get; private set;}

    void Awake()
    {
        //CanonModèle = new Canon(transformSortieProjectile, GetComponentInParent<ContrôleurJoueur>().JoueurModèle);

        CanonModèle.OnTirer += (s, e) => Instantiate(GestionnairePrefabs.PrefabProjectile, transformSortieProjectile.position, Quaternion.identity)
                                            .GetComponent<ControleurProjectile>().ProjectileModèle = e.ProjectileTirer;
    }
}
