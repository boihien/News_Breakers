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
    
    public Animator hero;
    public GameObject player;
    public PlayerMovement test;
    
    public Slider healthBar;
    public Color Low;
    public Color High;
    
    private Vector3 startPos;
    private float enemyHit = 5f;
    private float letterHit = 4f;
    public float curHealth;
    public float maxHealth = 20f;
    
    void Start() {
        curHealth = maxHealth;
        healthBar.value = maxHealth;
        test = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    
    void Awake() {

        startPos = player.transform.position;
    }
    
    void Update() {
        SetHealth();
        
        if (health > numOfHearts) {
            health = numOfHearts;
        }
        
        if (curHealth == 0) {
            numOfHearts--;
            dead();
            curHealth = maxHealth;
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
    
    public void SetHealth()
    {
        healthBar.value = curHealth/maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other) {
    
        if (other.transform.tag == "Trap") {
            //StartCoroutine(test.Knockback(0.01f, 250, player.transform.position));
            dead();
        }
        
        if (other.transform.tag == "Enemy") {
            damaged();
            curHealth -= enemyHit;
        }
        
        if (other.transform.tag == "Letter") {
            damaged();
            curHealth -= letterHit;
        }
    }
    
    void dead()
    {
        hero.SetTrigger("Hurt");
        StartCoroutine(ExampleCoroutine());
        player.transform.position = startPos;
    }
    
    void damaged()
    {
        hero.SetTrigger("Damaged");
    }
    
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
    }

}
