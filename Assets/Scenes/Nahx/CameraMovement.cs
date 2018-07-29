using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float CameraSetting; 
    private float PlayerX;
        // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerX = player.transform.position.x;
        gameObject.transform.position = new Vector3(player.transform.position.x- CameraSetting, player.transform.position.y,-2);
        if (PlayerX < 0)
        {
            gameObject.transform.position =new Vector3(0,0,0);
        }
    }
}