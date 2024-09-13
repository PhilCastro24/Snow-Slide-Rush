using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    bool canMove = true;

    [SerializeField] float tourgueAmount = 1f;
    [SerializeField] float normalSpeed = 20;
    [SerializeField] float BoostSpeed = 30;
    [SerializeField] float JumpForce = 10000;

    [SerializeField] LayerMask groundLayer;

    CapsuleCollider2D myCapsuleCollider;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        myCapsuleCollider = GetComponentInChildren<CapsuleCollider2D>();

    }


    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
            Jump();
        }
    }


    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(tourgueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-tourgueAmount);
        }
    }

    void Jump()
    {
        if (!myCapsuleCollider.IsTouchingLayers(groundLayer))
        {
            Debug.Log("Player is not Touching the ground, cannot Jump");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump detected");
            rb2d.AddForce(Vector2.up * JumpForce,ForceMode2D.Impulse);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = BoostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }
    public void DisableControls()
    {
        canMove = false;
    }
}
