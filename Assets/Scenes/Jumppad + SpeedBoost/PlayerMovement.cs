using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
{
    public float speed = 5f;
    public float jumpForce = 5;
    public bool isOnGround = true;
    private float horizontalInput;
    private float fowardInput;
    private Rigidbody playerRb;
    private float boostTimer;
    private bool boosting ;

    // Start is called before the first frame update
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        boostTimer = 0f;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround) 
        
        {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround= false;
        
        }

        if(boosting) 
        
        {
            boostTimer += Time.deltaTime;

            if (boostTimer >= 3) 
            
            {
                speed = 5;
                boostTimer = 0f;
                boosting= false;
            
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SpeedBoost")
            
        { 
            boosting= true;
            speed = 10;
            Destroy(other.gameObject);
        }
    
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            
        {
            isOnGround = true;
        }
        
    }
}
