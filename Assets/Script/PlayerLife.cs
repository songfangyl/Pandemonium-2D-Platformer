using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public int HP = 5;
    public int maxHP = 5;
    private bool isDead = false;
    private bool alreadyDie = false;
    [SerializeField] private Text LifeText; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap")) {
            subtractHP(1);
        }
    }


    private void Die() {
        anim.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void EndScreen() {
        SceneManager.LoadScene(2);
    }

    public void subtractHP(int points)
    {
        if (HP > points)
        {
            GetComponent<Animator>().SetTrigger("Hurt");
            // GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8f), ForceMode2D.Impulse);
            HP -= points;
            LifeText.text = "Life:";
            for (int i = 0; i < HP; i++) {
                LifeText.text += " *";
            }
        }
        else 
        {
            LifeText.text = "Life:";
            HP = 0;
            isDead = true;
            if (isDead && !alreadyDie) {
                Die();
                alreadyDie = true;
            }
        } 
    }

}
