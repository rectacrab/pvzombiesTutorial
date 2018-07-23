using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {
    private List<DamageText> textArray = new List<DamageText>();
    private int currentIndex = 0;

	// Use this for initialization
	void Start () {
		for (int p =0; p < this.transform.childCount; p++)
        {
            textArray.Add(this.transform.GetChild(p).gameObject.GetComponent<DamageText>());
        }
	}
	
    //display damage on a text object.
	public void DisplayDamage (float dmg, GameObject summoner)
    {
        textArray[currentIndex].gameObject.SetActive(true);
        textArray[currentIndex].SetText(dmg.ToString(), summoner);
        if (currentIndex+1 < textArray.Count)
        {
            currentIndex += 1;
        }
        else
        {
            currentIndex = 0;
        }
    }
}
