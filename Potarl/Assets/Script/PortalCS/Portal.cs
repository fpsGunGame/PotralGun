using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float speed;

    bool isGo;
    public GameObject portalOpen;
    private GameObject portal;
    private float playerAngleY;

    private void Awake() 
    {
        isGo = true;
        playerAngleY = GameObject.Find("Player").GetComponent<Transform>().eulerAngles.y;
    }

    private void Update() 
    {
        if (isGo)
            transform.Translate(Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider other) 
    {
        isGo = false;
        Transform wall = other.transform;
        if (other.CompareTag("WallOne")) {
            PortalOpen();
            portal.transform.rotation = Quaternion.Euler(90, AngleCalculation(playerAngleY), 0);
        } else if (other.CompareTag("WallTwo")) {
            PortalOpen();
            portal.transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (other.CompareTag("WallThree")) {
            PortalOpen();
            portal.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        Destroy(gameObject);
    }

    private void PortalOpen()
    {
        GameObject isPortal = GameObject.Find(portalOpen.name + "(Clone)");
        if (isPortal != null)
            Destroy(isPortal);
        portal = Instantiate(portalOpen);
        portal.transform.position = gameObject.transform.position;
        
    }

    private float AngleCalculation(float angle)
    {
        if (angle > 315 || angle < 45) {
            return 0f;
        } else if (angle < 135) {
            return 90f;
        } else if (angle < 225) {
            return 0f;
        } else {
            return 90f;
        }
    }
}
