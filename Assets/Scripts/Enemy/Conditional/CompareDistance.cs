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
            new Vector2(target.transform.position.x,transform.position.y)) < distance.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}
