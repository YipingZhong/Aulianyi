using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    int time1 = 0;
    Color c = Color.blue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c = Color.Lerp(Color.blue, Color.green, time1/120);
        gameObject.GetComponent<Renderer>().material.color = c;
        print(time1);
        if (time1 < 120)
        {
            transform.localScale += new Vector3(0.05F, 0.05F, 0);
        }
        if (time1 > 120 && time1 < 240)
        {
            transform.localScale += new Vector3(-0.05F, -0.05F, 0);
        }
        time1++;
    }

}
