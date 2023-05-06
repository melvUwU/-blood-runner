using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene("CG");
        EndScene.endGame = false;
        GameOver.gameOver = false;
    }
    public void skipButton()
    {
        SceneManager.LoadScene("Tutorial");
        EndScene.endGame = false;
        GameOver.gameOver = false;
    }
    public void quitButton()
    {
        Application.Quit();

    }
    public void stageOne()
    {
        SceneManager.LoadScene("Scene01_city");
        EndScene.endGame = false;
        GameOver.gameOver = false;

    }
    public void stageTwo()
    {
        SceneManager.LoadScene("Scene2_1_thecity2");
        EndScene.endGame = false;
        GameOver.gameOver = false;
    }
    public void stageThree()
    {
        SceneManager.LoadScene("Scene_the_city3");
        EndScene.endGame = false;
        GameOver.gameOver = false;
    }
    public void backButton()
    {
        SceneManager.LoadScene("MainMenu");
        EndScene.endGame = false;
        GameOver.gameOver = false;
    }
    public void menuButton()
    {
        Debug.Log("press");
        SceneManager.LoadScene("Level");
        EndScene.endGame = false;
        GameOver.gameOver = false;
    }
    public void creditsButton()
    {
        Debug.Log("press");
        SceneManager.LoadScene("Credits");
        EndScene.endGame = false;
        GameOver.gameOver = false;
    }
}
