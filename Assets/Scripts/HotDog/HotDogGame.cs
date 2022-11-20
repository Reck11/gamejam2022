using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogGame : MonoBehaviour
{

    public List<HotDogPoint> hotDogPoints = new List<HotDogPoint>();

    public float countMax = 0.5f;

    private int currentPointIndex = 0;

    private float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        if (currentPointIndex != 0 && count <= 0)
        {
            currentPointIndex = 0;
            Debug.Log("Error");
        }
    }

    public void HotDogPointTrigger(HotDogPoint hotDogPoint)
    {
        if (hotDogPoint == hotDogPoints[currentPointIndex])
        {
            currentPointIndex++;
            count = countMax;
        }

        if (currentPointIndex >= hotDogPoints.Count)
        {
            currentPointIndex = 0;
            Debug.Log("Finished");
        }
    }
}
