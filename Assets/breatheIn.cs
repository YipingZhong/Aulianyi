using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breatheIn : MonoBehaviour
{
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fakeAnim();
        }
    }


    void hide()
    {
        gameObject.SetActive(false);
    }

    void show()
    {
        gameObject.SetActive(true);
    }

    void fakeAnim()
    {
        Invoke("show", 0f);
        Invoke("hide", 7.5f);
        Invoke("show", 15f);
        Invoke("hide", 22.5f);
        Invoke("show", 30f);
        Invoke("hide", 37.5f);
        Invoke("show", 45f);
        Invoke("hide", 52.5f);
        Invoke("show", 60f);
        Invoke("hide", 67.5f);
    }
}