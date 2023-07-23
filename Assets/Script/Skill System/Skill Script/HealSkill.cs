using UnityEngine;
using UnityEngine.InputSystem;

namespace SkillSystem
{
    [CreateAssetMenu(menuName = "SkillSystem/Skill/HealSkill")]
    public class HealSkill : BaseSkill
    {
        // heal 20 % of hp

        private float cooldown = 30f;

        private bool onCooldown = false;


        public override void Execute(InputAction action, GameObject player)
        {
            if (action.WasPressedThisFrame() & !onCooldown)
            {
                player.GetComponent<PlayerLife>().Heal();
                onCooldown = true;
                player.GetComponent<PlayerAudio>().actionSource.PlayOneShot(skillAudio);
            }
            else if (onCooldown && cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            } 
            else if (onCooldown)
            {
                onCooldown = false;
            }
            
            
        }
    }
}
