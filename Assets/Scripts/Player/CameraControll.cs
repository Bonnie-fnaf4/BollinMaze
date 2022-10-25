using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        Vector3 vector3 = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        transform.position = vector3;
    }
}
