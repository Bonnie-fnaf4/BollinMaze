using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    Rigidbody RB;
    public int LevelLoad;
    float Timer;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(RB.isKinematic == false)
        {
            Timer += Time.deltaTime;
        }
        if(Timer > 2)
        {
            if (LevelLoad == 0) Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(LevelLoad);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        RB.isKinematic = false;
    }
}
