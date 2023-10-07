using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Patrol : EnemyAction
{
    public GameObject patrolPoint;
    public float patrolSpeed;
public override void OnStart()
    {
        Animator.Play("Walk");
        Debug.Log("1");
    }
    

    public override TaskStatus OnUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, patrolPoint.transform.position, patrolSpeed * Time.deltaTime);
        if(Vector2.Distance(gameObject.transform.position, patrolPoint.transform.position) < 0.1f)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Running;
        }
        
    }
    
    public override void OnEnd()
    {
        //Animator.Play("Turn");
    }
    
}
