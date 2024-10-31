using System. Collections;
using System. Collections. Generic;
using System. Linq;
using UnityEngine;


public class Deplacement: MonoBehaviour
{
	private const float vitesse = 30;
	
	private Transform
		lanceur,
		depart,
		prefab
	;
	private List <Transform> projectiles;
	private float periode;
	private bool jete = false;
	
	
    void Start ()
    {
		this. lanceur = transform. Find ("humains"). Find ("joueur");
		this. prefab  = transform. Find ("prefabriques").  Find ("projectile");
		this. projectiles = new List <Transform> ();
        this. projectiles. Add (Deplacement. cloner (ref this. prefab));
		this. projectiles [0]. SetParent (this. lanceur);
    }
	
	void Update ()
    {
		this. periode = Time. deltaTime;
		
		if (jete)
		{
			this. deplacer (Vector3. forward);
		}
		else if (Input. GetKey (KeyCode. Space))
		{
			jete = true;
			
			this. depart = new GameObject ("depart"). GetComponent <Transform> ();
			Deplacement. copier (ref this. lanceur, ref this. depart);
			this. depart. SetParent (transform);
			this. projectiles. Last (). SetParent (transform);
			this. projectiles. Add (Deplacement. cloner (ref this. prefab));
		}
    }
	
	
	private void deplacer (Vector3 direction)
	{
		Transform projectile;
		Vector3 deplacement = direction * Deplacement. vitesse * this. periode;
		
		for (int indice = 0; indice < this. projectiles. Count - 1; indice ++)
		{
			projectile = this. projectiles [indice];
			projectile. Translate (deplacement, this. depart);
		}
	}
	
	
	public static void copier (ref Transform original, ref Transform copie)
	{
		copie. position = original. position;
		copie. eulerAngles = original. eulerAngles;
	}
	
	public static Transform cloner (ref Transform original)
	{
        Transform clone = Instantiate (original);
		Deplacement. copier (ref original, ref clone);
		clone. gameObject. SetActive (true);
		
		return clone;
	}
}
