﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breatheIn : MonoBehaviour
{
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("hide", 7f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void hide()
    {
        gameObject.SetActive(false);
    }

    void show()
    {
        gameObject.SetActive(true);
    }
}