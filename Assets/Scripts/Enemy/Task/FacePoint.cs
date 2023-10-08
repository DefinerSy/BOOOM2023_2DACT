using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FacePoint : EnemyAction
{
    public GameObject point;
    public override TaskStatus OnUpdate()
    {
        transform.localScale = point.transform.position.x > transform.position.x ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        return TaskStatus.Success;
    }
}