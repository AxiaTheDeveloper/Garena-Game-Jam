using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]private CanvasGroup allTitle, fadeBG;
    [SerializeField]private CanvasGroup options;
    private void Awake() 
    {
        fadeBG.LeanAlpha(0f, 0.5f).setOnComplete(
            ()=>fadeBG.gameObject.SetActive(false)
        );
        options.LeanAlpha(0f, 0.5f).setOnComplete(
            ()=>
            {
                options.gameObject.SetActive(false);
                
            }
        );
    }
    public void StartGame()
    {
        allTitle.LeanAlpha(0f, 0.5f).setOnComplete(
            ()=>
            {
                fadeBG.gameObject.SetActive(true);
                fadeBG.LeanAlpha(1f, 0.2f).setOnComplete(
                    ()=>SceneManager.LoadSceneAsync("MainGame")
                );
            }
        );
    }
    public void Exit()
    {
        allTitle.LeanAlpha(0f, 0.5f).setOnComplete(
            ()=>
            {
                fadeBG.gameObject.SetActive(true);
                fadeBG.LeanAlpha(1f, 0.2f).setOnComplete(
                    ()=>Application.Quit()
                );
            }
        );
    }
    public void Option()
    {
        allTitle.LeanAlpha(0f, 0.5f).setOnComplete(
            ()=>
            {
                allTitle.gameObject.SetActive(false);
                options.gameObject.SetActive(true);
                options.LeanAlpha(1f, 0.2f);
            }
        );
    }
    public void closeOptions()
    {
        options.LeanAlpha(0f, 0.5f).setOnComplete(
            ()=>
            {
                options.gameObject.SetActive(false);
                allTitle.gameObject.SetActive(true);
                allTitle.LeanAlpha(1f, 0.2f);
                
            }
        );
    }
}
