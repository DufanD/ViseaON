using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MulaiYa : MonoBehaviour
{
    public Button Mulai;
    public AudioClip sound;
    public Animator ani;
    public Canvas yourcanvas;
    public GameObject Player;

    void Start()
    {
        Mulai = Mulai.GetComponent<Button>();
        ani.enabled = false;
        yourcanvas.enabled = true;
    }


    public void Press()

    {
        Mulai.enabled = true;
        AudioSource.PlayClipAtPoint(sound, transform.position);
        ani.enabled = true;

    }
}