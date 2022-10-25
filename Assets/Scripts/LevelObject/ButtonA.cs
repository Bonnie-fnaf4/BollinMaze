using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonA : MonoBehaviour
{
    public OpenDoorMany OPM; //Скрипт для обработки нажатия на кнопку A для скрипта OpenDoorMany

    private void OnTriggerEnter(Collider other) //Если игрок наехал на кнопку то запустить void в OpenDoorMany
    {
        OPM.a_Active();
    }
    private void OnCollisionEnter(Collision collision) //Если игрок наехал на кнопку то запустить void в OpenDoorMany
    {
        OPM.a_Active();
    }
}
