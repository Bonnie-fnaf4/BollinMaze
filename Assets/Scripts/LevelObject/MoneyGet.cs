using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGet : MonoBehaviour
{
    Animator ani;
    public int idMoney;
    public GameObject Effect, Prefab;
    private void Start()
    {
        if(PlayerPrefs.GetInt("MoneyId" + idMoney) == 1)
        {
            Destroy(gameObject);
        }
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(!(idMoney == 0))
            {
                PlayerPrefs.SetInt("MoneyId" + idMoney, 1);
                ani.SetTrigger("Get");
                Effect.SetActive(true);
                Destroy(Effect, 5);
                Destroy(Prefab, 7);
                Destroy(gameObject, 4);
            }
        }
    }
}
