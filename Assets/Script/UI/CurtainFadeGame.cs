using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainFadeGame : MonoBehaviour
{
    [SerializeField]private RectTransform fadeBG;
    [SerializeField]private float hideUISpeed = 2f;
    private void Awake() {
        fadeBG = GetComponent<RectTransform>();
        HideUI();
    }
    private void HideUI(){
        LeanTween.alpha(fadeBG, 0f, hideUISpeed);
    }
}
