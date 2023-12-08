using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void Rotate(float x)
    {
        transform.localScale = new Vector3(x, 1, 1);
    }
}
