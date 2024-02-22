using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointText : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI textBox;


    // Start is called before the first frame update
    void Start()
    {
        //textBox = GetComponent<TextMeshProUGUI>();
    }

    public void Refresh(int newCollectedPointAmount = 0, int pointsInCurrentRoom = 0)
    {
        textBox.text = newCollectedPointAmount.ToString() + " / " + pointsInCurrentRoom.ToString() + " points collected";
    }
}
