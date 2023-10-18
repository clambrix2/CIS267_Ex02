using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private bool moveleft;
    public float movementspeed;
    private float startposx;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        moveleft = false;
        startposx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }
    private void movePlatform()
    {
        if(moveleft)
        {
            transform.Translate(Vector2.left * movementspeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * movementspeed * Time.deltaTime);
        }

        if(transform.position.x >= startposx) 
        {
            moveleft = true;
        }
        if(transform.position.x <= startposx - offset)
        {
            moveleft = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Orc"))
        {
            collision.transform.parent = gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Orc"))
        {
            collision.transform.parent = null;
        }
    }
}
