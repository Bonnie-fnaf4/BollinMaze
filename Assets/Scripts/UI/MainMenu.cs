using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Toggle InversX, InversY;          //Это галочки для инверсии управления камеры
    public Dropdown dropdown;                //Список уровней, заполняется через редактор Unity
    public CameraRotateController CRC;       //Скрипт управления камерой, нужен для отключения управления камеры на уровнях
    public bool IsMainMenu = true, IsMobile; //Булевые переменные который нужны что бы понять IsMobile какое управление обычное\мобильное, IsMainMenu используеться ли скрипт на уровне или же он используется в главном меню

    void Start()
    {
        bool a = false; //Булевая переменная которая задаёт своё значение в галочки Toggle InversX, InversY

        if (PlayerPrefs.GetInt("Invers") == 1 || PlayerPrefs.GetInt("Invers") == 3) a = true; // 1 Только X, 2 Только Y, 3 и X и Y
        InversX.isOn = a; //Включает выключает галочку в зависимости от значения a

        a = false;
        if (PlayerPrefs.GetInt("Invers") == 2 || PlayerPrefs.GetInt("Invers") == 3) a = true; //Данный механизм позволяет использовать одну Int Переменную для сохранения значений инверсии управления. К сожалению Bool PlayerPrefs не существует, использовал бы их
        InversY.isOn = a;

        if (PlayerPrefs.GetInt("IsMobail") == 0) IsMobile = false; //Преобразовывает PlayerPrefs.GetInt("IsMobail"), то есть значение int в bool
        else IsMobile = true;
    }


    void Update() //Update обрабатывает значение галочек Toggle, для того что бы сразу сохранять их значение в память что бы потом на уровне подгружать настройки инверсиии управления камеры
    {
        if (InversX.isOn == true && InversY.isOn == true) //Тут он проверяет какие галочки включены\выключенны
        {
            PlayerPrefs.SetInt("Invers", 3); //В зависимости от этого изменяет значение сохраняемой переменной в памяти
            if (!IsMainMenu) //Если используется скрипт на уровне то выключает\выключает инверсию напрямую у скрипта управления камеры
            {
                CRC.InvertX = true;
                CRC.InvertY = true;
            }
        }
        if (InversX.isOn == true && InversY.isOn == false) //Тоже самое что и выше, просто другие значения
        {
            PlayerPrefs.SetInt("Invers", 1);
            if (!IsMainMenu)
            {
                CRC.InvertX = true;
                CRC.InvertY = false;
            }
        }
        if (InversX.isOn == false && InversY.isOn == true) //Тоже самое что и выше, просто другие значения
        {
            PlayerPrefs.SetInt("Invers", 2);
            if (!IsMainMenu)
            {
                CRC.InvertX = false;
                CRC.InvertY = true;
            }
        }
        if (InversX.isOn == false && InversY.isOn == false) //Тоже самое что и выше, просто другие значения
        {
            PlayerPrefs.SetInt("Invers", 0);
            if (!IsMainMenu)
            {
                CRC.InvertX = false;
                CRC.InvertY = false;
            }
        }
    }
    public void StartLevel() //После выбора уровня в Dropdown, или же просто в списке, при нажатие на кнопку загружается уровень в соответствии с id сцены уровня dropdown.value + 1. + 1 потому что 1 это главное меню
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(dropdown.value + 1);
    }
    public void Continue() //Кнопка продолжить, возвращает время в нормальное состояние и включает управление, выключает панель меню на уровне и если управление не мобильное блокирует курсор
    {
        Time.timeScale = 1;
        CRC.ActiveRotate = true;
        gameObject.SetActive(false);
        if(!IsMobile)Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenuActive() //Кнопка вернуться в главное меню
    {
        SceneManager.LoadScene(0);
    }
}
