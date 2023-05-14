using UnityEngine;

public class Player_Spawn : MonoBehaviour
{
 private void Awake() 
    
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
