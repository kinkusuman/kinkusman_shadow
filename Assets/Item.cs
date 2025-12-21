using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private int HealingItemCount = 0;
    private int PlayerHP = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        print(HealingItemCount);

        if(Input.GetMouseButtonDown(1) && HealingItemCount >= 1)
        {
            HealingItemCount -= 1;
            PlayerHP += 6;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HealingItem")
        {
            Destroy(other.gameObject);
            HealingItemCount += 1;
        }
    }
}
