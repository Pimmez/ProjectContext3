using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class IntroTextMessage : MonoBehaviour
{
    public DialogManager DialogManager;
    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/my name is Dove.", "Dove"));

        dialogTexts.Add(new DialogData("I am Fox. Popped out to let you know Asset can show other characters.", "Fox"));

        dialogTexts.Add(new DialogData("This Asset, The D'Dialog System has many features.", "Li"));


        DialogManager.Show(dialogTexts);
    }
}