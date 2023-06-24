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
            return Mathf.Abs(transform.position.x - targetPoint.x) <= 0.1f;
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

        public float GetTargetPointDirectionX()
        {
            return targetPoint.x - transform.position.x;
        }

    }
}