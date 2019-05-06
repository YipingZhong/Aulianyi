using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void BeginButton(string beginbtn)
    {
        Initiate.Fade("SampleScene", Color.black, .87f);
// SceneManager.LoadScene(beginbtn);

    }
}
