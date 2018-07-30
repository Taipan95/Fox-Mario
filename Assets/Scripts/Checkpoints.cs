using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
    // a list with The Checkpoints
    public List<GameObject> checkpointArray = new List<GameObject>();
    //gameobjects that will have to be teleported on loose
    public GameObject player, cameraMain;
    //creating a private collider for personal convenience
    private BoxCollider2D CheckCollider;
    //it starts from zero the FIRST CHECKPOINT IN THE GAME must be an invisible spawn point
    private int checkpointNumber=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D CheckpointMark)
    {   //if the object collided is a checkpoint then checkpoint number is increased by one the colllider of that object turns of
        if (CheckpointMark.tag.ToLower().Contains("checkpoint"))
        {
            checkpointNumber++;
            CheckCollider = checkpointArray[checkpointNumber].GetComponent<BoxCollider2D>();
            CheckCollider.enabled = false;
        }
    }
    //this is a public method that is called by the general script LoseScript
    public void OnLoose(GameObject Player)
    {
        cameraMain.transform.Translate(0, 0,0);
        cameraMain.transform.position = new Vector3(checkpointArray[checkpointNumber].transform.position.x+12, checkpointArray[checkpointNumber].transform.position.y,GetComponent<Camera>().transform.position.z);
        player.transform.position = checkpointArray[checkpointNumber].transform.position;
        
    }

}
