using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> podium;


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
        other.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        other.GetComponent<Player_Controller>().speed = 0;
        podium.Add(other.gameObject);
        //int playerID = playerInput.playerIndex;
        //podium.Add(other.GetComponent<Pl>); 
        foreach (GameObject gameObject in podium)
        {
            //// Instanciation de l'interface utilisateur � partir du pr�fabriqu�
            //GameObject uiInstance = Instantiate(uiPrefab, uiContainer);

            //// Configuration des propri�t�s de l'interface utilisateur en fonction de l'�l�ment actuel
            //UIElementScript uiElement = uiInstance.GetComponent<UIElementScript>();
            //uiElement.SetData(elements[i]);
        }
    }
}
