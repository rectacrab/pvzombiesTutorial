using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {
    private string displayString;
    [SerializeField]
    private Text[] textFields;
    [SerializeField]
    private float zPos;
    private Animator anim;

	// Use this for initialization
	void Awake () {
        anim = this.GetComponent<Animator>();
    }

    //set the text.
    public void SetText(string newString, GameObject summoningObject)
    {
        displayString = newString;
        foreach (Text txt in textFields)
        {
            txt.text = displayString;
        }

        //lets move there!
        this.transform.position = new Vector3(summoningObject.transform.position.x, summoningObject.transform.position.y, zPos);
        anim.Play("DamageFloat");
    }

    //method to complete.
    public void Completed ()
    {
        //gameObject.SetActive(false);
    }
}
