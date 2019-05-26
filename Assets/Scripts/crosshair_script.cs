using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair_script : MonoBehaviour
{
    public GameObject character;
    public Camera cam;

    private Vector3 crosshair_offset;

    // Start is called before the first frame update
    void Start()
    {
        crosshair_offset = new Vector3(5f,0f,0f);
        Vector3 crosshair_pos = character.transform.position;
        transform.position = cam.WorldToScreenPoint( crosshair_pos + crosshair_offset);
        Debug.Log(transform.position);
        
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 cursor_pos = (Input.mousePosition - Camera.main.WorldToScreenPoint(character.transform.position)).normalized;
        //Debug.Log(Vector3.SignedAngle(cursor_pos, transform.right, transform.forward));
        float aim_angle = Vector3.SignedAngle(cursor_pos, transform.forward, transform.right);
        crosshair_offset = new Vector3(5f,0f,0f);

        transform.position = cam.WorldToScreenPoint( character.transform.position + Quaternion.AngleAxis(-aim_angle, Vector3.right) * crosshair_offset);

        

        
    }
}
