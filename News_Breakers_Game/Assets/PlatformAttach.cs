using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Animator myAnimationController;
    public void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
            myAnimationController.SetBool("PlayerCollision", true);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = null;
            myAnimationController.SetBool("PlayerCollision", false);
        }
    }
}
