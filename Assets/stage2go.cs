using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage2");
        }
    }
}
