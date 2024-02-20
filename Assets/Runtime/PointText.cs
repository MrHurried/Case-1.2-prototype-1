using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointText : MonoBehaviour
{
    TextMeshProUGUI textBox;


    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
    }

    public void Refresh(int newCollectedPointAmount, int pointsInCurrentRoom)
    {
        textBox.text = newCollectedPointAmount.ToString() + " / " + pointsInCurrentRoom.ToString() + " points collected";
    }
}
