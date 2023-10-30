using System.Collections;
using UnityEngine;

public class BluePortalOpen : PortalOpen
{
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && GameObject.Find("Player/PortalGun").GetComponent<PortalGun>().check) {
            GameObject portal = GameObject.Find("OrangePortalOpen(Clone)");
            StartCoroutine(TelPo(portal));
            other.transform.position = portal.transform.position;
        }
    }
}