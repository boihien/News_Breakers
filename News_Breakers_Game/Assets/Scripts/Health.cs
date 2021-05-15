using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    public GameObject player;
    
    private Vector3 startPos;
    
    void Awake() {
        startPos = player.transform.position;
    }
    
    void Update() {

        if (health > numOfHearts) {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;

            }
            else {
                hearts[i].enabled = false;
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Death") {
            numOfHearts--;
            //Application.LoadLevel(Application.loadedLevel);
            player.transform.position = startPos;
        }
    }
}
