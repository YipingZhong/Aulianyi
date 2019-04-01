using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject SphereOutline;
    Animator sphereanim;
    Animator outlineanim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        sphereanim = Sphere.GetComponent<Animator>();
        outlineanim = SphereOutline.GetComponent<Animator>();
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
                    sphereanim.Play("Looping",0,0f);
                    outlineanim.Play("OutlineLooping",0,0f);
                }
            }
        }
        
    }
}
