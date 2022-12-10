using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float walkSpeed = 10f;//Controls velocity multiplier
    [SerializeField]
    private float runSpeed = 10f;

    private float forwardMovement;
    private float rotationMovement;
    Rigidbody rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script
    Animator playerAnimator;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //movement = new Vector3(rotationMovement, 0, forwardMovement).normalized;

    }
    private void Move()
    {
        forwardMovement = Input.GetAxis("Vertical"); // w key changes value to 1, s key changes value to -1
        rotationMovement = Input.GetAxis("Horizontal"); // d key changes value to 1, a key changes value to -1
        movement = new Vector3(rotationMovement, 0, forwardMovement).normalized;
        movement = transform.TransformDirection(movement);

    }
    void FixedUpdate()
    {

        if (transform.InverseTransformDirection(movement).z >= 0)
        {

            playerAnimator.SetBool("isRunningBackward", false);
            if (movement != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walking();
            }
            else if (movement != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Running();
            }
            else if (movement == Vector3.zero)
            {
                Idle();
            }
            moveCharacter(movement);
        }
        else
        {

            playerAnimator.SetBool("isRunningBackward", true);
            moveCharacter(movement);
        }
    }


    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
        //rb.velocity = direction* moveSpeed*Time.fixedDeltaTime;
    }
    private void Idle()
    {
        playerAnimator.SetFloat("Speed", 0, 0.1f, Time.fixedDeltaTime);
    }
    private void Walking()
    {
        moveSpeed = walkSpeed;
        playerAnimator.SetFloat("Speed", 0.5f, 0.1f, Time.fixedDeltaTime);
    }
    private void Running()
    {
        moveSpeed = runSpeed;
        playerAnimator.SetFloat("Speed", 1f, 0.1f, Time.fixedDeltaTime);
    }
}
