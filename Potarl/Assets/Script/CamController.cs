using UnityEngine;

namespace Script
{
    public class CamController : MonoBehaviour
    {
        bool _zoom;

        private Camera _mainCamera;
        void Start()
        {
            _mainCamera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!_zoom)
                {
                    _mainCamera.fieldOfView -= 35;
                    _zoom = true;
                }
                else
                {
                    _mainCamera.fieldOfView += 35 * Time.deltaTime;
                    _zoom = false;
                }
            }
        }
    }
}
