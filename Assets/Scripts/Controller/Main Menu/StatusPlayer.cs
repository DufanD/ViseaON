using UnityEngine;

public class StatusPlayer : MonoBehaviour {

    private void Start()
    {
        SetStatus(true);
    }

    public void SetStatus (bool status)
    {
        if (status)
        {
            PlayerPrefs.SetInt("status", 1);
        } else
        {
            PlayerPrefs.SetInt("status", 0);
        }
        
    }
}
