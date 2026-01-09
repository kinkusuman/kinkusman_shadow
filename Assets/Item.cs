using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private int HealingItemCount = 0;
    AudioSource audioSource;
    public AudioClip SE1;

    // Start is called before the first frame update
    void Start()
    {
    audioSource = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        print(HealingItemCount);

        if(Input.GetKeyDown(KeyCode.B)&& HealingItemCount >= 1)//Input.GetMouseButtonDown(1) 
        {
            HealingItemCount -= 1;

            HealthManager.playerHP += 20;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HealingItem")
        {
            audioSource.PlayOneShot(SE1);
            Destroy(other.gameObject);
            HealingItemCount += 1;
        }
    }
}
