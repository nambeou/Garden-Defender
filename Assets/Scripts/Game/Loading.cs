﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SceneLoader>().LoadToMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
