using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
    }

    // Update is called once per frame
    void Update()
    {
        int nbTouches = Input.touchCount;
 
        if(nbTouches > 0)
        {
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);
 
                if(touch.phase == TouchPhase.Ended) {
                    print("released");
                }
            }
        }
        
    }
}
