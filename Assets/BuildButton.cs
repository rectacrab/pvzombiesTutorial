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
    private BuildMaster buildMaster;

    // Use this for initialization
    void Start () {
        buildMaster = this.GetComponentInParent<BuildMaster>();

    }
	


	public void SetActiveButton ()
    {
        TargetImage.color = activeColour;
    }

    public void SetInactiveButton ()
    {
        TargetImage.color = inactiveColour;
    }

    public void SetBuildType ()
    {
        buildMaster.setCurrentActive(transform.GetSiblingIndex());
    }
}
