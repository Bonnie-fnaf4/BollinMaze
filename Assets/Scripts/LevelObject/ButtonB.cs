using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonB : MonoBehaviour
{
    public OpenDoorMany OPM; //Скрипт для обработки нажатия на кнопку B для скрипта OpenDoorMany

    private void OnTriggerEnter(Collider other) //Если игрок наехал на кнопку то запустить void в OpenDoorMany
    {
        OPM.b_Active();
    }
    private void OnCollisionEnter(Collision collision) //Если игрок наехал на кнопку то запустить void в OpenDoorMany
    {
        OPM.b_Active();
    }
}
