﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderScript : MonoBehaviour {
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D objectCollided)
    {
        rb = objectCollided.GetComponent<Rigidbody2D>();
        if (objectCollided.tag.ToLower().Contains("player"))
        {
            Debug.Log("it M8 Work");
                //rb.velocity = new Vector2(0, 0);
            objectCollided.transform.position =new Vector3(gameObject.transform.position.x+0.6f, objectCollided.transform.position.y,1);
        }
    }
    //void OnTriggerExit2D(Collider2D objectCollided)
    //{
    //    if (objectCollided.tag.ToLower().Contains("enemy"))
    //    {
    //        Debug.Log("it M8 Work");
    //        enemy.SetActive(false);
    //    }
    //}
}
