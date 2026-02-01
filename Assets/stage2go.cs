using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage2go : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAA");
        if (other.CompareTag("Trap"))
        {
            SceneManager.LoadScene("Stage2");
        }
    }
    
}
