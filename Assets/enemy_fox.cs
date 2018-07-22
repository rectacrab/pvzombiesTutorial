using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fox : MonoBehaviour {
    private Animator anim;
    private Attacker attacker;


	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        attacker = this.GetComponent<Attacker>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //encounter enemy.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //projectile - this is handled on that object.
        if (!collision.gameObject.GetComponent<Defender>())
        {
            return;
        }
        
        //gravestone jump
        if (collision.gameObject.GetComponent<def_stone>())
        {
            anim.SetTrigger("isJumping");
        }
        else
        {
            attacker.StartAttack(collision.gameObject);
        }
    }

}
