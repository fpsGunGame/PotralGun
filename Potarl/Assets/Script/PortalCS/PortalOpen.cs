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
    
    public IEnumerator TelPo(GameObject portal)
    {       
        portal.GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(1f);
        portal.GetComponent<BoxCollider>().isTrigger = true;
    }
}