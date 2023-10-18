using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orccontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementspeed;
    public float inputhorizontal;
    public float jumpforce;
    private Animator playeranimtor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playeranimtor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveLateral();
        jump();
        
    }
    private void moveLateral()
    {
        inputhorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movementspeed * inputhorizontal, rb.velocity.y);
        if(inputhorizontal == 0) 
        {
            playeranimtor.SetBool("isWalking", false);
        }
        else
        {
            playeranimtor.SetBool("isWalking", true);
        }
        flipplayer(inputhorizontal);
    }
    private void flipplayer(float input)
    {
        if(input>0)
        {
            transform.localRotation =Quaternion.Euler(0,0,0); 
        }
        else if (input < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }
    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }
}
