using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float movementSpeed = 1f;

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

}
