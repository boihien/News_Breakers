using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 20f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time > nextAttackTime) //attack cooldown
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Attack();
                //nextAttackTime = Time.time + attackRate; //attack cooldown
                StartCoroutine(TimerRoutine());
            }
        }*/
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            Attack();
            //nextAttackTime = Time.time + attackRate; //attack cooldown
            StartCoroutine(TimerRoutine());
        }
    }

    void Attack()
    {
        //PLay an attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); //creates circle with radius and collects all objects that the circle hits
        
        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBehavior>().TakeHit(attackDamage);
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
    
    private IEnumerator TimerRoutine()
    {
      //code can be executed anywhere here before this next statement
      yield return new WaitForSeconds(10); //code pauses for 5 seconds
     //code resumes after the 5 seconds and exits if there is nothing else to run
 
    }

}
