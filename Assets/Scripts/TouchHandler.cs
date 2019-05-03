using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//The TouchHandler can only work on phones;

public class TouchHandler : MonoBehaviour
{
    public GameObject cam;
    public GameObject cameraEndPosition;
    public Image m_Image;
    public AudioSource song0;
    public AudioSource song1;
    public AudioSource song2;
    


    Camera mainCamera;

    Vector3 fp = Vector3.zero;
    Vector2 lp;

    float speed = 2.0f;
    bool moving = false;

    int currentScreen = 1;
        
    // value to modify for minimum drag distance to be a swipe
    float dragDistance = Screen.height * 0.15f;

    void Start()
    {        
        m_Image.CrossFadeAlpha(0, 2f, false);
        song0.Stop();
        song2.Stop();
    }

    void Awake() {
        mainCamera = cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        //https://gist.github.com/cuibonobo/09709c38b218e1f3fd0d
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                fp = touch.position;
                lp = touch.position;
            }
            if (touch.phase == TouchPhase.Ended){
                lp = touch.position;
                
                float xDistance = Mathf.Abs(lp.x - fp.x);
                float yDistance = Mathf.Abs(lp.y - fp.y);
                
                if (xDistance > dragDistance || yDistance > dragDistance){
                    // Check if the horizontal movement is greater than the vertical movement
                    if (xDistance > yDistance){
                        if (lp.x > fp.x) {   //Right swipe
                            Debug.Log("Right Swipe");
                            if(currentScreen > 0) {
                                StopCoroutine(fade());
                                cameraEndPosition.transform.position = cameraEndPosition.transform.position + new Vector3(-100,0,0);
                                currentScreen--;
                                StartCoroutine(fade());
                                if (currentScreen == 0){
                                    StartCoroutine(CrossFadeAudio(song1, song0, 2f, 1f));
                                }
                                else if (currentScreen == 1){
                                    StartCoroutine(CrossFadeAudio(song2, song1, 2f, 1f));
                                }

                            }
                        } else {   //Left swipe
                            Debug.Log("Left Swipe"); 
                            if(currentScreen < 2) {
                                StopCoroutine(fade());
                                cameraEndPosition.transform.position = cameraEndPosition.transform.position + new Vector3(100,0,0);
                                currentScreen++;
                                StartCoroutine(fade());
                                if (currentScreen == 1) {
                                    StartCoroutine(CrossFadeAudio(song0, song1, 2f, 1f));
                                }
                                else if(currentScreen == 2){
                                    StartCoroutine(CrossFadeAudio(song1, song2, 2f, 1f));
                                }
                            }
                            
                        }
                    } 
                } else {
                    // That was a tap!
                }
            }
            // Just do the one touch for now...
            break;
        }

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraEndPosition.transform.position, speed * Time.deltaTime);

    }

    IEnumerator fade() {
        m_Image.CrossFadeAlpha(1, 0.2f, false);
        yield return new WaitForSeconds(0.7f);
        m_Image.CrossFadeAlpha(0, 2f, false);
    }


    private IEnumerator CrossFadeAudio(AudioSource audioSource1, AudioSource audioSource2, float crossFadeTime, float audioSource2VolumeTarget)
    {
        float startAudioSource1Volume = audioSource1.volume;
    
        audioSource2.volume = 0f;
        audioSource2.Play();
    
        while (audioSource1.volume > 0f && audioSource2.volume < audioSource2VolumeTarget)
        {
            audioSource1.volume -= startAudioSource1Volume * Time.deltaTime / crossFadeTime;
            audioSource2.volume += audioSource2VolumeTarget * Time.deltaTime / crossFadeTime;
            yield return null;
        }
    
    }
}