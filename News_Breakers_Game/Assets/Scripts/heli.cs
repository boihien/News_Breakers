using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heli : MonoBehaviour
{
    public Animator player;
    public static int nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay(Collider other) {
    
        if (other.CompareTag("Player") && Input.GetKey("up") && player.GetBool("Armored2"))
        {
                nextScene = 5;
                SceneManager.LoadScene("Loading");
        }
    }
}
