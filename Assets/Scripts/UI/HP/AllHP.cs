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
    //这nm写的什么玩意基类就用来干这个？
}
