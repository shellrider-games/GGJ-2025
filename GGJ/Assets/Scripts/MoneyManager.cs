using System;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int Money { get; private set; } = 10;
    private TextMeshProUGUI _moneyField;
    private void Start()
    {
        _moneyField = GameObject.Find("MoneyField").GetComponent<TextMeshProUGUI>();
        _moneyField.SetText("Money: "+Money);
        CollectPlant.collectedPlant += () => { AddMoney(1); };
    }

    public void AddMoney(int money)
    {
        Money += money;
        _moneyField.SetText("Money: "+Money);
    }

    public bool RemoveMoney(int money)
    {
        if (0 <= (Money - money))
        {
            Money -= money;
            _moneyField.SetText("Money: "+Money);
            return true;
        }
        return false;
    }
}
