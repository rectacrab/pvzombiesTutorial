using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [SerializeField]
    private float maxMovementSpeed = 5f;
    private float movementSpeed = 5f;
    private bool isMoving = true;
    private Animator anim;
    private GameObject strikeTarget = null;
    [SerializeField]
    private float Damage = 5f;
    [SerializeField]
    private float HP = 10f;

    private DamageController dmgControl;
    public float SpawnTime; //delay on spawning object.


    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        movementSpeed = maxMovementSpeed;
        dmgControl = GameObject.FindWithTag("DamageCanvas").GetComponent<DamageController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            MoveForward();
        }

        if (anim.GetBool("isAttacking"))
        {
            if (strikeTarget == null)
            {
                anim.SetBool("isAttacking", false);
                SetIsMoving(1);
            }
        }
	}

    //method to move forward.
    private void MoveForward ()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }

    //stop this thing from moving.
    public void SetIsMoving (int movingStatus)
    {   
        isMoving = movingStatus == 1;
    }

    //method to deal damage to 
    public void StrikeCurrentTarget ()
    {
        if (strikeTarget != null)
        {
            Health hp = strikeTarget.GetComponent<Health>();
            if (hp)
            {
                hp.TakeDamage(Damage);
                dmgControl.DisplayDamage(Damage, strikeTarget);
                Debug.Log("Dealing " + Damage + " to: " + strikeTarget.name);
            }
        }
    }

    //take damage from projectile script
    public void TakeDamage (float incomingDamage)
    {
        anim.SetTrigger("isHit");
        this.GetComponent<Health>().TakeDamage(incomingDamage);
    }

    //temporary speed boosts for this.
    public void SpeedBoost (float multiplier)
    {
        movementSpeed = maxMovementSpeed * multiplier;
    }

    //start attacking an object.
    public void StartAttack (GameObject otherObj)
    {
        anim.SetBool("isAttacking", true);
        strikeTarget = otherObj;
    }
}
