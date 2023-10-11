using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    GameObject _character;
    
    private void Awake()
    {
        _character = GetComponentInParent<Character>().gameObject;
    }
    
    public void DieAnimationEnd()
    {
        Destroy(gameObject);
    }
}
