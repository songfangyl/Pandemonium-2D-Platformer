using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestSystem;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] private QuestManager questManager;

    [SerializeField] private int orangeXP = 5;

    void Awake() 
    {
       // playerLevel = GetComponent<PlayerLevel>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Orange")) 
        {
            Destroy(other.gameObject);
            questManager.CollectItem(orangeXP);
        }    
    }
}
