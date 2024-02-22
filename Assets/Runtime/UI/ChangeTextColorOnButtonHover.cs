using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeTextColorOnButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TMP_ColorGradient normalGradient;
    [SerializeField] TMP_ColorGradient hoverGradient;

    [SerializeField] TextMeshProUGUI text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.colorGradientPreset = hoverGradient;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.colorGradientPreset = normalGradient;
     }

}
