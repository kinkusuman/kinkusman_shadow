using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static int playerHP = 100;
    public int shadowHealth = 10;
    private bool isUnderground = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckShadowHealth", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUnderground && shadowHealth < 10)
        {
            shadowHealth += 1;
        }

        if (playerHP < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("GameOver");
        }
       
        Debug.Log($"PlayerHP...{playerHP}/shadowHealth...{shadowHealth}");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHP -= 10;
        }
        else if (collision.gameObject.CompareTag("UnderGround"))
        {
            isUnderground = true;
        }
        if (collision.gameObject.tag == "T")
        {
            playerHP -= 20;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("UnderGround"))
        {
            isUnderground = false;
        }
    }
    void CheckShadowHealth()
    {
        if (isUnderground)
        {
            shadowHealth -= 2;
            if (shadowHealth < 0)
            {
                shadowHealth = 0; // Reset shadow health after penalty
            }
        }

        if (shadowHealth == 0)
        {
            playerHP -= 1;
        }
    }
}
