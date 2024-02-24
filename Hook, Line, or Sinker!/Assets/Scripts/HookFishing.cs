using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HookFishing : MonoBehaviour
{
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
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
        myRig.velocity = new Vector2(0, -3);
        
    }
}
