using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DataAssets;


public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private PlayerStats playerStats;

    private void LoadStats()
    {
        playerStats.initialize();

        maxHP = playerStats.Health();
        HP = maxHP;
    }

    public int HP;
    public int maxHP;
    private bool isDead = false;
    private bool alreadyDie = false;
    [SerializeField] private Text LifeText; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LoadStats();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap")) {
            subtractHP(1);
        }
    }


    private void Die() {
        anim.Play("Death");
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
            LifeText.text = "Life:" + HP;;
            // for (int i = 0; i < HP; i++) {
            //     LifeText.text += " *";
            // }
        }
        else 
        {
            LifeText.text = "Life:";
            HP = 0;
            isDead = true;
            anim.SetBool("isDead", true);
            if (isDead && !alreadyDie) {
                Die();
                alreadyDie = true;
            }
        } 
    }

}
