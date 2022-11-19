using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {

        //SceneManager.LoadScene();

    }

    public void Exit()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}
