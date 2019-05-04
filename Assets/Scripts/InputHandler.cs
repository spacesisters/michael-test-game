using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void FixedUpdate()
    {
        float input_horizontal = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(input_horizontal, 0, 0);

        rb.AddForce(force * speed);

    }
}
