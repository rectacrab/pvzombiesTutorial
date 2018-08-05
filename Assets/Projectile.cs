using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float movementSpeed = 1f;
    [SerializeField]
    private float Damage = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveProjectile();
	}

    //method to move the projectile.
    private void MoveProjectile ()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //test for enemies, otherwise do nothing.
        Attacker ene = collision.GetComponent<Attacker>();
        if (ene)
        {
            ene.TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
