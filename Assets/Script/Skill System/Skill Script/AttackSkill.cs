using UnityEngine;
using UnityEngine.InputSystem;
using Control;

namespace SkillSystem
{
    [CreateAssetMenu(menuName = "SkillSystem/Skill/AttackSkill")]
    public class AttackSkill : BaseSkill
    {
        // increase attack damage
        [SerializeField] private LightAttackCommand attackCommand;

        private float cooldown = 20f;

        private bool onCooldown = false;

        private float effect = 10f;

        private bool activated = false;

        public override void Execute(InputAction action, GameObject player)
        {
            
            if (action.WasPressedThisFrame() && !activated && !onCooldown)
            {
                attackCommand.LoadDamage();
                attackCommand.AttackBuff();
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
                attackCommand.AttackNormal();
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
