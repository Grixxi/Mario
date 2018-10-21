using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform hitBox;
    public float speed;
    public bool wallHit;
    public float hitBoxWidth;
    public float hitBoxHeight;
    public LayerMask isGround;
    int count;
	// Use this for initialization
	void Start () {
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        wallHit = Physics2D.OverlapBox(hitBox.position, new Vector2(hitBoxWidth, hitBoxHeight), 0, isGround);
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (wallHit == true && count >= 5)
        {
            speed = speed * -1;
            count = 0;
        }
        
        

    }
  
}
