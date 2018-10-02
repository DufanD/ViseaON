using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour {
    public float timer;
    public string changeLevel;
    
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(changeLevel);
        }
    }
}
