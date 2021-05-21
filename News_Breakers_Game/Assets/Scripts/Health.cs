using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    public GameObject player;
    public PlayerMovement test;
    
    private Vector3 startPos;

    void Start() {
        test = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    
    void Awake() {

        startPos = player.transform.position;
    }
    
    void Update() {

        if (health > numOfHearts) {
            health = numOfHearts;
        }
        
        if (health <= 0f) {
            SceneManager.LoadScene(0);
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Trap") {
            numOfHearts--;
            //StartCoroutine(test.Knockback(0.01f, 250, player.transform.position));
            player.transform.position = startPos;
        }
        
        if (other.transform.tag == "Enemy") {
            numOfHearts--;
        }
        
        if (other.transform.tag == "Death") {
            numOfHearts--;
            player.transform.position = startPos;
        }
    }


}
