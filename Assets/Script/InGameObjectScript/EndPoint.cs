using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using QuestSystem;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private QuestManager questManager;

    [SerializeField] private Quest quest;

    [SerializeField] private AudioSource UISource;

    [SerializeField] private AudioClip complete;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") 
        {
            UISource.PlayOneShot(complete);
            Invoke("CompleteLevel", 2.5f);
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    private void CompleteLevel()
    {
        questManager.CompleteQuest(quest);
        SceneManager.LoadScene("MainScene");
    }
}
