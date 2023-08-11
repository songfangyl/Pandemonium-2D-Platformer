using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;

    [SerializeField] private Quest quest;

    [SerializeField] private Text title;

    [SerializeField] private Text description;

    [SerializeField] private Text reward;

    [SerializeField] private Text levelreq;

    private Button button;

    void Start()
    {
        title.text = quest.Quest_id();
        description.text = quest.Description();
        reward.text = quest.Reward() + "xp";
        levelreq.text = "Required Level: " + quest.LevelNeeded();
        button = GetComponent<Button>();

        if(questManager.canDoQuest(quest)) {
            button.interactable = true;
        } else {
            button.interactable = false;
        }
    }

    public void LoadLevel()
    {
        questManager.LoadQuest(quest);
    }
    
    void Update()
    {
        if(questManager.canDoQuest(quest)) {
            button.interactable = true;
        }
    }

    // Update is called once per frame
}
