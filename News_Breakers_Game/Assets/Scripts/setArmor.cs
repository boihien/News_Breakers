using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setArmor : MonoBehaviour
{

    public Animator isArmored;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isArmored.SetBool("Armored",true);
        //player = GameObject.FindWithTag("Player");
        //player.transform.position = (gameObject.transform.position);
    }

   
}
