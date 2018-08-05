using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]
    private GameObject projectile;
    private Animator anim;
    private GameObject projectilesParent;
    private EnemySpawnPoint spawnPoint;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        projectilesParent = GameObject.Find("Projectiles");
        if (!projectilesParent)
        {
            projectilesParent = new GameObject("Projectiles");
        }
        setLaneSpawner();
    }
	
	// Update is called once per frame
	void Update () {

        if (CheckIfEnemyInFront())
        {
            if (!anim.GetBool("isAttacking"))
            {
                FireAnimation();
            }
        }
        else
        {
            ReturnToIdle();
        }
	}

    //pick a spawner to target for enemy checks.
    private void setLaneSpawner ()
    {
        EnemySpawnPoint[] spawners = GameObject.FindObjectsOfType<EnemySpawnPoint>();

        foreach (EnemySpawnPoint point in spawners)
        {
            if (point.transform.position.y == this.transform.position.y)
            {
                spawnPoint = point;
                break;
            }
        }

        if (spawnPoint == null) { Debug.LogError("Spawn point cannot be found, this is outside of a lane."); }
        else { Debug.Log("Spawner discovered: " + spawnPoint.name); }
    }

    private bool CheckIfEnemyInFront ()
    {
        if (spawnPoint.transform.childCount < 1)
        {
            return false;
        }
        else
        {
            foreach(Transform child in spawnPoint.transform)
            {
                if (child.transform.position.x > this.transform.position.x)
                {
                    return true;
                }
            }
        }
        return false;
    }

    //method to fire off projectile, called by animation keyframes.
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
    }

    private void ReturnToIdle ()
    {
        anim.SetBool("isAttacking", false);
    }

    private bool CheckLaneForEnemy ()
    {
        bool enePresent = false;
        
        return enePresent;
    }
}
