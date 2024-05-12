using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] PopUps;
    private int index;
    private NeedVal znach;

    private void Start()
    {
        znach = JsonUtility.FromJson<NeedVal>(File.ReadAllText(Application.streamingAssetsPath + "/need.json"));
    }

    private void Update()
    {
        if (znach.Need == 0)
        {
            for (int i = 0; i < PopUps.Length; i++)
            {
                if (i == index)
                {
                    PopUps[i].SetActive(true);
                }
                else
                {
                    PopUps[i].SetActive(false);
                }
            }
        }
        
    }

    public class NeedVal
    {
        public int Need;
    }

}
