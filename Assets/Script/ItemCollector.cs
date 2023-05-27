using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text orangesText; 
    private int oranges = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Orange")) {
            Destroy(other.gameObject);
            oranges++;
            orangesText.text = "Oranges: " + oranges;
        }    
    }
}
