using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class ControleJoueur: MonoBehaviour
{
	private const float vitesse = 10;
	
	private Transform solide;
	private float periode;
	
	
    void Start ()
    {
        this. solide = transform;
    }
	
	void Update ()
    {
		this. periode = Time. deltaTime;
		
        if
		(
			Input. GetKey (KeyCode. UpArrow)
			&& this. solide. position. z < 35
		)
		{
			this. deplacer (Vector3. forward);
		}
        if
		(
			Input. GetKey (KeyCode. LeftArrow)
			&& this. solide. position. x > -25
		)
		{
			this. deplacer (Vector3. left);
		}
        if
		(
			Input. GetKey (KeyCode. DownArrow)
			&& this. solide. position. z > -15
		)
		{
			this. deplacer (Vector3. back);
		}
        if
		(
			Input. GetKey (KeyCode. RightArrow)
			&& this. solide. position. x < 25
		)
		{
			this. deplacer (Vector3. right);
		}
    }
	
	
	private void deplacer (Vector3 direction)
	{
		Vector3 deplacement = direction * ControleJoueur. vitesse * this. periode;
		this. solide. Translate (deplacement, Space. World);
	}
}
