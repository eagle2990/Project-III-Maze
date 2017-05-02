using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 
    private bool locked;
    private bool opening;
    private AudioSource audioSource;
    public AudioClip lockedSoundClip;
    public AudioClip openSoundClip;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float doorAnimationSpeed;

    private Quaternion leftDoorEndRotation;
    private Quaternion rightDoorEndRotation;
    void Start()
    {
        locked = true;
        opening = false;
        StartAudio();
        StartRotationAngles();
    }

    void Update()
    {
        if (opening)
        {
            leftDoor.transform.rotation = Quaternion.RotateTowards(leftDoor.transform.rotation, leftDoorEndRotation, Time.time * doorAnimationSpeed);
            rightDoor.transform.rotation = Quaternion.RotateTowards(rightDoor.transform.rotation, rightDoorEndRotation, Time.time * doorAnimationSpeed);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void OnDoorClicked()
    {
        if (!locked)
        {
            SwapClipAndPlay();
            opening = true;
        }
        else
        {
            audioSource.Play();
        }
    }

    public void Unlock()
    {
        locked = false;
    }

    private void StartAudio()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = lockedSoundClip;
    }

    private void SwapClipAndPlay()
    {
        audioSource.clip = openSoundClip;
        audioSource.Play();
    }
    
    private void StartRotationAngles()
    {
        leftDoorEndRotation = leftDoor.transform.rotation * Quaternion.Euler(0f, 0f, -90f);
        rightDoorEndRotation = rightDoor.transform.rotation * Quaternion.Euler(0f, 0f, 90f);
    }
}
