
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI clearText;
    public float speed = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    private float lastSpacePressTime = 0f;
    private float doublePressThreshold = 0.5f;
    private bool isInShadow = false;
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity))
        {
            if (hit.collider != null && hit.collider.CompareTag("Building"))
            {
                isInShadow = true;
            }
            else
            {
                isInShadow = false;
            }
        }
        Debug.DrawRay(transform.position, Vector3.up * 100, Color.red);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSpacePressTime < doublePressThreshold)
            {
                ToggleGroundState();
            }
            lastSpacePressTime = Time.time;
        }
    }
    void ToggleGroundState()
    {
        if (isInShadow)
        {
            transform.position = new Vector3(transform.position.x, -2, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("^-^2");
        if (collision.gameObject.tag == "Goal")
        {
            clearText.enabled = true;
            Debug.Log("^-^");
        }
         if (collision.gameObject.tag == "M")
          {
             Debug.Log("111111");
              SceneManager.LoadScene("Stage2");
          }
    
     }

}    
    

    
            


