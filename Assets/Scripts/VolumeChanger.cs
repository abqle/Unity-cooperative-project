using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float x = 10;

    public void SetGeneralSound(float VolumeValue)
    {
        audioMixer.SetFloat("GeneralSoundVolume", Mathf.Log(VolumeValue) * x);
    }
    public void SetEffectsSound(float VolumeValue)
    {
        audioMixer.SetFloat("SoundVolume", Mathf.Log(VolumeValue) * x);
    }
    public void SetMusicSound(float VolumeValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log(VolumeValue) * x);
    }
}
