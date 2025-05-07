using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialog : Dialog
{

    protected override void DialogAdd()
    {
        //throw new System.NotImplementedException();
    }


    protected override void ShowDialog()
    {
        base.ShowDialog();

        isDialog=true; //대화중인걸 반영
    }
}
