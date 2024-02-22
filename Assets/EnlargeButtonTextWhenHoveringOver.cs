using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class EnlargeButtonTextWhenHoveringOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float scaleMultipler;

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<RectTransform>().localScale *= scaleMultipler;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<RectTransform>().localScale *= scaleMultipler;
    }
}

