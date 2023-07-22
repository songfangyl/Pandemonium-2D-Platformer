using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Level;

public class QuestSceneFunctions : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private Text levelText;
    public void BackToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Start() {
        levelText.text = "Your Level: " + levelManager.lvl();
    }

    
}
