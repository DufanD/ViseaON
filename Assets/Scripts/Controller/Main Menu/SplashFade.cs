using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour
{
    public Image splashImage;
    public string loadlevel;

    IEnumerator Start()
    {
        PlayerPrefs.SetInt("vrLevel", 0);

        splashImage.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5F);
        SceneManager.LoadScene(loadlevel);
    }

    void FadeIn() {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);

    }

    void FadeOut() {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
