using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class Numbers : MonoBehaviour
{
    [SerializeField] int nextBtn;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] objects;
    [SerializeField]
    private GameObject station;

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

        if (nextBtn == 10)
        {
            station.GetComponent<Task>().EndTask();
            nextBtn = 0;
            panel.SetActive(false);
        }
    }
}
