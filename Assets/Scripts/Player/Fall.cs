using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    Transform startTransform;
    public Vector3 vector3;

    Rigidbody RB;
    void Start()
    {
        startTransform = transform;
        RB = GetComponent<Rigidbody>();
        vector3 = startTransform.position;
    }

    void Update()
    {
        if(transform.position.y < -50f)
        {
            transform.position = vector3;
            RB.velocity = new Vector3(0,0,0);
        }
    }
}
