using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerController : MonoBehaviour
{
    private static int nextPlayerIndex = 0; // Variable statique pour l'index du joueur
    private InputActionAsset inputAsset;
    private InputActionMap player;
    //[SerializeField] public float SpeedValue;

    public int AssignPlayerIndex()
    {
        int playerIndex = nextPlayerIndex; // Attribuer l'index du joueur
        nextPlayerIndex++; // Incrémenter l'index pour le prochain joueur
        return playerIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player")==true)
        {

            int playerIndex = other.gameObject.GetComponent<Player_Trigger>().playerIndex;

            if (playerIndex == 10)
            {
                AssignPlayerIndex();
                GiveMalus(other.gameObject);
            }
        }
    }
    private void GiveMalus(GameObject player)
    {
        player.GetComponent<Player_Controller>().speed = -player.GetComponent<Player_Controller>().speed;
        Debug.Log(player);
        
        //float invertedValue = InputSystem.GetAction("Move").ReadValue<float>();

        //float invertedValue = InputSystem.
    }
}
