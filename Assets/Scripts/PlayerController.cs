using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 20f;
    public Rigidbody2D rb;
    public float direction;
    public float jumpForce = 300f;
    public SpriteRenderer sprite;

 
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
  
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }   
    public void Attack()
    {
        animator.SetTrigger("isAttack");
    }

}
