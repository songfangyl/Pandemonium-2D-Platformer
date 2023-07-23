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

    // to load health stats for player object
    [SerializeField] private PlayerStats playerStats;

    public void LoadStats()
    {
        playerStats.initialize();

        maxHP = playerStats.Health();

        // we only set HP to Max when initializing player
        if (firstLoadStats)
            HP = maxHP;
    }

    public int HP;

    public int maxHP;

    private bool firstLoadStats = true;

    private bool isDead = false;

    private bool alreadyDie = false;

    [SerializeField] private Text LifeText; 

    [SerializeField] private Slider LifeSlider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LoadStats();
        firstLoadStats = false;
        LifeText.text = "Life: " + HP;
        LifeSlider.maxValue = maxHP;
        LifeSlider.value = HP;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap")) {
            subtractHP(3);
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
        LifeText.text = "Life: " + HP;
        LifeSlider.value = HP;
    }

    public void Heal()
    {
        int temp = HP + (int)(0.2 * maxHP);
        if (temp > maxHP)
            HP = maxHP;
        else 
            HP = temp;

        LifeText.text = "Life: " + HP;
        LifeSlider.value = HP;
    }

}
