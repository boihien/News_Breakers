using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float height;
    private float maxHigh;
    private float maxLow;
    private bool dir;
    private float bounceSpeed;
    
    // Update is called once per frame
    void Start()
    {
        bounceSpeed = 30f;
        height = transform.position.y;
        maxHigh = height + 10f;
        maxLow = height - 10f;
        dir = true; //true = up, false = down
    }
    void Update()
    {
        if (height >= maxHigh) {
            dir = false;
        } else if (height <= maxLow) {
            dir = true;
        }
        
        Animate();
    }
    
    private void Animate()
    {
        if (dir) {
            height += bounceSpeed * Time.deltaTime;
        } else {
            height -= bounceSpeed * Time.deltaTime;
        }
        
        transform.position = new Vector3(transform.position.x,height,0f);
    }
}
