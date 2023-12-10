using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI text_MaxHeight, text_BestHeight, text_TotalJump, text_TotalEnemiesKilled;
    [SerializeField]private CanvasGroup score, settings;
    
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private GameObject backSettingsButton;
    [SerializeField]private PauseUI pauseUI;
    [SerializeField]private CurtainFadeGame fade;
    public void UpdateText()
    {
        float maxHeight = playerIdentity.GetMaxHeight();
        text_MaxHeight.text = Mathf.Round(maxHeight).ToString() + " m";
        if(!PlayerPrefs.HasKey("PREF_BEST_HEIGHT"))
        {
            PlayerPrefs.SetFloat("PREF_BEST_HEIGHT", maxHeight);
            text_BestHeight.text = Mathf.Round(maxHeight).ToString() + " m";
        }
        else
        {
            float bestHeight = PlayerPrefs.GetFloat("PREF_BEST_HEIGHT");
            if(bestHeight > maxHeight)text_BestHeight.text = Mathf.Round(bestHeight).ToString() + " m";
            else
            {
                PlayerPrefs.SetFloat("PREF_BEST_HEIGHT", maxHeight);
                text_BestHeight.text = Mathf.Round(maxHeight).ToString() + " m";
            }
        }
        
        text_TotalJump.text = playerMovement.GetCounterJump().ToString();
        text_TotalEnemiesKilled.text = playerAttack.GetEnemyKillTotal().ToString();
    }
    public void RestartGame()
    {
        
        fade.ShowUIRestart();
    }
    public void MainMenu()
    {
        BGMManager.Instance.DestroyInstance();
        fade.ShowUIMainMenu();
    }
    public void Settings()
    {
        score.LeanAlpha(0f, 0.2f);
        pauseUI.ShowUIEnd();
        backSettingsButton.gameObject.SetActive(true);
    }
    public void BackSettings()
    {
        // settings.LeanAlpha(0f, 0.2f);
        score.LeanAlpha(1f, 0.5f);
        pauseUI.CloseUI();
        backSettingsButton.gameObject.SetActive(false);
    }
}
