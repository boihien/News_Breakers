using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float height;
    public float maxHigh;
    public float maxLow;
    public bool up;
    public bool down;
    public float xcoord;
    
    // Update is called once per frame
    void Start()
    {
        height = transform.position.y;
        xcoord = transform.position.x;
        maxHigh = height + 10f;
        maxLow = height - 10f;
        up = true;
        down = false;
    }
    void Update()
    {
        if (height == maxHigh) {
            down = true;
            up = false;
        } else if (height == maxLow) {
            down = false;
            up = true;
        }
        
        Animate();
    }
    
    private void Animate()
    {
        if (up) {
            height += .5f;
        } else if (down) {
            height -= .5f;
        }
        
        transform.position = new Vector3(xcoord,height,0f);
    }
}
