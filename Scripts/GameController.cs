using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public GameObject gameOver;
    public GameObject stopPainel;
    public GameObject nextLevel;

    public GameObject menuPainel;
    public GameObject anotherPainel;
    public GameObject aboutPainel;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
    //stop
    public void ShowStopPainel()
    {
        stopPainel.SetActive(true);
    }
    //restart
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    public void Reiniciar(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void ShowMenuPainel()
    {
        menuPainel.SetActive(true);
        anotherPainel.SetActive(false);
        aboutPainel.SetActive(false);
    }
    public void ShowAnotherPainel()
    {
        anotherPainel.SetActive(true);
        menuPainel.SetActive(false);
        // ShowMenuPainel();
        // bool painelActivo = anotherPainel.SetActive(true);
        // if(painelActivo)
        // {
        //     ShowMenuPainel();
        //     // menuPainel.SetActive(false);
        // }
    }
    public void ShowAboutPainel()
    {
        aboutPainel.SetActive(true);
        menuPainel.SetActive(false);
        // ShowMenuPainel();
    }

    //new level
    // public void ShowNextLevel()
    // {
    //     nextLevel.SetActive(true);
    // }
    // public void Continuar(string lvlName)
    // {
    //     SceneManager.LoadScene(lvlName);
    // }
}
