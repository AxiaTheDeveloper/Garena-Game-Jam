using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainFadeGame : MonoBehaviour
{
    [SerializeField]private CanvasGroup fadeBG, fade;
    [SerializeField]private CanvasGroup deathScreen;
    [SerializeField]private float hideUISpeed = 0.2f;
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
    public void ShowUIMainMenu()
    {
        fade.gameObject.SetActive(true);
        fade.LeanAlpha( 1f, 0.1f).setOnComplete(
            ()=> 
            {

                SceneManager.LoadSceneAsync("Main Menu");
            }
        );
    }
    public void ShowUIRestart()
    {
        fade.gameObject.SetActive(true);
        fade.LeanAlpha( 1f, 0.1f).setOnComplete(
            ()=> 
            {

                SceneManager.LoadSceneAsync("MainGame");
            }
        );
    }
}
