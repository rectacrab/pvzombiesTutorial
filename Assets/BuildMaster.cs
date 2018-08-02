using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaster : MonoBehaviour {

    public static GameObject buildingObject;
    private BuildButton[] buttons = new BuildButton[4];

	// Use this for initialization
	void Start () {
		for (int p =0; p < buttons.Length; p++)
        {
            buttons[p] = transform.GetChild(p).GetComponent<BuildButton>();
            buttons[p].SetInactiveButton();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //set a button to be active using a current index.
    public void setCurrentActive (int index)
    {
        for (int p = 0; p < buttons.Length; p++)
        {
            if (p != index)
            {
                buttons[p].SetInactiveButton();
            }
            else
            {
                buttons[p].SetActiveButton();
            }
        }
    }

}
