using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondUpdate
{
    public void Upgrade(int BtnId, int numberUpdate)
    {
        
        switch (BtnId)
        {
            case 5:
                BowAttack bowPoint = GameObject.FindGameObjectWithTag("SecondBow").GetComponent<BowAttack>();
                bowPoint.SetActive();
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }
    }
}
