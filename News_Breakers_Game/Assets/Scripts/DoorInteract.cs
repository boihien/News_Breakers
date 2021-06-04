using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    public Animator player;
    public static int nextScene = 2;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("up") && player.GetBool("Armored"))
        {
                
                SceneManager.LoadScene("Loading");
        }
    
    }
}
