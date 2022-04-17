using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCycle : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float spinSpeed;
    public float linearSpeed;
    private Rigidbody2D rgb2d;
    private float startPosition;

    public GameObject Goblin;

    private bool isFlipping;
    private bool isStart;

    private float time;
    

    //public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        startPosition = rgb2d.position.x;
        isFlipping = false;
        isStart = true;


    }

    // Update is called once per frame
    void Update()
    {

        time = Time.timeSinceLevelLoad;

        if (isStart == true)
            StartCoroutine(Waiting());
        //Vector2 direction = (target.position - transform.position);
        if(isFlipping == false)
        {
            //if(Time.time % 3 == 0)
            //{
                isFlipping = true;
            StartCoroutine(Flipping());
            //}

            
        }

        
            rgb2d.MovePosition(new Vector2((Mathf.Sin((2 * Mathf.PI * (time * linearSpeed / distance)) - (Mathf.PI / 2)) * (distance / 2) + (distance / 2)) + startPosition, rgb2d.position.y));
        //rgb2d.SetRotation(rgb2d.rotation + spinSpeed * Time.fixedDeltaTime);


        //if (direction.x > 0)
        //    Flip();
        //else if (direction.x < 0)
        //    Flip();

    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);

        Goblin.GetComponent<SpriteRenderer>().sortingOrder = 1;

        isStart = false;
    }

    IEnumerator Flipping()
    {


        yield return new WaitForSeconds(5);

        isFlipping = false;
        Flip();
    }

    void Flip()
    {
        //facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
