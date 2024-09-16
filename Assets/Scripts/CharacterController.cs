using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float cameraSpeed = 1000f;
    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;
    private float cameraShift;

    public GameObject followCamera;
    //Uncomment line below when adding jump
    // private float movementZ

    public float JumpForce = 10;
    //!!! IsGrounded and groundContactCount concepts were copied from the 'BasicControlScript.cs' provided in the milestones !!!
    private int groundContactCount = 0;
    public bool IsGrounded
    {
        get
        {
            return groundContactCount > 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnLook(InputValue cameraValue)
    {
        Vector2 cameraVector = cameraValue.Get<Vector2>();
        cameraShift = Mathf.Clamp(cameraVector.x, -1, 1);
    }

    private void LateUpdate()
    {
        Quaternion newRotation = Quaternion.Euler(0, cameraShift * cameraSpeed, 0);
        followCamera.transform.RotateAround(transform.position, Vector3.up, cameraShift * cameraSpeed );
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && IsGrounded){
            rigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(movementX, 0.0f, movementY);
        //Quaternion cameraDirection = followCamera.transform.rotation;
        //Debug.Log(cameraDirection);
        //playerMovement = playerMovement.;
        rigidBody.AddForce(playerMovement * movementSpeed);
    }

    //!!! The OnCollisionEnter and OnCollisionExit updates were copied from the 'BasicControlScript.cs' provided in the milestones !!!
    //This is a physics callback
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject.tag == "ground")
        {
            ++groundContactCount;         
        }
						
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "ground")
        {
            --groundContactCount;
        }
    }

}


