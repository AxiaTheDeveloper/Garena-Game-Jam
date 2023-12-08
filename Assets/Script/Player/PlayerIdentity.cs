using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    [SerializeField]private int playerHeightNow;
    public int PlayerHeight()
    {
        return playerHeightNow;
    }
    public void ChangePlayerHeight(int newHeight)
    {
        playerHeightNow = newHeight;
        if(PlatformSpawner.Instance.GetTotalHeight()-1 == newHeight)
        {
            PlatformSpawner.Instance.SpawnPlatform(3);
        }
    }
}
