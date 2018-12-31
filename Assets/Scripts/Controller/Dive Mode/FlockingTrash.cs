using UnityEngine;

public class FlockingTrash : MonoBehaviour {

    public GameObject[] trashPrefabs;
    public GameObject trashPlace;
    public static int tankSize = 10;

    static int numTrash = 5;
    public static GameObject[] allTrash = new GameObject[numTrash];
    public static Vector3 goalPos = Vector3.zero;

    void Start () {
        for (int i = 0; i < numTrash; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize)
            );
            GameObject fish = (GameObject)Instantiate(trashPrefabs[Random.Range(0, trashPrefabs.Length)], pos, Quaternion.identity);
            fish.transform.parent = trashPlace.transform;
            allTrash[i] = fish;
        }
    }
	
	// Update is called once per frame
	void Update () {
        HandleGoalPos();
    }

    void HandleGoalPos()
    {
        if (Random.Range(1, 10000) < 50)
        {
            goalPos = new Vector3(
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize)
            );
        }
    }
}
