﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]
    private float cooldown = 5f;
    [SerializeField]
    private GameObject projectile;
    private Animator anim;
    private GameObject projectilesParent;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        Invoke("FireAnimation", cooldown);
        projectilesParent = GameObject.Find("Projectiles");
        if (!projectilesParent)
        {
            projectilesParent = new GameObject("Projectiles");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //method to fire off projectile.
    public void FireProjectile ()
    {
        GameObject obj = Instantiate(projectile);
        obj.SetActive(true);
        obj.transform.SetParent(projectilesParent.transform);
        obj.transform.position = this.transform.position;
    }

    //method to fire off the animation for shooting. This then calls the fire projectile method.
    private void FireAnimation ()
    {
        anim.SetBool("isAttacking", true);
        Invoke("FireAnimation", cooldown);
    }

    private void ReturnToIdle ()
    {
        anim.SetBool("isAttacking", false);
    }
}
