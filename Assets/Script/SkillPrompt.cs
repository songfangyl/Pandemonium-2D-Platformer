using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillSystem;

public class SkillPrompt : MonoBehaviour
{
    private GameObject skillButton;

    private BaseSkill skill;

    private AddSkillButton script;

    [SerializeField] private SkillManager skillManager;

    [SerializeField] private Text skillpoints;

    [SerializeField] private Text equipmentText1;

    [SerializeField] private Text equipmentText2;

    public void InitiateButton(GameObject button) 
    {
        skillButton = button;
        skill = button.GetComponent<AddSkillButton>().GetSkill();
        script = button.GetComponent<AddSkillButton>();
    }
    void Start()
    {
        UpdateEquipmentText1();
        UpdateEquipmentText2();
        UpdateSkillPoints();
    }

    public void UnlockSkill()
    {
        skillManager.UnlockSkill(skill);
        script.UpdateButtonColor();
        UpdateSkillPoints();
    }

    public void EquipSkill1()
    {
        skillManager.AssignSkill_1(skill);
        UpdateEquipmentText1();
    }

    public void EquipSkill2()
    {
        skillManager.AssignSkill_2(skill);
        UpdateEquipmentText2();
    }
    

    public void UpdateSkillPoints()
    {
        skillpoints.text = "Skill Points: " + skillManager.SkillPoint();
        Debug.Log("" + skillManager.SkillPoint());
    }

    public void UpdateEquipmentText1()
    {
        if (skillManager.GetSkill1() == null) 
        {
            equipmentText1.text = "Skill 1:\n" + "None";
        } 
        else 
        {
            equipmentText1.text = "Skill 1:\n" + skillManager.GetSkill1().Name();
        }
    }
    public void UpdateEquipmentText2()
    {
        if (skillManager.GetSkill2() == null) 
        {
            equipmentText2.text = "Skill 2:\n" + "None";
        } 
        else 
        {
            equipmentText2.text = "Skill 2:\n" + skillManager.GetSkill2().Name();
        }
    }
}
