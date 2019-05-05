using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator player_animator;

    public float speed;

    private Rigidbody rb;

    private float input_horizontal;

    // Start is called before the first frame update
    void Start()
    {
        player_animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         input_horizontal = Input.GetAxis("Horizontal");

        if(input_horizontal > 0f)
        {
            player_animator.SetBool("player_walking", true);
            transform.rotation = Quaternion.Euler(0f, input_horizontal * -90f, 0);
        }
        else if(input_horizontal < 0f)
        {
            player_animator.SetBool("player_walking", true);
            transform.rotation = Quaternion.Euler(0f, input_horizontal * -90f, 0);
        }
        else 
        {
            player_animator.SetBool("player_walking", false);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        Vector3 force = new Vector3(input_horizontal, 0f, 0f);
        rb.AddForce(speed * force);
            

    }
}
