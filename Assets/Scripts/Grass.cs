using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    private Animator anim;
    public AnimationClip deSpawnClip;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
