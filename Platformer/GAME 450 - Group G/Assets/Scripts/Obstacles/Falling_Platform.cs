using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Platform : MonoBehaviour
{
    private Vector3 origPos;
    private bool isFalling;

    private void Start()
    {
        isFalling = false;
        origPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(!isFalling)
        {
            if (collision == null)
                return;
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                StartCoroutine(Fall());
            }
        }
    }

    private IEnumerator Fall()
    {

        yield return new WaitForSeconds(.5f);

        isFalling = true;

        //transform.GetComponent<Rigidbody2D>().gravityScale = 1;

        for(float i = 0; i < 5f; i += Time.deltaTime)
        {
            transform.Translate(new Vector2(0f, -1f) * Time.deltaTime);
            yield return null;
        }

        //yield return new WaitForSeconds(2f);

       // transform.GetComponent<Rigidbody2D>().gravityScale = 0;
        isFalling = false;
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = origPos;

    }
}
