using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOutlineScript : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (null != anim)
            {
                anim.Play("OutlineLooping", 0, 0f);
            }
        }
    }

}
