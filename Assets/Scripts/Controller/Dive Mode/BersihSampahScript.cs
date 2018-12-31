using UnityEngine;

public class BersihSampahScript : MonoBehaviour {

    public GameObject bersihSampahPanel;
    private Animator anim;
    private bool isButtonClicked = false;

    // Use this for initialization
    void Start () {
        anim = bersihSampahPanel.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isButtonClicked==true)
        {
            ButtonClicked();
        }
	}

    public void ButtonClicked()
    {
        //play the SlideOut animation
        anim.Play("PanelSampahOut");
        GetComponent<VRWalk>().enabled = true;
    }
}
