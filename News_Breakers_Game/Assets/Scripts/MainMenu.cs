using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int scene = PlayerMovement.curScene;
    public int cur;
    void Start(){
    cur = scene;
    }
    public void PlayB ()
    {
        if (scene == 0) {
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(scene);
        }
    }

    public void Quit () 
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
