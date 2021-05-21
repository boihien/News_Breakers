using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{


    public float loadTime = 300f;
    public float curTime;
    private int nextScene;
    // Start is called before the first frame update
    void Start()
    {
        nextScene = DoorInteract.nextScene;
        curTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += 1f;
        
        if (curTime == loadTime) {
            SceneManager.LoadScene(nextScene);
        }
    }
}
