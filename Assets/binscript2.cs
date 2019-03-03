using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binscript2 : MonoBehaviour
{
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 120)
        {
            gameObject.SetActive(false);
        }
        time++;
    }
}
