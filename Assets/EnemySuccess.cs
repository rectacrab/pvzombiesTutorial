using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //destroy projecticles that touch you.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            Debug.Log("OMG YOU'RE LOSING");
            Destroy(collision.gameObject);
        }
    }
}
