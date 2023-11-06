using UnityEngine;

namespace Script
{
    public class PoolingManger : MonoBehaviour
    {
        // Start is called before the first frame update
        public int poolSize = 20;
        
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
       
    }
}
