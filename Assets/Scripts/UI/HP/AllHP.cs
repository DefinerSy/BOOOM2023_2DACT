using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllHP : MonoBehaviour
{
    public void ChangeHPImage(Image HPimage,float HPcurrent,float HPmax)
    {
        HPimage.fillAmount = HPcurrent / HPmax;
    }

    public void ChangeHPText(Text HPtext, float HPcurrent, float HPmax)
    {
        HPtext.text = HPcurrent.ToString() + "/" + HPmax.ToString();
    }
}
