using UnityEngine;
using System.Collections; 

public class DeathZone : MonoBehaviour
{
    private Transform PlayerSpawn;
    private Animator fadeSysteme; 

    private void Awake()
    {
        PlayerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSysteme = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();


    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) 
        
        {
            StartCoroutine(ReplacePlayer(collision));
            fadeSysteme.SetBool("FadeIn",true);
            fadeSysteme.SetBool("respawn", false);

        }
    }

    private IEnumerator ReplacePlayer(Collider collision) 
    
    {
        yield return new WaitForSeconds(1f); 
        collision.transform.position = PlayerSpawn.position;
        fadeSysteme.SetBool("respawn", true);
        fadeSysteme.SetBool("FadeIn", false);
    }
}
