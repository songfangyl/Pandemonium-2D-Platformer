using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Level;
using SkillSystem;
using QuestSystem;


namespace SaveSystem
{

    [CreateAssetMenu(menuName = "SaveSystem/SaveManager")]
    public class SaveManager : ScriptableObject
    {
        
        private static string DIRECTORY = "/SaveFile.dat";
        
        public SaveData save;

        [SerializeField] private LevelManager levelManager;

        [SerializeField] private SkillManager skillManager;

        [SerializeField] private QuestManager questManager;
        
        public void SaveGame()
        {

            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Create(Application.persistentDataPath + DIRECTORY);

            save = new SaveData();

            save.total_exp = levelManager.XP();

            save.curr_lvl = levelManager.lvl();

            BaseSkill skill1 = skillManager.Skill_1();

            save.skill_1 = skill1 == null ? null : skill1.Name();

            BaseSkill skill2 = skillManager.Skill_2();

            save.skill_2 = skill2 == null ? null : skill2.Name();

            save.skill_point = skillManager.SkillPoint();;

            save.unlockedSkill = skillManager.UnlockedSkill();

            save.doneQuest = questManager.CompletedQuest();

            bf.Serialize(file, save);

            file.Close();

            Debug.Log("Game saved");


        }


        public void LoadGame()
        {
            if (File.Exists(Application.persistentDataPath + DIRECTORY))
            {
                BinaryFormatter bf = new BinaryFormatter();

                FileStream file = File.Open(Application.persistentDataPath + DIRECTORY, FileMode.Open);

                save = (SaveData) bf.Deserialize(file);

                file.Close();
            }
            else {
                NewGame();
            }
        }

        private void NewGame()
        {
            save = new SaveData();

            save.total_exp = 0;

            save.curr_lvl = 1;

            save.skill_1 = "";

            save.skill_2 = "";

            save.skill_point = 0;

            save.unlockedSkill = new List<string>();

            save.doneQuest = new List<string>();

        }

        void Awake()
        {
            LoadGame();
        }

    }
}

