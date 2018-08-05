using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarInventory : MonoBehaviour {
    [SerializeField]
    private int StartingStars;
    [SerializeField]
    private Text CurrentStarField;
    private int starCount;

    // Use this for initialization
    void Start() {
        AddStars(StartingStars);
    }

    public void AddStars (int stars)
    {
        starCount += stars;
        UpdateStarCount();
    }

    public void SpendStars (int stars)
    {
        starCount -= stars;
        UpdateStarCount();
    }

    private void UpdateStarCount()
    {
        CurrentStarField.text = starCount.ToString();
    }

    public int GetStarCount ()
    {
        return starCount;
    }
}
