using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Control;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") 
        {
            Invoke("CompleteLevel", 1f);
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    private void CompleteLevel()
    {
        // GameObject.Find("ControlScheme").SetActive(false);
        SceneManager.LoadScene(2);
    }
}
