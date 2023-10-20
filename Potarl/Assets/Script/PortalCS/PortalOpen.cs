using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpen : MonoBehaviour
{
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Destroy(gameObject);
        }
    }
}