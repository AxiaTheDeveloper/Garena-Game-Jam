using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum CameraColliderSide
    {
        Top, Down
    }
    [SerializeField]private GameObject parent;
    [SerializeField]private CameraColliderSide side;
    [SerializeField]private float moveSize, delayCheckerTime, delayChecker;
    private bool isDelay;
    [SerializeField]private CameraMovement otherColliderSide;
    
    private void Update() 
    {
        if(isDelay)
        {
            delayChecker -= Time.deltaTime;
            if(delayChecker <= 0)isDelay = false;
        }    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!isDelay)
            {
                if(side == CameraColliderSide.Top)parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + moveSize, parent.transform.position.z);
                else parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y - moveSize, parent.transform.position.z);
                Debug.Log(parent.transform.position);

                isDelay = true;
                delayChecker = delayCheckerTime;
                otherColliderSide.TurnOnThisDelay();
            }
            
        }
    }
    public void TurnOnThisDelay()
    {
        isDelay = true;
        delayChecker = 0.1f;
    }
}
