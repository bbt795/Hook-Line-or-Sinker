using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public Transform thisTransform;
    public float moveSpeed = 0.2f;

    public Vector2 decisionTime = new Vector2(1, 4);
    public float decisionTimeCount = 0;

    public Vector2[] moveDirections = new Vector2[] { Vector2.right, Vector2.left, Vector2.up, Vector2.down, Vector2.zero, Vector2.zero };
    public int currentMoveDirection;

    public SpriteRenderer spriteRenderer;

    public Collider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = this.transform;
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.position += (Vector3)moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;

        if (decisionTimeCount > 0)
        {
            decisionTimeCount -= Time.deltaTime;

            if (currentMoveDirection == 0)
            {
                spriteRenderer.flipX = false;
            }
            else if(currentMoveDirection == 1)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

            ChooseMoveDirection();
        }
    }

    void ChooseMoveDirection()
    {
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Output the message
            Debug.Log("hit a wall");
        }
    }
}
