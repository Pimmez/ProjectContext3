using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class ElinahDialogue : MonoBehaviour
{
    public DialogManager DialogManager;

    // Start is called before the first frame update
    void Awake()
    {
        var dialogTexts = new List<DialogData>();

        //INTRO CUTSCENE

        dialogTexts.Add(new DialogData("Today is the day of my big journey.", "Elinah"));
        dialogTexts.Add(new DialogData("The Peace Brigades International organization said it’d be very risky to go to the event, but this is too important.", "Elinah"));
        dialogTexts.Add(new DialogData("I have to get there for everyone who’s counting on me.", "Elinah"));
        dialogTexts.Add(new DialogData("The organization agreed with me, on the condition that they can send a guide. Protection so that nothing bad can happen to me on my way to the event.", "Elinah"));
        dialogTexts.Add(new DialogData("They told me a guiding figure could help me. But I don’t know what exactly they meant with that…", "Elinah"));

        dialogTexts.Add(new DialogData("Ah, this letter is from the Peace Brigades organization.", "Elinah"));

        dialogTexts.Add(new DialogData("There’s a fox stamp on it and wow, it looks kind of magical!", "Elinah"));

        dialogTexts.Add(new DialogData("You must be the guide I was told about. Well, Fox, if you’re supposed to guide me on my journey, then let’s begin this adventure.", "Elinah"));

        dialogTexts.Add(new DialogData("Are you ready?", "Elinah"));

        //Puzzle One

        dialogTexts.Add(new DialogData("Come on, fox, follow me!", "Elinah"));

        dialogTexts.Add(new DialogData("Today’s event is very important, people from around the whole region will show up.", "Elinah"));

        dialogTexts.Add(new DialogData("So come on, let’s get going!", "Elinah"));

        dialogTexts.Add(new DialogData("I lost something last night. It’s somewhat important for today, so we should make a quick stop before we can continue.", "Elinah"));

        dialogTexts.Add(new DialogData("Let’s stay on the path, alright?", "Elinah"));

        dialogTexts.Add(new DialogData("Come on, we shouldn’t take too long or we’ll be late.", "Elinah"));

        //Puzzle Two

        dialogTexts.Add(new DialogData("After I dropped my bag in the dark yesterday, I thought I saw another fox take it into this tunnel. I don’t think I could reach it, but maybe you can?", "Elinah"));

        dialogTexts.Add(new DialogData("If you get close to that little hole, you could probably dig your way in!", "Elinah"));

        dialogTexts.Add(new DialogData("Yes, that’s my bag! Thank you for retrieving it!", "Elinah"));

        dialogTexts.Add(new DialogData("I needed this bag, because there’s a lot of stuff in it. I brought some flyers and banners for the protest we’re heading to, but also things like make-up, because I do want to look good!", "Elinah"));

        //CUTSCENE MIDWAY

        //Puzzle Three

        dialogTexts.Add(new DialogData("The human rights defender should pass this road. Let’s make sure she can’t reach the city!", "Voice1"));
        dialogTexts.Add(new DialogData("It’s a woman right? Then this should be easy.", "Voice2"));

        dialogTexts.Add(new DialogData("Oh no, do you hear that? They must have blocked off the road ahead. The PBI handbook says we should find an alternate escape route, so we don’t put ourselves into a dangerous situation.", "Elinah"));

        dialogTexts.Add(new DialogData("This forest? Well, it’s a pretty dense forest, so it might be difficult for me to navigate. But it does provide an alternative route to the campsite! Great thinking, fox!.", "Elinah"));

        dialogTexts.Add(new DialogData("As I thought, I’m not as small as you are, fox. I can’t move through the forest as easily.", "Elinah"));

        dialogTexts.Add(new DialogData("You’re much smaller. Perhaps you could crawl your way through these piles?", "Elinah"));

        dialogTexts.Add(new DialogData("Fox, is there anything you can do on the other side that would allow me to pass as well?", "Elinah"));

        dialogTexts.Add(new DialogData("Wait before you go on, I’m still stuck here!", "Elinah"));

        dialogTexts.Add(new DialogData("It worked! Let’s continue.", "Elinah"));

        dialogTexts.Add(new DialogData("We can’t go there, it's too dangerous. We’ll go through the forest.", "Elinah"));


        //Puzzle Four

        dialogTexts.Add(new DialogData("That letter is very important to me, can you see it from that height?", "Elinah"));

        dialogTexts.Add(new DialogData("Oh, you found it! Please, bring it back to me now.", "Elinah"));

        dialogTexts.Add(new DialogData("Now that we have the letter back, we can go on! There’s no time to waste!", "Elinah"));


        //CUTSCENE EXTRA

        //CUTSCENE ENDING

        DialogManager.Show(dialogTexts);

    }
}
