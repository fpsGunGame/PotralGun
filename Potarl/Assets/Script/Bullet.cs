using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float currentTime;
    
    private GameObject _target;
    void OnEnable()
    {
        _target = GameObject.Find("firePos");
        transform.position = _target.transform.position;
        transform.rotation = _target.transform.rotation;;
    }

    void Update()
    {
        transform.position += Vector3.forward * (Time.deltaTime * 15f);
    }
}
