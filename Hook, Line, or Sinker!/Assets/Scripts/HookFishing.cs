using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HookFishing : MonoBehaviour
{
    public Camera hookCamera;
    public GameObject gameManager;
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    public Collider2D boxCollider;
    public float speed = 3f;
    public bool isReversing = false;
    public bool mouseMove = true;
    public float targetYPosition = -38.5f; 
    // Start is called before the first frame update
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Fish"))
        {
            FishMove otherObject = other.gameObject.GetComponent<FishMove>();
            gameManager.GetComponent<DoNotDestroy>().fishCount += 1;
            Destroy(otherObject.gameObject);
        }
        else if(other.gameObject.CompareTag("Squid"))
        {
            FishMove otherObject = other.gameObject.GetComponent<FishMove>();
            gameManager.GetComponent<DoNotDestroy>().squidCount += 1;
            Destroy(otherObject.gameObject);
        }
        else if(other.gameObject.CompareTag("Swordfish"))
        {
            FishMove otherObject = other.gameObject.GetComponent<FishMove>();
            gameManager.GetComponent<DoNotDestroy>().swordCount += 1;
            Destroy(otherObject.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldMousePosition = hookCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        worldMousePosition.y = transform.position.y;
        //transform.position = new Vector2(worldMousePosition.x, transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, worldMousePosition, speed*Time.deltaTime);
    }
}
