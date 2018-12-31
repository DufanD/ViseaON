using UnityEngine;

public class KlikInformation : MonoBehaviour {
    public GameObject[] fish;

    private static bool[] clicked = new bool[6];
    private PointController pointController;

    // Use this for initialization
    void Start () {
        pointController = new PointController();
        for (int i = 0; i < clicked.Length; i++)
        {
            clicked[i] = false;
        }
    }

    public void fishClicked(int idFish)
    {
        pointController.updatePointClickFish(idFish, clicked);        
    }
}
