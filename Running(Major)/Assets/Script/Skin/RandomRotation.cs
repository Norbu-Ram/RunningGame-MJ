using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [SerializeField] float delay, repeatingTime;

    private void Start()
    {
        InvokeRepeating("Rotaion", delay ,repeatingTime );
    }
    void Rotaion()
    {
        transform.Rotate(0, -10,10);
    }
}
