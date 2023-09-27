using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : AllHP
{
    public float hpmax;
    public float hpcurrent;
    private Image hpimage;
    public Text hptext;
    // Start is called before the first frame update
    void Start()
    {
        hpcurrent = hpmax;
        hpimage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpcurrent <= 0)
        {
            hpcurrent = 0;
        }
        base.ChangeHPImage(hpimage,hpcurrent,hpmax);
        base.ChangeHPText(hptext,hpcurrent,hpmax);
    }
}
