using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void BeginButton(string beginbtn)
    {
        Initiate.Fade("SampleScene", Color.white, 2.0f);
// SceneManager.LoadScene(beginbtn);

    }
}
