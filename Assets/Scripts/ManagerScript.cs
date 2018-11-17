using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

	public GameObject pauseBotao;
	public GameObject menu;
	public bool pausado = false;
	private float velocidade;
    private float savedSpeed;

	public float movimento = 1;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void Pause ()
	{
		if (pausado == false)
		{
			pauseBotao.SetActive (true);
			menu.SetActive (true);
            savedSpeed = Time.timeScale;
			Time.timeScale = 0;
			GetComponent<AudioSource>().Pause();
			pausado = true;
		}
	}

	public void Resume ()
	{
		if (pausado == true)
		{
			pauseBotao.SetActive (false);
			menu.SetActive (false);			
			GetComponent<AudioSource>().Play();
			Time.timeScale = savedSpeed;
			pausado = false;
		}
	}

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
