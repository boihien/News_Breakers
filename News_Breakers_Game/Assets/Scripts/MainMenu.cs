using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int scene = PlayerMovement.curScene;
    public void PlayB ()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit () 
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
