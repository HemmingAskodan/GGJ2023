using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public float digSpeed = 5f;
    public float walkSpeed = 10f;
    public float angleSmoothTime = 0.1f;
    public SpriteRenderer characterSpriteRenderer;
    public bool isDigging = false;
    private float movementX, movementY;
    new Rigidbody2D rigidbody2D => GetComponent<Rigidbody2D>();
    private bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    float zVelocity;
    // Update is called once per frame
    void Update()
    {
        if ((transform.eulerAngles.z < 90 || transform.eulerAngles.z > 270) && isFlipped)
        {
            flip();
        }
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270 && !isFlipped)
        {
            flip();
        }
    }
    void FixedUpdate()
    {
        Vector2 axisInputs = new Vector2(movementX, movementY);
        if (axisInputs.magnitude > 1)
        {
            axisInputs.Normalize();
        }
        if (isDigging)
        {
            // Dig Logic

            rigidbody2D.AddForce(transform.right * digSpeed * axisInputs.magnitude);

            if (axisInputs.magnitude > 0)
            {
                float zAxis = Mathf.SmoothDampAngle(transform.eulerAngles.z, Mathf.Atan2(axisInputs.y, axisInputs.x) * Mathf.Rad2Deg, ref zVelocity, angleSmoothTime);
                transform.eulerAngles = new Vector3(0, 0, zAxis);
            }

            bool startWalking = transform.position.y > 0.25f;
            if(startWalking)
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Ground"),false);
                transform.rotation = Quaternion.identity;
                isDigging = false;
                rigidbody2D.gravityScale = 1;
            }
        }
        else
        {
            // Walk logic

            rigidbody2D.AddForce(transform.right*walkSpeed*new Vector2(axisInputs.x,0));

            bool startDig = axisInputs.y < -0.25f;
            if(startDig)
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Ground"),true);
                isDigging = true;
                rigidbody2D.gravityScale = 0;
            }
        }
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void flip()
    {
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        characterSpriteRenderer.flipY = !characterSpriteRenderer.flipY;
        isFlipped = !isFlipped;
    }
}
