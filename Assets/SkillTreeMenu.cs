using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeMenu : MonoBehaviour
{
    [SerializeField] private GameObject skillPromptObject;
    void Start()
    {
        SkillPrompt skillPrompt = skillPromptObject.GetComponent<SkillPrompt>();
        skillPrompt.UpdateEquipmentText1();
        skillPrompt.UpdateEquipmentText2();
        skillPrompt.UpdateSkillPoints();
    }
}
