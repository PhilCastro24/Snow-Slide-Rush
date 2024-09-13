using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    bool canMove = true;

    [SerializeField] float torqueAmount = 1f;

    [SerializeField] float normalSpeed = 20;
    [SerializeField] float boostSpeed = 30;

    [SerializeField] float jumpForce = 10f; // changed 10000 to 10f, because for some reason 10000 was not recognized as float number

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
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void Jump()
    {
        if (!myCapsuleCollider.IsTouchingLayers(groundLayer))
        {
            //Debug.Log("Player is not Touching the ground, cannot Jump");
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump detected");

            // rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // changed jump implementaion after changing variable on line 17
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce); 
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
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
