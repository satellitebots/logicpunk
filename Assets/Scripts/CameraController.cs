using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject playerCharacter;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerCharacter.transform.position;
    }

    public Vector3 GetOffset()
    {
        return offset;
    }

    // Update is called once per frame
    //void LateUpdate()
    //{
    //    transform.position = playerCharacter.transform.position + offset;
    //}
}
