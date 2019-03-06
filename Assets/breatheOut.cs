using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breatheOut : MonoBehaviour
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
        Invoke("hide", 0f);
        Invoke("show", 7.5f);
        Invoke("hide", 15f);
        Invoke("show", 22.5f);
        Invoke("hide", 30f);
        Invoke("show", 37.5f);
        Invoke("hide", 45f);
        Invoke("show", 52.5f);
        Invoke("hide", 60f);
        Invoke("show", 67.5f);
    }
}