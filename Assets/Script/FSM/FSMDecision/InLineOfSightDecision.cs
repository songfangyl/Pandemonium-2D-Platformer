using UnityEngine;
 
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/InLineOfSightDecision")]
    public class InLineOfSightDecision : Decision
    {
        // public LayerMask layerMask;
        // public float distanceThreshold = 3f;   // distance threshold to check against; 
        // Vector3 prevPosition = Vector3.zero;
        // Vector3 prevDir = Vector3.zero;
 
        // public override bool Decide(BaseStateMachine stateMachine)
        // {
        //     Vector3 dir      = (stateMachine.transform.position - prevPosition).normalized;
        //     dir              = (dir.Equals(Vector3.zero)) ? prevDir : dir;
        //     RaycastHit2D hit = Physics2D.Raycast(stateMachine.transform.position, dir, distanceThreshold, layerMask);
        //     prevPosition     = stateMachine.transform.position;
        //     prevDir          = dir;
        //     return (hit.collider != null) ? true : false;
        // }
        GameObject target;                     // target to measure the distance to
        public string targetTag;               // the tag of the target game object we want to check against
        public float distanceThreshold = 3f;   // distance threshold to check against; if distance is greater than or equal to distanceThreshold return true   
    
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var transform = stateMachine.GetComponent<Transform>();
            if (target == null) target = GameObject.FindWithTag(targetTag);
            return Vector2.Distance(transform.position, target.transform.position) <= distanceThreshold;
            
        }
    }
}