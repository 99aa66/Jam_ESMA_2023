using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerController : MonoBehaviour
{
    private int nextPlayerIndex = 1; // Variable statique pour l'index du joueur
    private InputActionAsset inputAsset;
    private InputActionMap player;
    //[SerializeField] public float SpeedValue;

    

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player")==true)
        {

            int playerIndex = other.gameObject.GetComponent<Player_Trigger>().playerIndex;

            if (playerIndex == 10)
            {
                other.GetComponent<Player_Trigger>().playerIndex = nextPlayerIndex;
                nextPlayerIndex++;
                StartCoroutine(GiveMalus(other.gameObject));
            }
        }
    }
    private IEnumerator GiveMalus(GameObject player)
    {
        yield return new WaitForSeconds(3f);
        player.GetComponent<Player_Controller>().speed =- player.GetComponent<Player_Controller>().speed;
        Debug.Log(player);
        
        //float invertedValue = InputSystem.GetAction("Move").ReadValue<float>();

        //float invertedValue = InputSystem.
    }
}
