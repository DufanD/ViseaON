using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {
    public GameObject transitionObj;
    public GameObject transitionObj2;

    public void StartForwardTransition()
    {
        this.gameObject.GetComponent<Animator>().SetBool("start", true);
        Active();
    }

    
    public void StartBackTransition()
    {
        this.gameObject.GetComponent<Animator>().SetBool("start", false);
        Deactive();
    }

    public void Active()
    {
        transitionObj.SetActive(true);
        transitionObj2.SetActive(false);
    }

    public void Deactive()
    {
        transitionObj.SetActive(false);
        transitionObj2.SetActive(true);
    }
}
