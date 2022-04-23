using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Vector3  offset;
    // Update is called once per frame
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
   
    void LateUpdate()
    {
        if(playerPos != null )
        transform.position = playerPos.position+ offset  ;
    }
}
