using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AnimationClip Walk;

    private float jumpForce;
    private float dashForce;
    private int jumpCount;
    private bool isSprinting;
    private bool isDashing;
    private bool isSliding;
    private bool isAttacking;
    private bool isWalking;

    private string currentAnim;
    private string[] Anims;

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

                GetComponent<Animator>().speed = 2;
            }
        }
        else
        {
            if(isSprinting)
            {
                isSprinting = false;
                GameManager.playerMovementSpeed /= 2;

                GetComponent<Animator>().speed = 1;
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * GameManager.playerMovementSpeed * Time.deltaTime);
            if(isSliding)
            {
                GetComponent<Rigidbody2D>().velocity += (Vector2.right * GameManager.playerMovementSpeed * Time.deltaTime);
            }

            GetComponent<Animator>().SetBool("Is_Moving", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * GameManager.playerMovementSpeed * Time.deltaTime);
            if(isSliding)
            {
                GetComponent<Rigidbody2D>().velocity += (Vector2.left * GameManager.playerMovementSpeed * Time.deltaTime);
            }
            GetComponent<Animator>().SetBool("Is_Moving", true);

            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * jumpCount);
            GetComponent<Animator>().SetBool("Is_Moving", true);
        }
        if(Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            GetComponent<Animator>().SetBool("Is_Moving", true);
            StartCoroutine(Dash(1));
        }
        if(Input.GetKeyDown(KeyCode.Q) && !isDashing)
        {
            GetComponent<Animator>().SetBool("Is_Moving", true);
            StartCoroutine(Dash(-1));
        }
        
        if(!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            GetComponent<Animator>().SetBool("Is_Moving", false);
            isWalking =false;
        }

        if (Input.GetKeyDown(KeyCode.W) && !isAttacking)
        {
            isAttacking = true;
            GetComponent<Animator>().SetBool("IsAttacking", true);
            GetComponent<Animator>().Play("Attack_Anim");
            StartCoroutine(Attack());
        }

        PlayAnim();
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
        isWalking = false;

        Anims = new string[] {"Walk_Anim", "Idle_Anim", "Attack_Anim" };
        PlayAnim();
    }

    private void PlayAnim()
    {
/*
        if(isAttacking && currentAnim != Anims[2])
        {
            currentAnim = Anims[2];
            GetComponent<Animator>().Play(Anims[2], 0);
        }
        else if(isWalking && currentAnim != Anims[0])
        {
            currentAnim = Anims[0];
            Debug.Log("Waslk");
            GetComponent<Animator>().Play(Anims[0], 0);
        }
        else if(currentAnim != Anims[1])
        {
            currentAnim = Anims[1];
            Debug.Log("Idle");
            GetComponent<Animator>().Play("Idle_Anim", 0);
            GetComponent<Animator>().Play(0);
        }
*/
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
        yield return new WaitForSeconds(0.25f);

        isAttacking = false;

        GetComponent<Animator>().SetBool("IsAttacking", false);

        PlayAnim();
    }

}
