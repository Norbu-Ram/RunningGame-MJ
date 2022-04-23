using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPosTxt : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Text playerPosTxt;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos!=null )
        playerPosTxt.text =((int)playerPos.position.z).ToString();
    }
}
