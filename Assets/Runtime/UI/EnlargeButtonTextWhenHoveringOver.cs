using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class EnlargeButtonTextWhenHoveringOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;

    Vector3 normalScale;
    Vector3 hoverScale;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        normalScale = rectTransform.localScale;
        hoverScale = rectTransform.localScale * scaleMultipler;
    }

    [SerializeField] float scaleMultipler;

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = normalScale;
    }

    
}

