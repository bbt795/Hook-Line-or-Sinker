using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HookFishing : MonoBehaviour
{
    public Camera hookCamera;
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    public Collider2D boxCollider;
    public float speed = 2f;
    public bool isReversing = false;
    public float targetYPosition = -38.5f; 
    // Start is called before the first frame update
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Spaghetti");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Slow down/Reverse direction at -38.5 y
       //Vector3 movement = Vector3.down * speed * Time.deltaTime;

        // Move the object
        //myRig.transform.Translate(movement);

        // myRig.velocity = Vector2.down * speed;
        // if (!isReversing && transform.position.y <= targetYPosition)
        // {
        //     isReversing = true;
        //     // Reverse the direction
        //     speed *= -1f;
        //     //myRig.velocity *= -1f;
        // }
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldMousePosition = hookCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector2(worldMousePosition.x, transform.position.y);
        Debug.Log(worldMousePosition.x);
    }
}
