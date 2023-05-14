using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockBack : MonoBehaviour
{
    [SerializeField] private float pushForce;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null && collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * pushForce, ForceMode.Impulse);
        }   
    }
}
