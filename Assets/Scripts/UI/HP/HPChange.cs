using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPChange : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHP()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            PlayerHP.hpcurrent = PlayerHP.hpcurrent - 2;
        }
    }
}
