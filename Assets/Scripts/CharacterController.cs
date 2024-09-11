using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float cameraSpeed = 100f;
    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;
    private float cameraShift;

    public GameObject followCamera;
    //Uncomment line below when adding jump
    // private float movementZ

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
        cameraShift = cameraVector.x;

    }

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(movementX, 0.0f, movementY);
        rigidBody.AddForce(playerMovement * movementSpeed);
        Quaternion newRotation = Quaternion.Euler(45, cameraShift * cameraSpeed, 0);
        followCamera.transform.SetPositionAndRotation(transform.position + new Vector3(0, 9, -10), Quaternion.Slerp(followCamera.transform.rotation, newRotation, Time.deltaTime));
    }
}
