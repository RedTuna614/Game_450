using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform rightPoint;
    public Transform leftPoint;

    public int dir; //Direction that the enemy is moving
    private int pushForce = 400; //Force that the enemy pushes the player back
    private int movementSpeed = 10; //Speed that the enemy is moving
    private float rightEnd;
    private float leftEnd;

    private void Start()
    {
        if(dir != 1 && dir != -1)
        {
            dir = 1;
        }

        rightEnd = rightPoint.position.x;
        leftEnd = leftPoint.position.x;
    }

    private void Update()
    {
        transform.Translate(new Vector2(dir, 0) * movementSpeed * Time.deltaTime);

        if(transform.position.x >= rightEnd || 
            transform.position.x <= leftEnd)
        {
            dir *= -1;
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
            if(collision.gameObject.GetComponent<Player>().GetisAttacking())
            {
                GameManager.points += 50;
                GameManager.Main.GetComponent<Main>().UpdatePointsText();
                gameObject.SetActive(false);
            }
            else
            {
                /*
                GameManager.currentLives--;
                GameManager.Main.GetComponent<Main>().UpdateLifeText();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir, 1) * pushForce);
                dir *= -1;
                StartCoroutine(CoolDown());
                */

                GameManager.Main.GetComponent<Main>().PlayerDied();

            }
        }
    }


    private IEnumerator CoolDown()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
