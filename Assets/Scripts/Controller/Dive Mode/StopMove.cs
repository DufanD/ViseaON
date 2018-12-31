using UnityEngine;

public class StopMove : MonoBehaviour {
    public GameObject[] fish;
    public GameObject panel;
    public GameObject button;
    public VRWalk vRWalk;

    private int id;
    
    public void StopFish(int idFish)
    {
        id = idFish;
        fish[id-1].GetComponent<Flock>().enabled = false;
        button.SetActive(true);
        PlayerWalk(false);
    }

    public void LetsMove()
    {
        fish[id-1].GetComponent<Flock>().enabled = true;
        panel.SetActive(false);
        button.SetActive(false);
        PlayerWalk(true);
    }

    public void PlayerWalk(bool statusWalk)
    {
        if (statusWalk) vRWalk.enabled = true;
        else vRWalk.enabled = false;
    }
}
