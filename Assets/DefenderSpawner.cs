using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefenderSpawner : MonoBehaviour {
    private GameObject defenderParent;
    private StarInventory starInv;

	// Use this for initialization
	void Start () {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
        starInv = GameObject.FindObjectOfType<StarInventory>();

    }

    private void OnMouseDown()
    {
        if (BuildMaster.buildingObject != null)
        {
            if (starInv.GetStarCount() >= BuildMaster.buildingCost)
            {
                GameObject newDef = Instantiate(BuildMaster.buildingObject, SnapToGrid(CalculateWorldPosition()), Quaternion.identity);
                newDef.transform.SetParent(defenderParent.transform);
                newDef.SetActive(true);
                starInv.SpendStars(BuildMaster.buildingCost);
            }
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
        float yVal = Mathf.FloorToInt(rawValue.y);
        Debug.Log("Raw Pos X: " + rawValue.x + ", rounded: " + xVal);
        Debug.Log("Raw Pos Y: " + rawValue.y + ", rounded: " + yVal);
        Vector3 newpos = new Vector3(xVal, yVal, 1);
        return newpos;
    }
}
