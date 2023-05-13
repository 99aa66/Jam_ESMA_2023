using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> startingPoints;
    [SerializeField] private List<int> spawnedPlayerIDs = new List<int>();
    public void OnPlayerSpawned(PlayerInput playerInput)
    {
        int playerID = playerInput.playerIndex;
        spawnedPlayerIDs.Add(playerID);
        
    }

    //public void RecupereID(PlayerInput playerInput)
    //{

    //}
    // Update is called once per frame
    public List<int> GetSpawnedPlayerIDs()
    {
        return spawnedPlayerIDs;
    }
}
