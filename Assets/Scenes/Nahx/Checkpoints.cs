using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
    public List<GameObject> checkpointArray = new List<GameObject>();
    public GameObject player, camera;
    private GameObject hitCheckpoint;
    private int checkpointNumber=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D CheckpointMark)
    {
        if (CheckpointMark.tag.ToLower().Contains("checkpoint"))
        {
            Debug.Log("ObjectCollided");
            //hitCheckpoint=CheckpointMark.GetComponent<GameObject>;
            checkpointNumber++;
            Debug.Log(+checkpointNumber);
        }
    }
    public void OnLoose(GameObject Player)
    {
        player.transform.position = checkpointArray[checkpointArray.Count - checkpointNumber].transform.position;
        camera.transform.position = checkpointArray[checkpointArray.Count - checkpointNumber].transform.position;
    }

}
