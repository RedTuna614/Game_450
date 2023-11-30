using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float jumpForce;
    private float dashForce;
    private int jumpCount;
    private bool isSprinting;
    private bool isDashing;
    private bool isSliding;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(!isSprinting)
            {
                isSprinting = true;
                GameManager.playerMovementSpeed *= 2;
            }
        }
        else
        {
            if(isSprinting)
            {
                isSprinting = false;
                GameManager.playerMovementSpeed /= 2;
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * GameManager.playerMovementSpeed * Time.deltaTime);
            if(isSliding)
            {
                GetComponent<Rigidbody2D>().velocity += (Vector2.right * GameManager.playerMovementSpeed * Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * GameManager.playerMovementSpeed * Time.deltaTime);
            if(isSliding)
            {
                GetComponent<Rigidbody2D>().velocity += (Vector2.left * GameManager.playerMovementSpeed * Time.deltaTime);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * jumpCount);
        }
        if(Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            StartCoroutine(Dash(1));
        }
        if(Input.GetKeyDown(KeyCode.Q) && !isDashing)
        {
            StartCoroutine(Dash(-1));
        }

        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(Attack());
        }

    }

    public void SetisSliding(bool newSlide)
    {
        isSliding = newSlide;
    }

    public bool GetisAttacking()
    {
        return isAttacking;
    }

    public void ResetVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void ResetPlayer()
    {
        //GameManager.Reset();
        dashForce = 500f;
        GameManager.playerMovementSpeed = 10f;
        jumpCount = 0;
        jumpForce = 200f;
        isSprinting = false;
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == null)
        {
            return;
        }
        else
        {
            jumpCount = 0;
        }
    }

    private IEnumerator Dash(int dir)
    {
        GetComponent<Rigidbody2D>().AddForce((new Vector2(dir, 0)) * dashForce);
        isDashing = true;

        yield return new WaitForSeconds(0.25f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isDashing = false;
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2f);

        isAttacking = false;
    }

}
