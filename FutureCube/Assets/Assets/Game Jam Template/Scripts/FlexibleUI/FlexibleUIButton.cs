using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FlexibleUIButton : FlexibleUI

{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        base.Initialize();
    }

    protected override void OnSkinUI()
    {

    }

}
