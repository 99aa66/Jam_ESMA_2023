using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{
    public List<PlayerInput> players = new List<PlayerInput>();
    public List<GameObject> Readyplayer;
    [SerializeField] private List<Transform> startingPoints;
    [SerializeField] private List<GameObject> Skin;
    private PlayerInputManager playerInputManager;
    private int index = 0;

    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        Debug.Log("p join");
        playerInputManager.onPlayerJoined += AddPlayer;
        
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
        index--;
    }

    public void AddPlayer(PlayerInput player)
    {
        
        players.Add(player.GetComponent<PlayerInput>());
        GameObject playerParent = player.gameObject;
        playerParent.transform.position = startingPoints[players.Count - 1].position;
        playerInputManager.playerPrefab = ChangeSkin();
        index++;

    }
    private GameObject ChangeSkin()
    {
        //Debug.Log(player.name);
        //Debug.Log("index" + Skin[index]);
        //player = Skin[index];
        //Debug.Log(player.name);
        return Skin[index];
    }
    private void Update()
    {
        foreach (GameObject gameObject in Skin)
        {
            if (gameObject.GetComponent<Player_Controller>().ready == true && Skin[index] != playerInputManager.playerPrefab)
            {
                //Readyplayer.Add(gameObject);
                gameObject.GetComponent<Player_Controller>().enabled = true;
            }
            else if (gameObject.GetComponent<Player_Controller>().ready == false)
            {
                gameObject.GetComponent<Player_Controller>().enabled = false;
            }
        } 
    }

}
