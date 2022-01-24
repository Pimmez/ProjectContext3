using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Test_Nowi : MonoBehaviour
{
    public DialogManager DialogManager;

    // Start is called before the first frame update
    void Start()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hello, my name is Li.", "Li"));

        dialogTexts.Add(new DialogData("My hobbies are skating, dining, streaming games, drawing furry porn and my job as an animal vet.", "Li"));

        dialogTexts.Add(new DialogData("Yes, you heard me right.", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/I love furry porn!", "Li"));

        var dialogTextsOptions = new List<DialogData>();

        var Text1 = new DialogData("/emote:Curious/Do you like furry porn?", "Li");
        Text1.SelectList.Add("Love", "I love it");
        Text1.SelectList.Add("Like", "I like it");
        Text1.SelectList.Add("Fursuit", "I have an Ankha fursuit");

        Text1.Callback = () => Check_Correct();

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);

    }

    private void Check_Correct()
    {
        if (DialogManager.Result == "Love")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("/emote:Happy/Come with me, I'll show you my personal collection.", "Li"));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Like")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("/emote:Happy/Cool! Let's be friends and draw big furry titties together!", "Li"));

            DialogManager.Show(dialogTexts);
        }
        else
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Great, think you could put it on for me?"));

            DialogManager.Show(dialogTexts);
        }
    }
    }