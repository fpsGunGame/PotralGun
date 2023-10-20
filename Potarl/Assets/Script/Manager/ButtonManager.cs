using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> button = new List<Button>();

    private void Start()
    {
        button[0]?.onClick.AddListener(() => ShowSound());
        button[1]?.onClick.AddListener(() => SoundTest());
    }

    private void ShowSound()
    {
        GameObject.Find("Manager/Canvas/Sound").SetActive(false);
        Time.timeScale = 1f;
    }

    private void SoundTest()
    {
        SoundManager.instance.PlaySFX(SoundManager.sfxClips.portalGun_Shout);
    }
}
