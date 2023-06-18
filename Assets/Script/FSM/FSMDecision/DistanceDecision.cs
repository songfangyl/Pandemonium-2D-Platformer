using UnityEngine;
 
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/DistanceDecision")]
    public class DistanceDecision : Decision
    {
        GameObject target;                     // target to measure the distance to
        public string targetTag;               // the tag of the target game object we want to check against
        public float distanceThreshold = 3f;   // distance threshold to check against; if distance is greater than or equal to distanceThreshold return true   
    
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var transform = stateMachine.GetComponent<Transform>();
            if (target == null) target = GameObject.FindWithTag(targetTag);
            var res = Vector2.Distance(transform.position, target.transform.position) >= distanceThreshold;
            if (res) {
                Debug.Log("DistanceDecisionTrue");
            }
            return res;
        }
    }
}