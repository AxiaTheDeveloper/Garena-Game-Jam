using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI height_Text, jumpGift_Text, attackGift_Text;
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private PauseUI pauseUI;
    private void Update() {
        UpdateHeightVisual();
    }
    public void UpdateHeightVisual()
    {
        height_Text.text = Mathf.Round(playerIdentity.GetHeight()).ToString() + " m";
    }
    public void UpdateJumpGiftVisual(int number)
    {
        jumpGift_Text.text = number.ToString();
    }
    public void UpdateAttGiftVisual(int number)
    {
        attackGift_Text.text = number.ToString();
    }
    public void Pause()
    {
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            GameManager.Instance.Pause();
            pauseUI.ShowUI();
        }
        
        
    }
}
