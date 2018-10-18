using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnairePrefabs : MonoBehaviour
{
    public static GameObject PrefabProjectile { get; private set; }
    public static GameObject PrefabCanon { get; private set; }

    void Awake()
    {
        PrefabProjectile = Resources.Load<GameObject>("Prefabs/Projectile");
        PrefabCanon = Resources.Load<GameObject>("Prefabs/Canon");
    }
}
