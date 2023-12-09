using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI text_Height, text_TotalJump, text_TotalEnemiesKilled;
    
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private GameObject SettingsUI;
    public void UpdateText()
    {
        text_Height.text = Mathf.Round(playerIdentity.GetHeight()).ToString();
        text_TotalJump.text = playerMovement.GetCounterJump().ToString();
        text_TotalEnemiesKilled.text = playerAttack.GetEnemyKillTotal().ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void Settings()
    {
        SettingsUI.SetActive(true);
    }
}
