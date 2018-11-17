using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour 
{

    public GameObject DeadMenu;
    public GameObject Manager;

    private bool pontaCabeca;
    private bool speedUp;
    public float forcaPulo;
	public float velocidadeMovimento; //multiplicador para a velocidade
	public int pontos;

	public Text textoPontos;
    public Text pontosFinais;
	public bool estaChao;

	void Start () 
	{
        Time.timeScale = 1;
        estaChao = true;
		pontaCabeca = false;
        speedUp = false;
		textoPontos.text = pontos.ToString();
		forcaPulo = 200;
	}
	
	void Update () 
	{		
		/*Movimenta sozinho o personagem.*/
		transform.Translate(new Vector3(velocidadeMovimento * Time.deltaTime, 0, 0));
		GetComponent<Animator>().SetBool("andando",true);

		/*Próximas 4 linhas de código para aplicar um força no eixo 'y' (x = 0) para pular.*/
		if((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && estaChao == true)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcaPulo));
			GetComponent<AudioSource>().Play();
			if (pontaCabeca == false)
			{	
				GetComponent<SpriteRenderer>().flipY = true;
				GetComponent<Rigidbody2D>().gravityScale = -1;
				pontaCabeca = true;			
			}
			else if (pontaCabeca == true)
			{
				GetComponent<SpriteRenderer>().flipY = false;
				GetComponent<Rigidbody2D>().gravityScale = 2;
				pontaCabeca = false;
			}
			estaChao = false;
		}

        /*Modo de acelerar o jogo como um todo.*/
        /*Problema: ao pausar e voltar ao jogo, precisa receber o valor desta variavel
		  no timeScale do ManagerScript*/
        if (speedUp && pontos % 3 == 0)
        {
            Time.timeScale += 0.2f;
            speedUp = false;
        }
    }
	
	void OnCollisionEnter2D (Collision2D colisor2d)
	{
		if (colisor2d.gameObject.CompareTag ("Obstaculos"))
		{
			Time.timeScale = 0;
            pontosFinais.text = pontos.ToString();
            Manager.GetComponent<AudioSource>().Pause();
            DeadMenu.SetActive(true);
        }

		if (colisor2d.gameObject.CompareTag ("Plataformas"))
		{
			estaChao = true;
		}
		
	}

	private void OnTriggerEnter2D (Collider2D colisor2d)
	{
		if (colisor2d.gameObject.CompareTag ("Obstaculos"))
		{
			pontos++;
            speedUp = true;
			textoPontos.text = pontos.ToString();
		}
        
	}
	
}
