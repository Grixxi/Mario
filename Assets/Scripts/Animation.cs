using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation: MonoBehaviour {
    private Animator anim;
    //public float playerSpeed;
    void Start () {
        anim = GetComponent<Animator>();
        //GameObject Player = GameObject.Find("Player");
        //PlayerController playerController = Player.GetComponent<PlayerController>();
        //playerSpeed = playerController.moveHorizontal;
        //.SetBool("isRunning", false);
    }
	
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow ) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isRunning", true);
        }
        else anim.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isJumping", true);
        }
        else anim.SetBool("isJumping", false);

    }
}
