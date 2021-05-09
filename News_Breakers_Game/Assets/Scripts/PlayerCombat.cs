using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Attack();
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

}
