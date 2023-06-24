using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GameManager : MonoBehaviour
{
    public int HP = 5;
    public int maxHP = 5;
    private bool isDead = false;
     
    // ... some other game related global stats
 
    #region Singleton
    public static GameManager instance;
 
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton
 
    public void subtractHP(int points)
    {
        if (HP > points)
        {
            HP -= points;
        }
        else
        {
            HP = 0;
            isDead = true;
        }
    }
}