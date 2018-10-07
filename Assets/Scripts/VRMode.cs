using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRMode : MonoBehaviour {
    public bool vrMode;

	// Use this for initialization
	void Start () {
        StartCoroutine(activatorVR());
    }
	
    public IEnumerator activatorVR()
    {
        if (vrMode)
        {
            XRSettings.LoadDeviceByName("cardboard");
        }
        else
        {
            XRSettings.LoadDeviceByName("none");
        }
        yield return null;
        XRSettings.enabled = vrMode;
    }
}
