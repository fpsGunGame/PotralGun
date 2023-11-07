using System;
using UnityEngine;

namespace Script
{
    public class PoolingManger : MonoBehaviour
    {
        // Start is called before the first frame update
        public int poolSize = 20;
        private int bulletSize;
        public float reloadTime;
        
        public GameObject bullet;
        public GameObject[] bulletpool;
        void Start()
        {
            bulletpool = new GameObject[poolSize];
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bull = Instantiate(bullet);
                bulletpool[i] = bull;
                bull.SetActive(false);
            }
        }

        private void Update()
        {
            if (reloadTime > 0)
            {
                Reload();
            }
                
        }

        public void Fire()
        {
            for (int j = 0; j < poolSize; j++)
            {
                bullet = bulletpool[j];
                if (bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bulletSize--;
                    Debug.Log(bulletSize);
                    if (bulletSize == 0)
                        Reload();
                    break;
                }
            }
        }

        public void Reload()
        {
            reloadTime += Time.deltaTime;
            if (reloadTime > 1f)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    bullet = bulletpool[i];
                    if (bullet.activeSelf)
                        bullet.SetActive(false);
                }
                bulletSize = poolSize;
                reloadTime = 0;
            }    
        }
    }
}
