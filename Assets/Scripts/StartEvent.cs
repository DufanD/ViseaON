using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEvent : MonoBehaviour {
    public Button tombolStart;
    public AudioClip sound;
    public Animator afterStart;
    public Canvas yourcanvas;
    public GameObject player;

    void Start()
    {
        tombolStart = tombolStart.GetComponent<Button>();
        afterStart.enabled = false;
        yourcanvas.enabled = true;
        player.GetComponents<Animator>();
    }

    public void Press()
    {
        tombolStart.enabled = true;
        AudioSource.PlayClipAtPoint(sound, transform.position);
        afterStart.enabled = true;
    }
}