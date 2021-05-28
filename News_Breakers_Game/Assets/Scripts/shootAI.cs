using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAI : MonoBehaviour
{
    public Transform target;
    
    private int lettersSize = 4;
    public GameObject[] letters;
    
    public Animator enemy;
    
    public GameObject armor;
    
    public AudioSource shootSound;
    public AudioSource deathSound;
    
    public float fireRate; //Fire every 2.5 seconds
    public float shootingPower; //force of projection
 
    private float shootingTime;
    private int curLetter;
    
    public float dist;
    public float maxDist;
    public int health;
    
    private void Start()
    {
        curLetter = -1;
    }
 
    private void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        if (dist < maxDist) {
            Fire(); //Constantly fire
        }
    }
 
    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            if (curLetter > (lettersSize-1)) {
                curLetter = 0;
            } else {
                curLetter++;
            }
            shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y); //our curr position is where our muzzle points
            GameObject projectile = Instantiate(letters[curLetter], myPos, Quaternion.identity); //create our bullet
            Vector2 direction = -(myPos - (Vector2)target.position); //get the direction to the target
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower * Time.deltaTime; //shoot the bullet
            shootSound.Play(0);
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
 
        if (health <= 0)
        {
            deathSound.Play(0);
            Die();
        }
    }
 
    void Die()
    {
        enemy.SetTrigger("Dead");
        StartCoroutine(ExampleCoroutine());
        Instantiate(armor, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
    }
}
