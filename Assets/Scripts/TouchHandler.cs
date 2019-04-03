using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TouchHandler : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject SphereOutline;
    public GameObject BreatheText;

    Animator sphereanim;
    Animator outlineanim;
    TMP_Text breatheText;

    float cycleTime = 14f;
    float counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        sphereanim = Sphere.GetComponent<Animator>();
        outlineanim = SphereOutline.GetComponent<Animator>();
        breatheText = BreatheText.GetComponent<TMP_Text>();
        //breatheText.alignment = TextAnchor.MiddleCenter;
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
                    counter = 0;
                    StartCoroutine("breathe");
                    sphereanim.Play("Looping",0,0f);
                    outlineanim.Play("OutlineLooping",0,0f);
                }
            }
        }
        
    }

    IEnumerator breathe()
    {
        while (counter < cycleTime)
        {
            if (counter < cycleTime/2)
            {
                breatheText.text = "Breathe In";
                breatheText.fontSize += .1f;
            }
            else if (counter <= cycleTime)
            {
                breatheText.text = "Breathe Out";
                breatheText.fontSize -= .1f;
            }
            counter += Time.deltaTime;
            yield return null;
        }
        
    }
}
