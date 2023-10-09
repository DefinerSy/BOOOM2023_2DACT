using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class CompareDistance : EnemyAction
{
    public GameObject target;
    public SharedFloat distance;
    public override TaskStatus OnUpdate()
    {
        return Vector2.Distance(transform.position, 
            target.transform.position) < distance.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}
