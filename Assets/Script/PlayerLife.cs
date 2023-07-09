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

    [SerializeField] private Slider LifeSlider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LoadStats();
        LifeText.text = "Life: " + HP;
        LifeSlider.maxValue = maxHP;
        LifeSlider.value = HP;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap")) {
            subtractHP(1);
        }
    }


    private void Die() {
        anim.Play("Death");
        rb.bodyType = RigidbodyType2D.Static;
        Invoke("EndScreen", 2f);
    }

    private void EndScreen() {
        SceneManager.LoadScene(2);
    }

    public void subtractHP(int points)
    {
        if (HP > points)
        {
            GetComponent<Animator>().SetTrigger("Hurt");
            
            HP -= points;
            // for (int i = 0; i < HP; i++) {
            //     LifeText.text += " *";
            // }
        }
        else 
        {
            HP = 0;
            isDead = true;
            anim.SetBool("isDead", true);
            if (isDead && !alreadyDie) {
                Die();
                alreadyDie = true;
            }
        } 
        LifeText.text = "Life:" + HP;
        LifeSlider.value = HP;
    }

}
