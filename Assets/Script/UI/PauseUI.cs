using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField]private Slider BGMSlider;
    [SerializeField]private CanvasGroup UI;
    [SerializeField]private GameObject buttons;
    [SerializeField]private CurtainFadeGame fade;
    private void Awake() {
        CloseUI();
    }
    public Slider GetBGMSlider()
    {
        return BGMSlider;
    }
    public void ShowUI()
    {
        UI.gameObject.SetActive(true);
        UI.LeanAlpha(1f, 0.8f);
    }
    public void ShowUIEnd()
    {
        UI.gameObject.SetActive(true);
        UI.LeanAlpha(1f, 0.8f);
        buttons.SetActive(false);
    }
    public void Restart()
    {
        fade.ShowUIRestart();
    }
    public void CloseUI()
    {
        UI.LeanAlpha(0f, 0.2f).setOnComplete(
            ()=>
            {
                UI.gameObject.SetActive(false);
            }
        );
        
    }
    public void CloseUIInGame()
    {
        UI.LeanAlpha(0f, 0.8f).setOnComplete(
            ()=>
            {
                UI.gameObject.SetActive(false);
                GameManager.Instance.Pause();
            }
        );
    }
    public void Mainmenu()
    {
        BGMManager.Instance.DestroyInstance();
        fade.ShowUIMainMenu();
    }
}
