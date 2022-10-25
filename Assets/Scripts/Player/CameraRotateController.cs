using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraRotateController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public float xRotation = 40, yRotation = 0, zRotation = 0;
    public float yRotationCheck;
    public Camera mainCamera;
    public Quaternion quaternion;
    public bool IsMobail = true;

    public bool pressed = false;
    private int fingerId;
    public float sensitivity;

    public Transform CameraRotate;

    public bool InvertX = false, InvertY = false;

    public Vector3 origin, direction, directionOld;

    public bool ActiveRotate = true;

    void Start()
    {
        direction = Vector3.zero;
        directionOld = Vector3.zero;
        if (PlayerPrefs.GetInt("IsMobail") == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            IsMobail = false;
        }
        if (PlayerPrefs.GetInt("Invers") == 1 || PlayerPrefs.GetInt("Invers") == 3) InvertX = true;
        else InvertX = false;
        if (PlayerPrefs.GetInt("Invers") == 2 || PlayerPrefs.GetInt("Invers") == 3) InvertY = true;
        else InvertY = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        origin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = eventData.position;
        Vector3 directionRaw = currentPosition - origin;
        direction = directionRaw + directionOld;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (direction.y / 10 <= -10 || direction.y / 10 >= 50)
        {
            if (direction.y / 10 <= -10) direction = new Vector3(direction.x, -10 * 10, 0);
            if (direction.y / 10 >= 50) direction = new Vector3(direction.x, 50 * 10, 0);
        }
        directionOld = new Vector3(direction.x, direction.y, 0);
        direction = directionOld;
    }

    void Update()
    {
        if (ActiveRotate)
        {
            Rotate();
        }
    }
    void Rotate()
    {
        if (IsMobail)
        {
            yRotationCheck = yRotation;

            if (InvertY) yRotation = direction.y / 10 * -1;
            else yRotation = direction.y / 10;

            if (InvertX) xRotation = direction.x / 10 * -1;
            else xRotation = direction.x / 10;

            if (yRotation <= -10 || yRotation >= 50)
            {
                yRotation = yRotationCheck;
            }

            CameraRotate.rotation = Quaternion.Euler(yRotation, xRotation, 1);
        }
        else
        {
            yRotationCheck = yRotation;

            if (InvertX) xRotation -= Input.GetAxis("Mouse X");
            else xRotation += Input.GetAxis("Mouse X");

            if (InvertY) yRotation -= Input.GetAxis("Mouse Y");
            else yRotation += Input.GetAxis("Mouse Y");

            if (yRotation <= -10 || yRotation >= 50)
            {
                yRotation = yRotationCheck;
            }

            CameraRotate.rotation = Quaternion.Euler(yRotation, xRotation, 1);
        }
    }
}
