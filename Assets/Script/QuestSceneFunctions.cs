using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestSceneFunctions : MonoBehaviour
{
    public void BackToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
