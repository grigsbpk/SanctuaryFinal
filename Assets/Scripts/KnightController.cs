using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    public NPCDialogue CurrentNPC;

    

    public GameObject TextBox;
    public GameObject NPCName;
    public GameObject NPCName2;
    public GameObject DialogueText;
    public GameObject Continue;

    public GameObject InteractPrompt;
    public GameObject InteractPrompt2;


    public bool isEnemyTrigger;
    public bool isInTrigger;
    public bool isInteracting;
    public bool isTalking;
    public bool isStaying;
    public bool isOver;

    public bool isMoving;

    Vector2 oldPosition;

    public bool facingRight = true;

    public float speed = 3.0f;
    public Animator animator;

    SpriteRenderer renderer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    float any;
    bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        isAttacking = Input.GetButton("Fire1");
        isInteracting = Input.GetButton("Interact");

        any = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        
    }

    private void FixedUpdate()
    {


        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        animator.SetFloat("Speed", Mathf.Abs(any));
        animator.SetBool("Attack", isAttacking);
        

        if (horizontal > 0 && !facingRight)
            Flip();
        else if (horizontal < 0 && facingRight)
            Flip();

        //needs to not continuously call and instead just initiate convo once
        if (isInTrigger == true && isInteracting == true)
        {
            
                DialogueControl();
                Debug.Log("NPC");
             
        }
        else if (isEnemyTrigger == true && isInteracting == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
        }
        else if (isOver == true)
        {
            

            TextBox.SetActive(false);
            NPCName.SetActive(false);
            NPCName2.SetActive(false);
            DialogueText.SetActive(false);
            Continue.SetActive(false);

        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "NPC")
        {
            InteractPrompt.SetActive(true);
            InteractPrompt2.SetActive(true);

            if (isStaying == true)
                return;

            isInTrigger = true;
        }
        else if(collision.tag == "Enemy")
        {
            InteractPrompt.SetActive(true);
            InteractPrompt2.SetActive(true);

            if (isStaying == true)
                return;

            isEnemyTrigger = true;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isStaying = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractPrompt.SetActive(false);
        InteractPrompt2.SetActive(false);

        isEnemyTrigger = false;
        isInTrigger = false;
        isStaying = false;
        isOver = true;
    }

    private void DialogueControl()
    {
        isOver = false;
        TextBox.SetActive(true);
        NPCName.SetActive(true);
        NPCName2.SetActive(true);
        DialogueText.SetActive(true);
        Continue.SetActive(true);

        

        if (isTalking == true)
            return;

        CurrentNPC.isInteracting = true;

        isTalking = true;
    }
    
}
