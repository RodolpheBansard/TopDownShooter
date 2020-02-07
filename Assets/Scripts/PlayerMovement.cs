using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum State
    {
        normal,
        dashing,
        recovery
    };

    public float moveSpeed = 5f;

    public Rigidbody2D rigidbody;
    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePos;

    private Vector2 lookDir;
    private float angle;

    private bool isDashing = false;
    private bool isRecovering = false;

    public State state = State.normal;

    

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }    

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.normal:
                UpdateMovement();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = State.dashing;                    
                }
                break;

            case State.dashing:
                if (!isDashing)
                {
                    StartCoroutine(Dash());
                    isDashing = true;
                }               
                break;

            case State.recovery:
                UpdateMovement();
                if (!isRecovering)
                {
                    StartCoroutine(DashRecover());
                }
                break;

            default:
                break;
        }        
    }

    public State GetState()
    {
        return state;
    }

    private void UpdateMovement()
    {
        rigidbody.velocity = movement * moveSpeed;

        lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    

    IEnumerator Dash()
    {
        rigidbody.AddForce(transform.up * 40,ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        state = State.recovery;
        isDashing = false;
    }

    IEnumerator DashRecover()
    {
        yield return new WaitForSeconds(1);
        state = State.normal;
        isRecovering = false;
    }  
}
