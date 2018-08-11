using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFlyingAiScript : MonoBehaviour {
    private float timerOfThisGameObject=1, Axes = 0;
    public float velocityOfbox,timeTillRightSide,timeTillLeftSide,endLoopTimer;
    private bool left, right;
        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Axes += Time.deltaTime;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * velocityOfbox, Mathf.Cos((-Axes)) * velocityOfbox);
        timerOfThisGameObject += 0.5f;
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
        if (timerOfThisGameObject >= timeTillRightSide)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * velocityOfbox, Mathf.Cos((-Axes)) * velocityOfbox);
        }
        if (timerOfThisGameObject == timeTillLeftSide)
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(11 * velocityOfbox, Mathf.Cos((-Axes)) * velocityOfbox);
        }
        if (timerOfThisGameObject>= endLoopTimer) {
            timerOfThisGameObject = 0;


        }

    }

}

