using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurCanon : MonoBehaviour
{
    [SerializeField]
    Transform pointdesortie;
    GameObject prefabprojectile { get; set; }
    void Start()
    {
        prefabprojectile = Resources.Load<GameObject>("Projectile");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 100 == 0)
        {
            var proj = Instantiate(prefabprojectile, pointdesortie.position, transform.rotation);
            proj.transform.localScale = new Vector3(.5f, .5f, .5f);
        }
    }
}
