using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaScript : MonoBehaviour {
	/*Velocidade da Eva é aproximadamente 2x mais lenta que a do personagem.*/
	public float velocidade;
	//private bool flip = false;

	void Start () {
		//velocidade = 0.1f;
	}

	void Update () {
		/*Movimenta sozinho*/
		transform.Translate(new Vector3(velocidade * Time.deltaTime, 0, 0));
		/*if (flip == false) {
			GetComponent<SpriteRenderer>().flipY = true;
			flip = true;
		}
		else {
			GetComponent<SpriteRenderer>().flipY = false;
			flip = false;
		}*/
	}

	void OnCollisionEnter2D (Collision2D colisor2d)
	{
		if (colisor2d.gameObject.CompareTag ("Obstaculos"))
		{
			Debug.Log("COLIDIU!"+colisor2d.gameObject.tag);
		}
	}


}
