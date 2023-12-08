using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        GameStart, Finish, Dead, Pause
    }
    [SerializeField]private GameStates stateGame;
    [SerializeField]private bool isPause;
    // Start is called before the first frame update
    private void Awake() 
    {
        stateGame = GameStates.GameStart;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
