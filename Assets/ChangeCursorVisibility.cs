using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursorVisibility : MonoBehaviour
{
    [SerializeField] bool StartWithCursorOn;
    // Start is called before the first frame update
    void Start()
    {
        if (StartWithCursorOn)
            Show();
        if (StartWithCursorOn == false)
            Hide();  
    }

    public void Hide()
    {
        Cursor.visible = false;
    }

    public void Show()
    {
        Cursor.visible = true;
    }
}
