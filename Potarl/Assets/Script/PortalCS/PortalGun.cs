using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public List<GameObject> portal = new List<GameObject>();

    public GameObject firePoint;
    List<int> counts = new List<int>{0, 0};
    public bool check;
    GameObject bluePortal;
    GameObject orangePortal;

    private void Awake()
    {
        check = false;
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0)) {
            PortalSpawn(0);
        } else if (Input.GetMouseButtonDown(1)) {
            PortalSpawn(1);
        }

        if (counts[0] + counts[1] == 2) {
            check = true;
        } else {
            check = false;
        }
    }

    private void PortalSpawn(int index)
    {
        SoundManager.instance.PlaySFX(SoundManager.sfxClips.portalGun_Shout);
        if (index == 0) {
            bluePortal = Instantiate(portal[0], Vector3.zero, transform.rotation);
            bluePortal.transform.position = firePoint.transform.position;
            counts[0] = 1;
        } else {
            orangePortal = Instantiate(portal[1], Vector3.zero, transform.rotation);
            orangePortal.transform.position = firePoint.transform.position;
            counts[1] = 1;
        }
    }
}