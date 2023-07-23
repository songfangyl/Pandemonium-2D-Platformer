using UnityEngine;
using UnityEngine.InputSystem;

namespace SkillSystem
{
    [CreateAssetMenu(menuName = "SkillSystem/Skill/SpeedSkill")]
    public class SpeedSkill : BaseSkill
    {
        private float cooldown = 20f;

        private bool onCooldown = false;

        private float effect = 15f;

        private bool activated = false;

        public override void Execute(InputAction action, GameObject player)
        {
            
            
            if (action.WasPressedThisFrame() && !activated && !onCooldown)
            {
                player.GetComponent<PlayerMovement>().SpeedBoost();
                activated = true;
                player.GetComponent<PlayerAudio>().actionSource.PlayOneShot(skillAudio);

            } 
            else if (activated && effect > 0)
            {
                // countdown on activate
                effect -= Time.deltaTime;
            }
            else if (effect < 0)
            {
                // start cooldown 
                player.GetComponent<PlayerMovement>().SlowDown();
                effect = 15f;
                activated = false;
                onCooldown = true;

            } 
            else if (cooldown > 0 && onCooldown)
            {
                // cooldown 
                cooldown -= Time.deltaTime;
            }
            else if (onCooldown)
            {
                // finsih cooldown & reset
                cooldown = 20f;
                onCooldown = false;
            }
        }

        override public float GetCD() 
        {
            return cooldown;
        }

        override public float GetEffect()
        {
            return effect;
        }
        
    }
}
