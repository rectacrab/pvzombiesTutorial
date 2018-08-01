using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //destroy projecticles that touch you.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
        }
    }
}
