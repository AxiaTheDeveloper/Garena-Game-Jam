using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance{get;private set;}
    [SerializeField]private GameObject[] platformsPrefab;
    [SerializeField]private float heightNow, heightAdd;
    [SerializeField]private int startHeight, totalHeight, lastRandomNumber;
    private void Awake() 
    {
        Instance = this;
        totalHeight = 1;
        heightNow = transform.position.y + heightAdd;
        SpawnPlatform(startHeight);
    }
    public void SpawnPlatform(int totalSpawn)
    {
        for(int i=0;i<totalSpawn;i++)
        {
            int random = Random.Range(0,2);
            if(i > 0)
            {
                while(random == lastRandomNumber)
                {
                    random = Random.Range(0,2);
                }
            }
            lastRandomNumber = random;
            Transform newPlatform = Instantiate(platformsPrefab[random].transform, this.gameObject.transform);
            newPlatform.transform.position = new Vector3(transform.position.x, heightNow, transform.position.z);
            heightNow += heightAdd;
            totalHeight++;
            newPlatform.GetComponent<PlatformIdentity>().ChangePlatformHeight(totalHeight);
        }
    }
    public int GetTotalHeight()
    {
        return totalHeight;
    }
}
