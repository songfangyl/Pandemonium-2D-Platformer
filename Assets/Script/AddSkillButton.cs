using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SkillSystem;

public class AddSkillButton : MonoBehaviour
{
    [SerializeField] private Text skillname;
    [SerializeField] private BaseSkill skill;

    [SerializeField] private SkillManager skillManager;
    
    private RawImage image;
    void Start()
    {
        skillname.text = skill.Name();
        image = GetComponent<RawImage>();
        UpdateButtonColor();
    }

    // public void UnlockSkill()
    // {
    //     skillManager.UnlockSkill(skill);
    //     UpdateButtonColor();
    //     UpdateSkillPoints();
    // }

    // public void EquipSkill1()
    // {
    //     skillManager.AssignSkill_1(skill);
    // }

    // public void EquipSkill2()
    // {
    //     skillManager.AssignSkill_2(skill);
    // }
    
    public void UpdateButtonColor()
    {
        
        if (skill.isUnlocked()) 
        {
            image.color = Color.white;
        } 
        else
        {
            image.color = Color.gray;
        }
    }
    public BaseSkill GetSkill()
    {
        return skill;
    }


}
