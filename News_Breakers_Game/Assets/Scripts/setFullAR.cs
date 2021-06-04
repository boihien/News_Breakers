using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFullAR : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Animator player;
    void Start()
    {
        player.SetBool("Armored2", true);
        player.SetBool("Armored", false);
    }

}
