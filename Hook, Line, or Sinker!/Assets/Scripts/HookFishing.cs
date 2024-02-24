using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HookFishing : MonoBehaviour
{
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    public float speed = 2f;
    public bool isReversing = false;
    public float stopDistance = 0.5f; // Adjust as needed
    public float targetYPosition = -38.5f; 
    // Start is called before the first frame update
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Slow down/Reverse direction at -38.5 y
       //Vector3 movement = Vector3.down * speed * Time.deltaTime;

        // Move the object
        //myRig.transform.Translate(movement);

        myRig.velocity = Vector2.down * speed;
        if (!isReversing && transform.position.y <= targetYPosition)
        {
            isReversing = true;
            // Reverse the direction
            speed *= -1f;
            //myRig.velocity *= -1f;
        }
        
    }
}
