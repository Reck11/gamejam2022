using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    [SerializeField] int nextBtn;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] objects;

    private void Start()
    {
        nextBtn = 0;
    }

    private void OnEnable()
    {
        nextBtn = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.SetSiblingIndex(Random.Range(0, 9));
        }
    }

    public void BtnOrder(int btn)
    {
        Debug.Log("Pressed");
        if (btn == nextBtn)
        {
            nextBtn++;
            Debug.Log("next button" + nextBtn);
        }
        else
        {
            Debug.Log("Fail");
            Debug.Log("next button" + nextBtn);
            nextBtn = 0;
            OnEnable();
        }

        if (btn == 9 && btn == nextBtn)
        {
            Debug.Log("Passed");
            nextBtn = 0;
            BtnOrderPanClose();
        }
    }

    void BtnOrderPanClose()
    {
        panel.SetActive(false);
    }

    void BtnOrderPanOpen()
    {
        panel.SetActive(true);
    }
}
