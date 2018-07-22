using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {
    private DamageText[] textArray;
    private int currentIndex = 0;

	// Use this for initialization
	void Start () {
		for (int p =0; p < this.transform.childCount; p++)
        {
            textArray[p] = this.transform.GetChild(p).GetComponent<DamageText>();
        }
	}
	
    //display damage on a text object.
	public void DisplayDamage (float dmg, GameObject summoner)
    {
        textArray[currentIndex].gameObject.SetActive(true);
        textArray[currentIndex].SetText(dmg.ToString(), summoner);
        currentIndex += 1;
    }
}
