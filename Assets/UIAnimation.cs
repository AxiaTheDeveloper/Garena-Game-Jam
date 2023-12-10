using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float timer;
    [SerializeField] private GameObject lineGameObject;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    enum WhichUI
    {
        StartButton,
        OptionButton,
        ExitButton,
        CreditButton
    }

    [SerializeField] private WhichUI uiType;

    void ChangeTextColor(Color tColor)
    {
        text.color = tColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.move(lineGameObject, gameObject.transform, timer);
        if (uiType == WhichUI.ExitButton)
        {   
            LeanTween.color(lineGameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>(), Color.red, timer);
            LeanTween.color(lineGameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), Color.red, timer);
            var color = text.color;
            var fadeoutcolor = color;
            fadeoutcolor.a = 1;
            LeanTween.value(gameObject, ChangeTextColor, fadeoutcolor, Color.red, timer);
        }
        if (uiType == WhichUI.OptionButton)
        {
            LeanTween.color(lineGameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>(), Color.white, timer);
            LeanTween.color(lineGameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), Color.white, timer);
        }
        else if (uiType == WhichUI.StartButton)
        {
            LeanTween.color(lineGameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>(), Color.black, timer);
            LeanTween.color(lineGameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), Color.black, timer);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (uiType == WhichUI.ExitButton)
        {
            var color = text.color;
            var fadeoutcolor = color;
            fadeoutcolor.a = 1;
            LeanTween.value(gameObject, ChangeTextColor, fadeoutcolor, Color.white, timer);
        }
    }
}
