using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

public class GameManager : MonoBehaviour
{
    private bool isDead = false;
    [SerializeField] public ActionCommandScheme controlScheme;
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

    void Start() 
    {
        InputHandler.inputHandler.UpdateActionCommandList(controlScheme.actionCommandList);
        InputHandler.inputHandler.UpdateActionCommandBindings();

        // GameObject.FindGameObjectWithTag("Control Scheme").GetComponenet<InputHandler>().UpdateActionCommandList(controlScheme.actionCommandList);
    }
    #endregion Singleton
 
    // public void subtractHP(int points)
    // {
    //     if (HP > points)
    //     {
    //         HP -= points;
    //     }
    //     else
    //     {
    //         HP = 0;
    //         isDead = true;
    //     }
    // }

}