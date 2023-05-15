using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_boost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLayer") == true)
        {
            other.GetComponent<PlayerMovement>().speed = 50;

        }
    }
}
