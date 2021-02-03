using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Duration of the level in seconds")]
    [SerializeField] int levelTimer = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad/ levelTimer;
    }

    public float GetLevelRemainingTime() {
        float remainingTime = levelTimer - Time.timeSinceLevelLoad;
        return remainingTime >= 0 ? remainingTime : 0;
    }

}
