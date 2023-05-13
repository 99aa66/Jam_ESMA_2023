using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> podium;
    public PlayerSpawnManager playerSpawnManager;


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
        other.GetComponent<MeshRenderer>().enabled = false;
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        //int playerID = playerInput.playerIndex;
        //podium.Add(other.GetComponent<Pl>);
        Destroy(gameObject);
    }
}
