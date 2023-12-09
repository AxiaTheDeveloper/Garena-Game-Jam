using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance{get;private set;}
    [SerializeField]private GameObject[] platformsPrefab;
    [SerializeField]private float heightNow, heightAdd;
    [SerializeField]private int startHeight, totalHeight, lastRandomNumber;
    [SerializeField]private GameObject parent;
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
            int maxLength = 0, minLength = 0;
            if(totalHeight/10 == 0)
            {
                minLength = 0;
                maxLength = 9;
            }
            else if(totalHeight/10 == 1)
            {
                minLength = 9;
                maxLength = 18;
            }
            else if(totalHeight/10 == 2)
            {
                minLength = 4;
                maxLength = platformsPrefab.Length;
            }
            int random = Random.Range(minLength,maxLength);
            if(i > 0)
            {
                while(random == lastRandomNumber )
                {
                    random = Random.Range(minLength,maxLength);
                    while(lastRandomNumber == 5 && random == 7)
                    {
                        random = Random.Range(minLength,maxLength);
                    }
                }
                
            }
            lastRandomNumber = random;
            Transform newPlatform = Instantiate(platformsPrefab[random].transform, parent.gameObject.transform);
            // Debug.Log(newPlatform);
            newPlatform.transform.localPosition = new Vector3(transform.position.x, heightNow, transform.position.z);
            // Debug.Log(newPlatform.transform.localPosition);
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
