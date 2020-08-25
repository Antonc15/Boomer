using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI totalMoneyText;
    public int money;

    public void GainMoney(int income)
    {
        money += income;

        if (totalMoneyText != null)
            totalMoneyText.text = "$" + money;
    }
}
