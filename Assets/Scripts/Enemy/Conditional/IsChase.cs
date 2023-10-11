using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsChase : EnemyCondition
{
    public GameObject target;
    public float distance;
    public float maxDistance;
    private Vector2 targetPostion;
    public override void OnStart()
    {
        targetPostion = new Vector2(target.transform.position.x, transform.position.y);
    }
    public override TaskStatus OnUpdate()
    {
        if(Vector2.Distance(transform.position, new Vector2(target.transform.position.x,transform.position.y)) > maxDistance)
        {
            return TaskStatus.Failure;
        }

        if (Vector2.Distance(transform.position,new Vector2(target.transform.position.x,transform.position.y))<distance)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
