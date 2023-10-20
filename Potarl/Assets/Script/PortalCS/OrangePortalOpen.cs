using System.Collections;
using UnityEngine;

public class OrangePortalOpen : PortalOpen
{
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && GameObject.Find("Player/PortalGun").GetComponent<PortalGun>().check) {
            GameObject portal = GameObject.Find("BluePortal(Clone)");
            StartCoroutine(TelPo(portal));
            other.transform.position = portal.transform.position;
        }
    }

    public IEnumerator TelPo(GameObject portal)
    {       
        portal.GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(1f);
        portal.GetComponent<BoxCollider>().isTrigger = true;
    }
}
