using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");
        Vector3 movement = transform.forward * moveVertical * speed;
        rb.velocity = movement;
        transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);
    }
}
