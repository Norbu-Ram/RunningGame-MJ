using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float time=0.3f;
    private void Start()
    {
        DestroyObject(time);
    }
    void  DestroyObject(float TTD )
    {
        Destroy(gameObject, TTD);

    }

}
