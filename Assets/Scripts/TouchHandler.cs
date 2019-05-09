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
    public Graphic t;
    public AudioSource song0;
    public AudioSource song1;
    public AudioSource song2;
    


    Camera mainCamera;

    Vector2 fp;
    Vector2 lp;
    Vector3 originalCameraPosition;

    float speed = 2.0f;

    int currentScreen = 1;
        
    bool userIsDragging = false;
    // value to modify for minimum drag distance to be a swipe
    float dragDistance = Screen.height * 0.25f;

    void Start()
    {        
        m_Image.CrossFadeAlpha(0, 2f, false);
        song0.Stop();
        song2.Stop();
        StartCoroutine(fadeUI());
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
                originalCameraPosition = mainCamera.transform.position;
            }
            if (touch.phase == TouchPhase.Moved) {
                // move camera directly (no animation!)
                userIsDragging = true;
                float x = (fp.x - touch.position.x)/100;
                cameraEndPosition.transform.position = originalCameraPosition + new Vector3(x, 0,0);
            }
            if (touch.phase == TouchPhase.Ended) {
                lp = touch.position;
                userIsDragging = false;
                
                float xDistance = Mathf.Abs(lp.x - fp.x);
                float yDistance = Mathf.Abs(lp.y - fp.y);

                cameraEndPosition.transform.position = originalCameraPosition;
                
                if (xDistance > dragDistance || yDistance > dragDistance){
                    // Check if the horizontal movement is greater than the vertical movement
                    if (xDistance > yDistance){
                        if (lp.x > fp.x) {   //Right swipe
                            if(currentScreen > 0) {
                                StopCoroutine(fade(m_Image));
                                StartCoroutine(fade(m_Image));
                                if (currentScreen == 1){
                                    StartCoroutine(CrossFadeAudio(song1,song0,2f,1f));
                                }
                                else if (currentScreen == 2){
                                    StartCoroutine(CrossFadeAudio(song2,song1,2f,1f));
                                }
                                currentScreen--;
                            }
                        } else {   //Left swipe
                            if(currentScreen < 2) {
                                StopCoroutine(fade(m_Image));
                                StartCoroutine(fade(m_Image));
                                if (currentScreen == 0){
                                    StartCoroutine(CrossFadeAudio(song0,song1,2f,1f));
                                }
                                else if (currentScreen == 1){
                                    StartCoroutine(CrossFadeAudio(song1,song2,2f,1f));
                                }
                                currentScreen++;
                            }
                            
                        }
                    } 
                }
            }
            // Just do the one touch for now...
            break;
        }

        if (!userIsDragging) {
            if (currentScreen == 0) {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(-100,7,0), speed * Time.deltaTime);
            }
            else if(currentScreen == 1) {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(0,7,0), speed * Time.deltaTime);
            }
            else if(currentScreen == 2) {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(100,7,0), speed * Time.deltaTime);
            }
        }
        else {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraEndPosition.transform.position, speed * Time.deltaTime);
        }
    }

    IEnumerator fade(Image g) {
        g.CrossFadeAlpha(1, 0.2f, false);
        yield return new WaitForSeconds(0.7f);
        g.CrossFadeAlpha(0, 2f, false);
    }

    IEnumerator fadeUI() {
        yield return new WaitForSeconds(3.0f);
        t.CrossFadeAlpha(0,2.0f,false);
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