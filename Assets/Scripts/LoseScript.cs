
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//stil under development but needed in order for the checkpoints to work
public class LoseScript : MonoBehaviour {
    public double timer;
    public double deathDelay;
    public bool isHit = false,free;
    //private float currentPlayerPositionx;
	// Use this for initialization
	void Start () {
}
	// Update is called once per frame
	void Update () {
        if (isHit)
        {
            timer+=Time.deltaTime;
            //Debug.Log(+timer);
            if (timer > deathDelay)
            {  if (isHit)
                {
                    free = true;
                }
                if (free)
                {
                        isHit = false;
                        
                    afterDeath();





                }
            }
            }
        if (timer >= deathDelay) { timer = 0; }
     
        

        
    }
    void OnTriggerEnter2D(Collider2D Coli)
    {
        //currentPlayerPositionx = gameObject.transform.position.x;
        if (Coli.tag.ToLower().Contains("enemy") &&gameObject.transform.position.y<=Coli.transform.position.y)
        {
         isHit = true;
            onDeath();   

        }
        if (Coli.name.ToLower().Contains("death"))
        {
        //currentPlayerPositionx = gameObject.transform.position.x;

            isHit = true;
            onDeath();

        }
        
    }
    private void afterDeath()
    { 
        //gameObject.transform.position = gameObject.transform.position;
     
            Debug.Log("entered");

        PlayerControl.Instance.animator.SetBool("Dead", false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<PlayerControl>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        free = true;
        gameObject.GetComponent<Checkpoints>().OnLoose(this.gameObject);

    }
    private void onDeath()
    {
        PlayerControl.Instance.animator.SetBool("Jump", false);
        PlayerControl.Instance.animator.SetBool("Dead", true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<PlayerControl>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        free = false;
       
    }

}
