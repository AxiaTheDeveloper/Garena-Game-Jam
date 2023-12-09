using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void Rotate(float x)
    {
        transform.localScale = new Vector3(x, 1, 1);
        gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).transform.localScale = new Vector3(x,1,1);
        gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).transform.localScale = new Vector3(x, 1, 1);
    }
}
