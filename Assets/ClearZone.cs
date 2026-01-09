using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearZone : MonoBehaviour
{
    public TextMeshProUGUI clearText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            clearText.enabled = true;
        }
    }
}
