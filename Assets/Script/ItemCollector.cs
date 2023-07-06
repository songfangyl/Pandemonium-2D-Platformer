using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text orangesText; 

    private int oranges = 0;

    private PlayerLevel playerLevel;

    void Awake() 
    {
        playerLevel = GetComponent<PlayerLevel>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Orange")) 
        {
            Destroy(other.gameObject);
            oranges++;
            orangesText.text = "Oranges: " + oranges;
            playerLevel.CollectItem();
        }    
    }
}
