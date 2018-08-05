using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    private StarInventory starInv;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //something is attacking.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Something is attacking: " + name);
    }

    //Add stars from harvester.
    public void SpawnStars (int Amount)
    {
        if (!starInv)
        {
            starInv = GameObject.FindObjectOfType<StarInventory>();
        }

        starInv.AddStars(Amount);
    }
}
