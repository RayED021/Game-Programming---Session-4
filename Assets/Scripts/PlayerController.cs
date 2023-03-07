using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 20f;
    public Rigidbody2D rb;
    public float direction;
    public float jumpForce = 300f;
    public SpriteRenderer sprite;
    public Collider2D coll;
    public bool isGrounded;
    public RawImage img;
    public LoadScene load;

 
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        img.gameObject.SetActive(false);
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.position = new Vector2(rb.position.x + direction * speed * Time.deltaTime, rb.position.y);

        if(direction <  0)
        {
            sprite.flipX = true;
        }
        else if(direction == 0)
        {

        }
        else
        {
            sprite.flipX = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }*/

        //if(coll.IsTouching())

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }

        //InvokeVideo();

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Attack()
    {
        animator.SetTrigger("isAttack");
    }

    public void InvokeVideo()
    {
        Invoke("PlayVideo", 2f);
    }

    public void PlayVideo()
    {
        img.gameObject.SetActive(true);
    }

    public void ChangeScene()
    {
        StartCoroutine("Scene");
    }

    public IEnumerator Scene()
    {
        yield return new WaitForSeconds(3f);
        load.ChangeMyScene("Menu");
    }

}
