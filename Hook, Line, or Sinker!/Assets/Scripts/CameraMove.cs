using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    public float speed = 2f;
    public bool isReversing = false;
    public float targetYPosition = -38.5f; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if camera should reverse direction
        if (!isReversing && transform.position.y <= targetYPosition)
        {
            isReversing = true;
            // Reverse the direction
            speed *= -1f;
        }
    }
}
