using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll_script : MonoBehaviour
{
    private Animator animator;
    public float speed;
    public float jump_strength;

    private Rigidbody rb;
    private float input_horizontal, input_vertical;
    private bool ground_contact;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ground_contact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        input_horizontal = Input.GetAxis("Horizontal");
        input_vertical = Input.GetAxis("Vertical");


        if(ground_contact)
        {
            if(input_horizontal == 0)
            {
                animator.SetBool("walking", false);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                animator.SetBool("walking", true);
                transform.rotation = Quaternion.Euler(0f, input_horizontal * -90f, 0f);
            }
        }

        Vector3 force = new Vector3(input_horizontal, 0f, 0f);
        rb.AddForce(speed * force);

        if(input_vertical > 0f && ground_contact)
        {
            jump();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            ground_contact = true;
        }
    }

    void jump()
    {
        ground_contact = false;
        rb.AddForce(0f, jump_strength, 0f);
    }
}
