using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefenderSpawner : MonoBehaviour {
    private GameObject defenderParent;
	// Use this for initialization
	void Start () {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }


    }

    private void OnMouseDown()
    {
        Debug.Log("mouse pos: " + SnapToGrid(CalculateWorldPosition()));
        if (BuildMaster.buildingObject != null)
        {
            GameObject newDef = Instantiate(BuildMaster.buildingObject, SnapToGrid(CalculateWorldPosition()), Quaternion.identity);
            newDef.transform.SetParent(defenderParent.transform);
            newDef.SetActive(true);
        }
    }

    private Vector2 CalculateWorldPosition ()
    {
        Vector2 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return worldpos;
    }

    private Vector3 SnapToGrid (Vector2 rawValue)
    {
        float xVal = Mathf.RoundToInt(rawValue.x);
        float yVal = Mathf.RoundToInt(rawValue.y);
        Vector3 newpos = new Vector3(xVal, yVal, 1);
        return newpos;
    }
}
