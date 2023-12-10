using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainFadeGame : MonoBehaviour
{
    [SerializeField]private CanvasGroup fadeBG;
    [SerializeField]private CanvasGroup deathScreen;
    [SerializeField]private float hideUISpeed = 0.8f;
    [SerializeField]private GameManager gameManager;
    private void Awake() {
        // fadeBG = GetComponent<RectTransform>();
        deathScreen.alpha = 0f;
    }
    private void Start() 
    {
        HideUI();
    }
    private void HideUI(){
        fadeBG.LeanAlpha(0f, hideUISpeed).setOnComplete(
            ()=> 
            {
                gameManager.GameStart();
                fadeBG.gameObject.SetActive(false);
            }
            
        );
    }
    public void ShowUIDead(){
        deathScreen.gameObject.SetActive(true);
        fadeBG.gameObject.SetActive(true);
        fadeBG.LeanAlpha( 1f, hideUISpeed).setOnComplete(
            ()=> 
            {
                deathScreen.LeanAlpha(1f, 0.8f);
            }
        );
    }
}
