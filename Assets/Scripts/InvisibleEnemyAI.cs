using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleEnemyAI : MonoBehaviour {
    private int enemyOrientation;
    public GameObject player;
	// Use this for initialization
	void Start () {
        //disables the image and choses the orientationif the object is left or right of the player
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (gameObject.transform.position.x > player.transform.position.x)
        {
            enemyOrientation = -1;

        }
        else if (gameObject.transform.position.x < player.transform.position.x)
        {
            enemyOrientation = 1;

        }
    }
	
	// Update is called once per frame
	void Update () {
     //adds force to the object when they reach a certain distance bettwen it and the player
        if (Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) > 5)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(20*enemyOrientation, 0.0f));
           

        }
     //when this distance is reached the object becomes active
        else  if (Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) > 0.8f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

        }
  //here it checks the orientation so when it passes the player it gets disabled
        if (enemyOrientation > 0)
        {
         if (gameObject.transform.position.x > player.transform.position.x)
            {
                gameObject.SetActive(false);
            }
        }
        else if(enemyOrientation < 0)
        {
            if (gameObject.transform.position.x < player.transform.position.x)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
