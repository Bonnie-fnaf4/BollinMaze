using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountMany : MonoBehaviour
{
    public int moneyCount = 1;
    int moneyGet = 0;

    public Text MoneyGetText;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= moneyCount; i++)
        {
            moneyGet += PlayerPrefs.GetInt("MoneyId" + i);
        }
        MoneyGetText.text = "Монет собрано " + moneyGet + " / " + moneyCount;
    }

    public void ClearMoney()
    {
        for (int i = 0; i <= moneyCount; i++)
        {
            PlayerPrefs.SetInt("MoneyId" + i, 0);
        }
        moneyGet = 0;
        for (int i = 0; i <= moneyCount; i++)
        {
            moneyGet += PlayerPrefs.GetInt("MoneyId" + i);
        }
        MoneyGetText.text = "Монет собрано " + moneyGet + " / " + moneyCount;
    }
}
