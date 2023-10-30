using System.Collections;
using UnityEngine;

public class OrangePortalOpen : PortalOpen
{
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && GameObject.Find("Player/PortalGun").GetComponent<PortalGun>().check) {
            GameObject portal = GameObject.Find("BluePortalOpen(Clone)");
            StartCoroutine(TelPo(portal));
            other.transform.position = portal.transform.position;
        }
    }
}
