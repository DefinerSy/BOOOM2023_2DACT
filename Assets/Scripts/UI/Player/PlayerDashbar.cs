using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDashbar : MonoBehaviour
{
    public Image dashImage;
    public bool beginCD;
    public float cdTime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        dashImage.fillAmount = 1;
        beginCD = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginCD == false && dashImage.fillAmount == 1)
        {
            dashImage.fillAmount = 0;
            beginCD = true;
        }

        if (beginCD)
        {
            dashImage.fillAmount += Time.deltaTime / cdTime;
        }
    }

    public void OnDashUsed(float time)
    {
        cdTime = time;
        //beginCD = true;
        if (dashImage.fillAmount == 1)
        {
            beginCD = false;
        }
    }
}
