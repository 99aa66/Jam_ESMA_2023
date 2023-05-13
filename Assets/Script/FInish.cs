using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //int playerID = playerInput.playerIndex;
        //podium.Add(other.GetComponent<Pl>);
        Destroy(gameObject);

    }
}
