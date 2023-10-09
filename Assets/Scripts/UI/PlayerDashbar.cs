using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDashbar : MonoBehaviour
{
    public Image dashImage;
    public bool beginCD;
    public float cdTime;
    
    // Start is called before the first frame update
    void Start()
    {
        dashImage.fillAmount = 0;
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
            OnDashUsed(cdTime);
        }
    }

    public void OnDashUsed(float time)
    {
        dashImage.fillAmount += Time.deltaTime / time;
        Debug.Log(dashImage.fillAmount);
    }
}
