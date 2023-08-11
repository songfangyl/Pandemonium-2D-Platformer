using Control;
using UnityEngine;
 
public class AnimatorFunctions : MonoBehaviour
{
    public LightAttackCommand attackCommand;
 
    public void ExecuteAttack()
    {
        attackCommand.ExecuteAttack();
    }
 
    public void ResetAttack()
    {
        attackCommand.ResetAttack();
    }
}