using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerSpawnManager spawnManager;

    // Start is called before the first frame update
    void SpawnPlayer(PlayerInput playerInput)
    {
        spawnManager.OnPlayerSpawned(playerInput);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
