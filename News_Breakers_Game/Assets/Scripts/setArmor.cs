using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setArmor : MonoBehaviour
{

    public Animator isArmored;
    
    // Start is called before the first frame update
    void Start()
    {
        isArmored.SetBool("Armored",true);
    }

   
}
