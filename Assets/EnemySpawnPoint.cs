using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {
    [SerializeField]
    private GameObject[] attackerPrefabs;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject atkr in attackerPrefabs)
        {
            if (isTimeToSpawn(atkr))
            {
                SpawnObject(atkr);
            }
        }
	}

    private bool isTimeToSpawn(GameObject targetObject)
    {
        bool isTime = false;
        Attacker atk = targetObject.GetComponent<Attacker>();
        float delay = 1 / atk.SpawnTime * Time.deltaTime /5 ;

        if (Random.value < delay) { isTime = true; }
        else { isTime = false; }
        return isTime;
    }

    private void SpawnObject (GameObject targetObject)
    {
        GameObject newObject = Instantiate(targetObject);
        newObject.transform.SetParent(this.transform);
        newObject.transform.position = this.transform.position;
    }
}
