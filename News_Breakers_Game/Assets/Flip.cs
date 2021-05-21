using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Flip : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01) {
            transform.localScale = new Vector3(-20f,20f,0f);
        } else if (aiPath.desiredVelocity.x <= -0.01) {
            transform.localScale = new Vector3(20f,20f,0f);
        }
    }
}
