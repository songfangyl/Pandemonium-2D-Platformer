using System.Collections.Generic;
using UnityEngine;
 
namespace AI.FSM
{
    public class PatrolPoints : MonoBehaviour
    {
        public List<Vector2> points;
        private Vector2 targetPoint;
        private int index;
 
        private void Start()
        {
            index = 0;
            targetPoint = points[index];
        }

        public bool HasReachedPoint()
        {
            return (Vector2.Distance(transform.position, targetPoint) <= 0.1f) ? true : false;
        }
        
        public void SetNextTargetPoint()
        {
            index = (index == points.Count - 1) ? 0 : index + 1;
            targetPoint = points[index];
        }
        public Vector2 GetTargetPoint()
        {
            return targetPoint;
        }

    }
}