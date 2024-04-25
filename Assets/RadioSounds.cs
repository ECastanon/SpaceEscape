using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSounds : MonoBehaviour
{
    private Transform VoiceOverManager;
    [SerializeField] private List<AudioSource> voices = new List<AudioSource>();

    //WaitingData
    private float waitingTime;
    private bool hasWaited1;
    private bool hasWaited2;

    //Picked Up Data
    public bool isPickedUp;
    public bool firstRoomVoiceRead;
    public Vector3 pos;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        VoiceOverManager = GameObject.Find("VoiceOverManager").transform;
        foreach(Transform child in VoiceOverManager)
        {
            voices.Add(child.GetComponent<AudioSource>());
        }

        Invoke("IntroVoice", 3f);
    }
    private void Update()
    {
        waitingTime += Time.deltaTime;
        if (waitingTime > 13 && !hasWaited1)
        {
            WaitVoice1();
            hasWaited1 = true;
        }
        if (waitingTime > 23 && !hasWaited2)
        {
            WaitVoice2();
            hasWaited2 = true;
        }

        if (!firstRoomVoiceRead)
        {
            if (pos != new Vector3(transform.position.x, transform.position.y, transform.position.z))
            {
                rb.isKinematic = false;
                Objective();
                Invoke("FirstPuzzle", 19);
                firstRoomVoiceRead = true;
            }
        }
        else
        {
            waitingTime = 0;
        }
    }

    private void IntroVoice()
    {
        voices[0].Play();
    }
    private void WaitVoice1()
    {
        voices[4].Play();
    }
    private void WaitVoice2()
    {
        voices[5].Play();
    }
    private void Objective()
    {
        voices[3].Play();
    }
    private void FirstPuzzle()
    {
        voices[1].Play();
    }
}
