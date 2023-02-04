using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DigController : MonoBehaviour
{

    public float digSpeed = 5f;
    
    public float angleSmoothTime = 0.1f;

    Rigidbody2D rigidbody2D => GetComponent<Rigidbody2D>();

    // Start is called before the first frame update
    void Start()
    {
    }

    float zVelocity;
    // Update is called once per frame
    void FixedUpdate()
    {
        print(Input.GetAxis("Horizontal")+","+Input.GetAxis("Vertical"));
        print(Input.GetAxisRaw("Horizontal")+","+Input.GetAxisRaw("Vertical"));
        
        Vector2 axisInputs = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        if(axisInputs.magnitude > 1)
        {
            axisInputs.Normalize();
        }
        
        // rigidbody2D.AddForce(axisInputs*digSpeed);
        rigidbody2D.AddForce(transform.right*digSpeed*axisInputs.magnitude);

        if(axisInputs.magnitude > 0)
        {
            float zAxis = Mathf.SmoothDampAngle(transform.eulerAngles.z, Mathf.Atan2(axisInputs.y, axisInputs.x) * Mathf.Rad2Deg,ref zVelocity, angleSmoothTime);
            transform.eulerAngles = new Vector3(0, 0, zAxis);
        }
    }
}
