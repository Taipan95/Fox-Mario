using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour {

    //SXOLIA : in order to work properly make a tag "Ground" and assign it to every surface that the player is able to jump from
    //apply grivity 4.4 to player so that he falls down quickly after jumping


    private int jumpingPower = 140;
    private int playerSpeed = 10;
    [HideInInspector]
    public static int points = 0;

    [HideInInspector]
    public static float bonusScore = 0;
    private float extraJumpPower = 30; //how much can the player jump when holding Space
    private float moveX; //controls the player on the x-axis
    private float timer = 100;

    private bool isGrounded; //checks if player is in touch with the ground
    private bool isDead = false;
    public Text pointsTxt; //coins etc. collected
    public Text bonusScoreTxt; //score that is added to the final points(it is a timer that gets multyplied by a value)
    public GameObject flytrapColliders;
    public GameObject tigerGameObject;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public Animator animator;
    private static PlayerControl instance;
    public static PlayerControl Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerControl>();
            }
            return instance;
        }
    }
    public bool Grounded { get; set; }
    public bool Dead { get; set; }

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveX = Input.GetAxis("Horizontal");
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        bonusScoreTxt.text = "Bonus Score: " + timer.ToString("0.00");

        Dead = isDead;
        Grounded = isGrounded;
        if (!isDead) { 
            PlayerMove();
        }
        
	}

    void FixedUpdate()
    {
        HandleLayers();
        HandleDead();
        if (rb.velocity.y < 0 && !isDead)
        {
            animator.SetBool("Land", true);
        }  
    }

    void PlayerMove()
    {
        //Basically what triggers the animation for running
        if (isGrounded && rb.velocity.x!=0)
        {
            animator.SetFloat("Speed", 1);
        }
        else if (rb.velocity.x == 0)
        {
            animator.SetFloat("Speed", 0);
        }   
        //MOVEMENT
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);

        //JUMP
        if (Input.GetKey(KeyCode.Space))
        {
            isGrounded = false;
            if (extraJumpPower > 0)
            {
                //Triggers the jumping animation
                animator.SetTrigger("Jump");
                rb.AddForce(Vector2.up * jumpingPower * Time.deltaTime, ForceMode2D.Impulse);
                extraJumpPower -= 10;
            }
        }

        //DIRECTION
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }
    //Switching between animation layers when player is on ground or not.
    void HandleLayers()
    {
        if (isGrounded)
        {
            animator.SetLayerWeight(1, 0);
        }
        else
        {
            animator.SetLayerWeight(1, 1);
        }
    }
    void HandleDead()
    {
        if (Dead)
        {
            animator.SetTrigger("Dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
            extraJumpPower = 100;
        }
       
       
    }
   
    public void OnRespawn()
    {
        Dead = isDead = false;
        animator.SetBool("Dead", false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Flytrap"))
        {
            StartCoroutine(Flytrap());
        }
        if (col.gameObject.CompareTag("Collectable"))
        {
            col.gameObject.SetActive(false);
            points++;
            pointsTxt.text = "Points Collected: " + points.ToString();
        }
        if (col.gameObject.tag.Equals("Tiger"))
        {
            tigerGameObject.SetActive(true);
        }
        //added a constrant that if the y axes of the player are greater than the object collided then it disables it and a point is added
        if (col.tag.ToLower().Contains("enemy") && col.transform.position.y < gameObject.transform.position.y)
        {
            col.gameObject.SetActive(false);
            points++;
        }
    }
  
    private IEnumerator Flytrap()
    {
        yield return new WaitForSeconds(0.1f);
        flytrapColliders.SetActive(true);
     //   GameObject.Find("Flytrap").transform.GetChild(0).gameObject.SetActive(true);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        if (moveX != 0)
        {
            isDead = true;
        }
        yield return new WaitForSeconds(1.5f);
       // GameObject.Find("Flytrap").transform.GetChild(0).gameObject.SetActive(false);
        flytrapColliders.SetActive(false);
    }
}
