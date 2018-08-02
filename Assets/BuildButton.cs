using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour {
    [SerializeField]
    private Image TargetImage;
    [SerializeField]
    private Text costField;
    [SerializeField]
    private GameObject tagetObject;
    [SerializeField]
    private Color32 inactiveColour;
    [SerializeField]
    private Color32 activeColour;
    [SerializeField]
    private GameObject ObjectToBuild;
    [SerializeField]
    private int BuildCost = 5;
    private BuildMaster buildMaster;

    // Use this for initialization
    void Start () {
        buildMaster = this.GetComponentInParent<BuildMaster>();
        costField.text = BuildCost.ToString();
    }
	


	public void SetActiveButton ()
    {
        TargetImage.color = activeColour;
    }

    public void SetInactiveButton ()
    {
        TargetImage.color = inactiveColour;
    }

    //need to put checks in here.
    public void SetBuildType ()
    {
        buildMaster.setCurrentActive(transform.GetSiblingIndex());
        BuildMaster.buildingObject = ObjectToBuild;
        Debug.Log("Setting build to: " + BuildMaster.buildingObject);
    }
}
