using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public Slider time;
    private void Awake()
    {
    }

    void Start()
    {
        time.maxValue = 60;
        time.minValue = 0;
        time.wholeNumbers = false;
        time.value = time.maxValue;
        timer = time.value;
    }
    void Update()
    {
        if (time.value > time.minValue)
        {
            timer -= Time.deltaTime;
            time.value = timer;
        }
    }
}
