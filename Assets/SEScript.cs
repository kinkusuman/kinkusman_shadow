using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip SE1;
    public AudioClip SE2;
    public AudioClip SE3;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            audioSource.PlayOneShot(SE1);
        }
        if (Input.GetKey(KeyCode.B))
        {
            audioSource.PlayOneShot(SE2);
        }
        if (Input.GetKey(KeyCode.C))
        {
            audioSource.PlayOneShot(SE3);
        }
        
    }
}
