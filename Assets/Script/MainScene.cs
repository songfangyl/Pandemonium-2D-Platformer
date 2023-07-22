using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void LoadQuestScene()
    {
        SceneManager.LoadScene("QuestScene");
    }

    public void LoadSkillTree()
    {
        SceneManager.LoadScene("SkillTree");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
