using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnimationEvent : MonoBehaviour
{
    public UIManager UM;
    // Start is called before the first frame update
    void Start()
    {
        UM.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEventWalk()
    {
        UM.OnEventWalk();
    }
}
