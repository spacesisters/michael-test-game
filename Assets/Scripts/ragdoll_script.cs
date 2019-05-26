using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class ragdoll_script : MonoBehaviour
{
    public float speed;
    public float jump_strength;

    private Animator animator;
    private Rigidbody rb;
    private float input_horizontal, input_vertical;
    private bool ground_contact;

    public InputMaster controls;

    private void OnEnable()
    {
        controls = new InputMaster();
        controls.Enable();
        controls.gameplay.movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Move(Vector2 move_vec)
    {
        Debug.Log(move_vec);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ground_contact = true;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 cursor_point = hit.point;
            cursor_point.z = transform.position.z;

            float aim_angle = Vector3.SignedAngle(cursor_point - transform.position, transform.forward, transform.up);

        }
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
            }
            else 
            {
                animator.SetBool("walking", true);
                if(input_horizontal < 0)
                    transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                else if(input_horizontal > 0)
                    transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
        }

        Vector3 force = new Vector3(input_horizontal, 0f, 0f);
        rb.AddForce(speed * force, ForceMode.VelocityChange);

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
        rb.AddForce(0f, jump_strength, 0f, ForceMode.VelocityChange);
    }
}
