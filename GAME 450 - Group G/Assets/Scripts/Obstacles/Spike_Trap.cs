using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null)
            return;
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GameManager.Main.GetComponent<Main>().PlayerDied();

            //collision.transform.parent.GetComponent<Main>().PlayerDied();

            /*
            if(transform.rotation.Equals(180f) || transform.localScale.y == -1)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 300f);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            }
            */

        }
    }
}
