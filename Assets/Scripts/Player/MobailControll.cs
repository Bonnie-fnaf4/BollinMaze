using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobailControll : MonoBehaviour
{
    public Vector2 startPos;
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
            {
            float pos = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - pos, -2.97f, 2.97f), transform.position.y, transform.position.z);
        }
    }
}
