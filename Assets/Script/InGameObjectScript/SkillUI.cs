using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SkillSystem;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Text title1;

    [SerializeField] private Text title2;

    [SerializeField] private Text CDText1;

    [SerializeField] private Text CDText2;

    [SerializeField] private Text EffectText1;

    [SerializeField] private Text EffectText2;

    [SerializeField] private SkillManager skillManager;

    private BaseSkill skill1;

    private BaseSkill skill2;


    // Start is called before the first frame update

    // Update is called once per frame
    private void Start() {
        skill1 = skillManager.GetSkill1();
        skill2 = skillManager.GetSkill2();
        if (skill1 == null) {
            title1.text = "None";
        }
        else 
        {
            title1.text = skill1.Name();
        }

        if (skill2 == null) {
            title2.text = "None";
        }
        else 
        {
            title2.text = skill2.Name();
        }
    }
    void Update()
    {
        if (skill1 == null)
        {
            CDText1.text = "CD: None";
            EffectText1.text = "None";
        } 
        else 
        {
            CDText1.text = "CD: " + skill1.GetCD();
            EffectText1.text = "Effect: " + skill1.GetEffect();
        }

        if (skill2 == null) 
        {
            CDText2.text = "CD: None";
            EffectText2.text = "None";
        }
        else
        {
            CDText2.text = "CD: " + skill2.GetCD();
            EffectText2.text = "Effect: " + skill2.GetEffect();
        }
    }
}
