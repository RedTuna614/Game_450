using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public int dist;
    public int dir;
    public float speed;
    private float leftMax;
    private float rightMax;
    private Transform formerParent;

    private void Start()
    {
        if(dist == 0)
        {
            dist = 20;
        }
        if (dir != 1 || dir != 1)
        {
            dir = 1;
        }
        if(speed == 0)
        {
            speed = 20;
        }

        leftMax = (transform.position.x - dist);
        rightMax = (transform.position.x + dist);


    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);

        if(transform.position.x >= rightMax)
        {
            dir = -1;
        }
        if(transform.position.x <= leftMax)
        {
            dir = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision == null)
        {
            return;
        }
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            //collision.gameObject.attach
            formerParent = collision.transform.parent;
            collision.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision == null)
        {
            return;
        }
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            collision.transform.SetParent(formerParent, true);
        }
    }
}
