using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpendMoney : MonoBehaviour
{
    [SerializeField] int[] prices;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] Button btn;
    [SerializeField] GameObject endText;

    private int newPriceIndex=0;

    private void Start()
    {
        priceText.text = prices[0].ToString();
    }

    public void Spend(int BtnId)
    {
        Tower tower = GameObject.FindGameObjectWithTag("Tower").GetComponent<Tower>();
        int allMoney = tower.money;

        FirstUpgrade upgrade = new FirstUpgrade();

        bool suc = Int32.TryParse(priceText.text, out int needMoney);
        if (suc)
        {
            if (allMoney >= needMoney)
            {
                tower.money -= needMoney;
                newPriceIndex += 1;
                if (newPriceIndex < prices.Length)
                {
                    priceText.text = prices[newPriceIndex].ToString();
                }
                else
                {
                    btn.gameObject.SetActive(false);
                    endText.SetActive(true);
                }

                if (newPriceIndex <= prices.Length) upgrade.Upgrade(BtnId);
            }
        }
        tower.moneyUpdate();
    }
}
