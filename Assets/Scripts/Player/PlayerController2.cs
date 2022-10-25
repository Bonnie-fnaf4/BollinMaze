using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Transform Player;           //Скрипт находится не на игроке а значит ему нужно положение игрока для того что бы находится в его позиции

    //На самом деле скрипт работает так, у игрока его глобальный Rotation постоянно изменяет так как он катиться по физике
    //Объект PlayerRotation позволяет узнать вектор направления игрока так как его Rotation меняется только по Y
    //Это позволяет задавать вектор направления движения правильно

    public Transform CameraRotation; // Тут ещё одна прикольная механика

    //Когда игрок поворачивает камеру например налево и нажимает допустим на W, шарик всё равно поедет непосредственно прямо
    //Это нужно непосредственно для удобства игрока
    //Скрипт поворачивает PlayerRotation по Y Камеры которая привязанна к этому скрипту. То есть, будет у камеры Y = 10, у PlayerRotation тоже будет Y = 10

    public float speed = 10000f;              //Значение скорости, для настройки скорости через редактор Unity
    public Rigidbody RB;                      //Rigidbody нужен для того что бы задать вектор направления с помощью физики. Rigidbody у PlayerRotation нет, он берется у игрока и задается через Unity редактор
    public VariableJoystick variableJoystick; //Стик для управления шариком на мобильный устройствах
    public bool IsMobile = true;              //Переменная для проверки какое управление нужно использовать, Мобильное\Обычное

    void Start()
    {
        if(PlayerPrefs.GetInt("IsMobail") == 0)
        {
            IsMobile = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion quaternion = CameraRotation.rotation;
        quaternion.x = 0f;
        quaternion.z = 0f;
        transform.rotation = quaternion;
        transform.position = Player.position;
        if(IsMobile) StikController();
        if (Input.GetKey(KeyCode.W))
        {
            RB.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            RB.AddForce(-transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            RB.AddForce(-transform.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(transform.right * speed);
        }
    }

    void StikController()
    {
        Vector3 direction = transform.forward * variableJoystick.Vertical + transform.right * variableJoystick.Horizontal;
        RB.AddForce(direction * speed * 1.5f);
    }
}
