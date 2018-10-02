using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyMode : MonoBehaviour {
    public Toggle DayLight;
    public Toggle TwiLight;
    public Material daySky;
    public Material twiSky;

    public void DayOn()
    {
        DayLight.isOn = true;
        TwiLight.isOn = false;
        RenderSettings.skybox = daySky;
    }	

    public void TwiOn()
    {
        TwiLight.isOn = true;
        DayLight.isOn = false;
        RenderSettings.skybox = twiSky;
    }
}
