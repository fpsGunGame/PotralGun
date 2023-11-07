using System;
using UnityEngine;

namespace Script
{
    public class Shoot : MonoBehaviour
    {
        PoolingManger _pool;

        void Awake()
        {
            _pool = GameObject.Find("PoolingManager").GetComponent<PoolingManger>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _pool.Fire();
            if (Input.GetKeyDown(KeyCode.R) && _pool.reloadTime == 0)
                _pool.Reload();
        }
        // ReSharper disable Unity.PerformanceAnalysis
    }
}