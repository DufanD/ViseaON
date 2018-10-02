using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleClick : MonoBehaviour {
    public AudioClip clickFx;
    public AudioMixerGroup mixer;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = clickFx;
        source.playOnAwake = false;
        source.outputAudioMixerGroup = mixer;
    }

    public void ClickSound()
    {
        source.PlayOneShot(clickFx);
    }
}
