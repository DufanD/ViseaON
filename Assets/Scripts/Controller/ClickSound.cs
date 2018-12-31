using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour {
    public AudioClip sound;
    public AudioMixerGroup mixer;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = true;
        source.outputAudioMixerGroup = mixer;

        button.onClick.AddListener(() => PlaySound());
	}
	
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}
