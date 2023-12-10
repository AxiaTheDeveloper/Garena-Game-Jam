using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public event EventHandler OnPause, OnUnPause;
    [SerializeField]private CurtainFadeGame fade;
    [SerializeField]private DeathScreen deathScreen;
    public enum GameStates
    {
        WaitingToStart, GameStart, Dead, Pause
    }
    [SerializeField]private GameStates stateGame;
    [SerializeField]private bool isPause;
    // Start is called before the first frame update
    private void Awake() 
    {
        Instance = this;
        stateGame = GameStates.WaitingToStart;
    }

    public void Pause()
    {
        if(isPause)
        {
            stateGame = GameStates.GameStart;
            if(SFXManager.Instance.isWalkingSFXPlay())SFXManager.Instance.StopWalkingSFX();
            OnUnPause?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            stateGame = GameStates.Pause;
            OnPause?.Invoke(this, EventArgs.Empty);
        }
        isPause = !isPause;
    }
    public void GameStart()
    {
        stateGame = GameStates.GameStart;
    }
    public void Death()
    {
        SFXManager.Instance.StopWalkingSFX();
        stateGame = GameStates.Dead;
        deathScreen.UpdateText();
        
    }
    public void ShowDeadUI()
    {
        fade.ShowUIDead();
    }
    public GameStates StateGame()
    {
        return stateGame;
    }
}
