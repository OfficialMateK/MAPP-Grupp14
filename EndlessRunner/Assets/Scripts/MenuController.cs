using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

	public Text coinText;


	public void Start()
	{
		coinText.text = "Coins:" + PlayerPrefs.GetInt("coins");
	}

	public void StartGame()
	{

		SceneManager.LoadScene(1);

	}

    public void MainMenu()
    {

        SceneManager.LoadScene(0);

    }

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();


	}

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}
