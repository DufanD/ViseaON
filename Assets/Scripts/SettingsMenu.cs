using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

	public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        audioMixer.SetFloat("music", volume);
        audioMixer.SetFloat("sfx", volume);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("music", volume);
    }

    public void SetSFX(float volume)
    {
        audioMixer.SetFloat("sfx", volume);
    }
}
