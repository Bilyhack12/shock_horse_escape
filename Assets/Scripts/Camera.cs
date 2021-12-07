using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static Camera Instance;
    private AudioSource audioSource; // players audio source variable
    
    void Awake(){
        Instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // init to audio source component
    }

    public void StartBackgroundMusic(){
        audioSource.Play();
    }

    public void StopBackgroundMusic(){
        audioSource.Stop();
    }

    public void Update(){
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
}
