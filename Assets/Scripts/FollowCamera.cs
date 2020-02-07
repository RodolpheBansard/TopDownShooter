using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerPos;
    

    void Update()
    {
        if(playerPos != null)
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -10);
        }
        
    }
}
