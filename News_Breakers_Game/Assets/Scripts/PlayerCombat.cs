using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public AudioSource armPunch;
    public AudioSource hitSound;

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public ScoreScript playerScore;
    
    public float attackRange;
    public int attackDamage;
    public float attackRate;
    float nextAttackTime = 0f;
    
    public float score = 0f;
    
    void Start(){
        playerScore = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextAttackTime) //attack cooldown
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                PlayArmSwing();
                Attack();
                nextAttackTime = Time.time + attackRate; //attack cooldown
            }
        }
        
        if (animator.GetBool("Armored2")) {
            attackRange = 50f;
            attackDamage = 4;
            attackRate = .25f;
        }
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
                hitSound.Play(0);
            } else if (enemy.gameObject.tag == "Boss") {
                enemy.GetComponent<shootAI>().TakeDamage(attackDamage);
                hitSound.Play(0);
            }
        }
        
    }
    
    public void PlayArmSwing()
    {
        armPunch.Play(0);
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
