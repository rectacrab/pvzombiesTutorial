using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    private float MaxHealth;
    private float CurrentHealth;

	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //take some damage.
    public void TakeDamage (float damageTaken)
    {
        CurrentHealth -= damageTaken;
        if (CurrentHealth <=0)
        {
            KillYourself();
        }
    }

    //Start destruction process.
    private void KillYourself ()
    {
        DestroyObject();
    }

    //actually destroy object.
    private void DestroyObject ()
    {
        Destroy(this.gameObject);
    }
}
