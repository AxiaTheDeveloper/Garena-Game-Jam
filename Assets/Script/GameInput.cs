using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameInput Instance{get; private set;}
    private void Awake() 
    {
        Instance = this;
    }
    
    public bool GetInputA()
    {
        return Input.GetKey(KeyCode.A);
    }
    public Vector2 GetInputPlayerDirection()
    {
        if(Input.GetKey(KeyCode.A))return new Vector2 (-1, 0);
        else if(Input.GetKey(KeyCode.D))return new Vector2 (1,0);
        return Vector2.zero;
    }
    public bool GetInputDownJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public bool GetInputUpJump()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }
    public bool GetInputSlam()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
