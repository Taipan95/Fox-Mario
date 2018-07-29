using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer1 : MonoBehaviour {

    private float followingEnemySpeed = 5.5f;

    private Vector3 playerPosition;

    public GameObject Player;
    public GameObject FollowingEnemy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        playerPosition = Player.transform.position;

        if(System.Math.Abs(FollowingEnemy.transform.position.x - playerPosition.x) < 11) //if the enemy is close to the player
        {
            FollowingEnemy.transform.position = Vector2.MoveTowards(FollowingEnemy.transform.position, playerPosition, followingEnemySpeed * Time.deltaTime); //move towards the current position of the player
            transform.right = FollowingEnemy.transform.position - playerPosition;
        }
	}
}
