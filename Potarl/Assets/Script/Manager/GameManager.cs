using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    bool soundSetting;

    private void Awake() 
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }

        soundSetting = true;
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && soundSetting) {
            GameObject.Find("Manager/Canvas").transform.GetChild(0).gameObject.SetActive(true);
            soundSetting = false;
            Time.timeScale = 0f;
        } else {
            GameObject.Find("Manager/Canvas/Sound").SetActive(false);
            soundSetting = true;
        }
    }
}
