using System;
using UnityEngine;

namespace Script
{
    public class Shoot : MonoBehaviour
    {
        PoolingManger _pool;
        
        public Transform firePos;
        public GameObject player;

        void Awake()
        {
            _pool = GameObject.Find("PoolingManager").GetComponent<PoolingManger>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Fire();
        }
        // ReSharper disable Unity.PerformanceAnalysis
        void Fire()
        {
            for (int j = 0; j < _pool.poolSize; j++)
            {
                GameObject bullet = _pool.bulletpool[j];
                if (bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePos.transform.position;
                    bullet.transform.rotation = player.transform.rotation;
                    bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * (Time.deltaTime * 5));
                    break;
                }
            }
        }
    }
}