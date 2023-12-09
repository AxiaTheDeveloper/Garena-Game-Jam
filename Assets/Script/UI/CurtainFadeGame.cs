using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainFadeGame : MonoBehaviour
{
    [SerializeField]private RectTransform fadeBG;
    [SerializeField]private float hideUISpeed = 2f;
    [SerializeField]private GameManager gameManager;
    private void Awake() {
        fadeBG = GetComponent<RectTransform>();
        
    }
    private void Start() 
    {
        HideUI();
    }
    private void HideUI(){
        LeanTween.alpha(fadeBG, 0f, hideUISpeed).setOnComplete(
            ()=> gameManager.GameStart()
        );
    }
    public void ShowUIDead(){
        LeanTween.alpha(fadeBG, 1f, 2f).setOnComplete(
            ()=> Debug.Log("Ded")
        );
    }
}
