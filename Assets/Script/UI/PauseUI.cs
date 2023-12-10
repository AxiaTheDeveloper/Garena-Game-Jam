using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField]private Slider BGMSlider;
    [SerializeField]private CanvasGroup UI;
    private void Awake() {
        CloseUI();
    }
    public Slider GetBGMSlider()
    {
        return BGMSlider;
    }
    public void ShowUI()
    {
        // UI.gameObject.SetActive(true);
        UI.LeanAlpha(1f, 0.8f);
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }
    public void CloseUI()
    {
        UI.LeanAlpha(0f, 0.8f).setOnComplete(
            ()=>
            {
                UI.gameObject.SetActive(true);
            }
        );
        
    }
    public void CloseUIInGame()
    {
        UI.LeanAlpha(0f, 0.8f).setOnComplete(
            ()=>
            {
                // UI.gameObject.SetActive(false);
                GameManager.Instance.Pause();
            }
        );
    }
    public void Mainmenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
