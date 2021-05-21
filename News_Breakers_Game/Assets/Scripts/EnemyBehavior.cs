using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 100;
    public HealthBarBehavior Healthbar;
    public EnemyBehavior enemy;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        //Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    // Update is called once per frame
    public void TakeHit(float damage) {
        Hitpoints -= damage;
        //StartCoroutine(test.Knockback(0.01f, 250, player.transform.position));

        if (Hitpoints <= 0) {
            Destroy(gameObject);
        }
    }

    void Destroy()
    {
        //Die animation

        Debug.Log("Enemy died!");
    }
}
