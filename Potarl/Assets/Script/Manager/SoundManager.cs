using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public GameObject soundSystem;

    public float bgmVolume;
    public float sfxVolume;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public List<AudioClip> bgmClip;
    public List<AudioClip> sfxClip;

    public Slider bgm_Slider;
    public Slider sfx_Slider;

    public enum bgmClips
    {
        
    }

    public enum sfxClips
    {
        portalGun_Shout
    }

    private void Awake() 
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }

        soundSystem.SetActive(false);
    }

    public void SoundTest()
    {
        PlaySFX(sfxClips.portalGun_Shout);
    }

    public void Hide()
    {
        soundSystem.SetActive(false);
    }

    private void Update() 
    {
        bgmSource.volume = bgm_Slider.value;
        sfxSource.volume = sfx_Slider.value;
    }

    public void PlayMusic(bgmClips clip)
    {
        bgmSource.loop = true;
        bgmSource.clip = bgmClip[(int)clip];
        bgmSource.volume = bgmVolume;
        bgmSource.enabled = true;
        bgmSource.Play();
    }

    public void PlaySFX(sfxClips clip)
    {
        sfxSource.loop = false;
        sfxSource.clip = sfxClip[(int)clip];
        sfxSource.volume = sfxVolume;
        sfxSource.enabled = true;
        sfxSource.Play();
    }

    public static implicit operator SoundManager(GameManager v)
    {
        throw new NotImplementedException();
    }
}
