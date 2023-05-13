using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Trigger : MonoBehaviour
{
    public int playerIndex = 10; // Index du joueur

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Malus"))
        {
            ObtenirIndex();
        }
    }

    public void ObtenirIndex()
    {
        // Obtenir l'index du joueur à partir du TriggerController
        playerIndex = GetComponent<TriggerController>().AssignPlayerIndex();
    }
}
