using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{
    public List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField] private List<Transform> startingPoints;
    private PlayerInputManager playerInputManager;

    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        players.Add(player);

        GameObject playerParent = player.gameObject;
        playerParent.transform.position = startingPoints[players.Count - 1].position;
    }
}
