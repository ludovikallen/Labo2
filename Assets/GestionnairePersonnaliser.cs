using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class GestionnairePersonnaliser : MonoBehaviour
{
    
    public static float sizeX = 2f, sizeY = 2f, sizeZ = 2f;
    public float augmentation = 0.01f;
    public float speed = 25.0f;
    public Dropdown DdlCouleur;
    GameObject cube;
    readonly Color[] Couleurs = new Color[] {Color.blue, Color.cyan, Color.yellow, Color.magenta, Color.black, Color.white };
 
    List<string> LstNomCouleur = new List<string>()
        {
        "Crying Blue",
        "Baby Blue",
        "Insecure Orange",
        "Overconfident Pink",
        "Classic Black",
        "Classic White"
         };


    void Start()
    {
        InitializerDropdown();
        InitializerCube();
        InitializerListener();
    }
    public void  InitializerCube()
    {
        cube = GénérerCube();
        cube.AddComponent<ControleurCouleur>();
        cube.transform.localScale += new Vector3(sizeX, sizeY, sizeZ);
        var couleurActuelle = Joueur.Joueur1.Couleur;
        cube.GetComponent<ControleurCouleur>().ChangerCouleur(couleurActuelle);
        var indexCouleur = Array.IndexOf(Couleurs, couleurActuelle);
        DdlCouleur.value = indexCouleur; 
        ChangerCouleurAvecParent();
    }
    public void ChangerCouleurAvecParent()
    {
        var couleurparent = cube.GetComponent<Renderer>().material.color; // get its color
        var child = cube.GetComponentsInChildren<Renderer>();
        child[1].material.color = couleurparent;
        Joueur.Joueur1.ChangerCouleur(ref couleurparent);
       // foreach (var child in cube.GetComponentsInChildren<Renderer>())
        // child.material.color = couleurparent;
    }
    public GameObject GénérerCube()
    {
        GameObject nouveauCube = Instantiate(Resources.Load<GameObject>("Joueur"));
        nouveauCube.transform.position = GenererVecteur();
        return nouveauCube;
    }
    public void InitializerDropdown()
    {
        if (DdlCouleur != null)
            DdlCouleur.AddOptions(LstNomCouleur);
    }
    static Vector3 GenererVecteur()
    {
        return new Vector3(0, 2, 0);
    }
    private void InitializerListener()
    {
        DdlCouleur?.onValueChanged.AddListener(Index => ModifierCouleur(Index));
    }
    private void Changercouleur(ref Color nouvelleCouleur)
    {
        cube.GetComponent<ControleurCouleur>().ChangerCouleur(nouvelleCouleur);
        ChangerCouleurAvecParent();
    }
    private void ModifierCouleur(int index)
    {
        var nouvellecouleur = Couleurs[index];
        Changercouleur(ref nouvellecouleur);
    }
    void Update()
    {
        cube.transform.Rotate(0.0f, Input.GetAxis("Horizontal1") * speed, 0.0f);

        //bonus!
        cube.transform.Rotate(Input.GetAxis("Vertical1") * speed, 0.0f, 0.0f);
        
        if (Input.GetKey(KeyCode.Z) && cube.transform.localScale.x <= sizeX * 2)
            cube.transform.localScale += new Vector3(augmentation, augmentation, augmentation);
        if (Input.GetKey(KeyCode.X) && cube.transform.localScale.x >= 0.10f)
            cube.transform.localScale += new Vector3(-augmentation, -augmentation, -augmentation);
        //bonus


    }
}
