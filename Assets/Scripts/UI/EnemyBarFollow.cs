using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarFollow : MonoBehaviour
{
    public GameObject enemy;

    public float y;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = enemy.transform.position + new Vector3(0,y);
    }
}
