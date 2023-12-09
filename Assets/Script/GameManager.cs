using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
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
        stateGame = GameStates.GameStart;
    }

    public void Pause()
    {
        if(isPause)
        {
            stateGame = GameStates.GameStart;
        }
        else
        {
            stateGame = GameStates.Pause;
        }
        isPause = !isPause;
    }
    public void GameStart()
    {
        stateGame = GameStates.GameStart;
    }
    public void Death()
    {
        stateGame = GameStates.Dead;
    }
    public GameStates StateGame()
    {
        return stateGame;
    }
}
