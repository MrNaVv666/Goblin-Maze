using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private bool isMoving;
    private bool canJump;
    private float playerSpeed = 0.5f;
    private float rotationSpeed = 4f;
    private float jumpForce = 3f;
    private float moveHorizontal, moveVertical;
    private float rotY;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject damagePoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        rotY = transform.localRotation.eulerAngles.y;
    }

    void Update()
    {
        GetKeyboardInput();
        AnimatePlayer();
        Attack();
        IsOnGround();
        Jump();
    }

    private void FixedUpdate()
    {
        MoveAndRotate();
    }

    void GetKeyboardInput()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            moveHorizontal = -1;
        }

        if (Input.GetKeyUp(KeyCode.A) && moveHorizontal != 1)
        {
            moveHorizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveHorizontal = 1;
        }

        if (Input.GetKeyUp(KeyCode.D) && moveHorizontal != -1)
        {
            moveHorizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveVertical = 1;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            moveVertical = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveVertical = -1;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            moveVertical = 0;
        }
    }

    void MoveAndRotate()
    {
        if (moveVertical != 0)
        {
            rb.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
        }

        rotY += moveHorizontal * rotationSpeed;
        rb.rotation = Quaternion.Euler(0f, rotY, 0f);
    }

    void AnimatePlayer()
    {
        if (moveVertical !=0)
        {
            if(!isMoving)
            {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.RUN_ANIMATION))
                {
                    isMoving = true;
                    animator.SetTrigger(Tags.RUN_ANIMATION);
                }
            }
        } else
        {
            if (isMoving)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.RUN_ANIMATION))
                {
                    isMoving = false;
                    animator.SetTrigger(Tags.STOP_TRIGGER);
                }
            }
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.ATTACK_ANIMATION) || !animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.RUN_ATTACK_ANIMATION))
            {
                animator.SetTrigger(Tags.ATTACK_TRIGGER);
            }
        }
    }

    void IsOnGround()
    {
        canJump = Physics.Raycast(groundCheck.position, Vector3.down, 0.2f, groundLayer);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                rb.MovePosition(transform.position + transform.up * (jumpForce * playerSpeed));
                animator.SetTrigger(Tags.JUMP_TRIGGER);
            }
        }
    }

    void ActivateDamagePoint()
    {
        damagePoint.SetActive(true);
    }

    void DeactivateDamagePoint()
    {
        damagePoint.SetActive(false);
    }
}
