using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip armPunch;

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public ScoreScript playerScore;
    
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    
    public float score = 0f;

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        if (Time.time > nextAttackTime) //attack cooldown
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Attack();
                nextAttackTime = Time.time + attackRate; //attack cooldown
            }
        }
    }

    public void PlayArmSwing()
    {
        audioSource.clip = armPunch;
        audioSource.Play();
    }

    void Attack()
    {
        //PLay an attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange); //creates circle with radius and collects all objects that the circle hits
        
        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Enemy") {
                enemy.GetComponent<EnemyMovement>().TakeDamage(attackDamage);
                playerScore.scoreValue += 500;
            } else if (enemy.gameObject.tag == "Boss") {
                enemy.GetComponent<shootAI>().TakeDamage(attackDamage);
            }
        }
        
    }

    //DELETE AFTER FINAL PROJECT IS DONE
    //draws circle to see the attack range
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
}
