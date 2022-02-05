using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System;

public class ElinahDialogue : MonoBehaviour
{
    public DialogManager DialogManager;

    public static Action<bool> WeirdVoicesEvent;
    
    public List<DialogData> tutorialDialogue = new List<DialogData>();
    public List<DialogData> beforeCaveDialogue = new List<DialogData>();
    public List<DialogData> afterCaveDialogue = new List<DialogData>();
    public List<DialogData> weirdVoicesDialogue = new List<DialogData>();
    public List<DialogData> forestDialogue = new List<DialogData>();

    // Start is called before the first frame update
    void Awake()
    {
        var dialogTexts = new List<DialogData>();


        tutorialDialogue.Add(new DialogData("Come on, fox, follow me!", "Elinah"));
        tutorialDialogue.Add(new DialogData("Today's event is very important, people from around the whole region will show up.", "Elinah"));
        tutorialDialogue.Add(new DialogData("So come on, let's get going!", "Elinah"));
        tutorialDialogue.Add(new DialogData("I lost something last night.", "Elinah"));
        tutorialDialogue.Add(new DialogData("It's somewhat important for today, so we should make a quick stop before we can continue.", "Elinah"));
        tutorialDialogue.Add(new DialogData("Let's stay on the path, alright?", "Elinah"));
        tutorialDialogue.Add(new DialogData("Come on, we shouldn't take too long or we'll be late.", "Elinah"));

        beforeCaveDialogue.Add(new DialogData("After I dropped my bag yesterday evening, I thought I saw an animal take it into this tunnel.", "Elinah")); 
        beforeCaveDialogue.Add(new DialogData("I don't think I could reach it, but maybe you can?", "Elinah"));
        beforeCaveDialogue.Add(new DialogData("If you get close to that little hole, you could probably dig your way in!", "Elinah"));

        afterCaveDialogue.Add(new DialogData("Yes, that's my bag! Thank you for retrieving it!", "Elinah"));
        afterCaveDialogue.Add(new DialogData("I needed this bag, because there's a lot of stuff in it.", "Elinah"));
        afterCaveDialogue.Add(new DialogData("I brought some flyers and banners for the protest we're heading to.", "Elinah"));
        afterCaveDialogue.Add(new DialogData("But also things like make-up, because I do want to look good!", "Elinah"));

        weirdVoicesDialogue.Add(new DialogData("The human rights defender should be passing this road.", "Voice1"));
        weirdVoicesDialogue.Add(new DialogData("Let's make sure she can't reach the city!", "Voice1"));
        weirdVoicesDialogue.Add(new DialogData("Hold up, it's a woman? Well, that should make this easy", "Voice2"));
        weirdVoicesDialogue.Add(new DialogData("Oh no, do you hear that? They will try to block me on the road ahead.", "Elinah"));
        weirdVoicesDialogue.Add(new DialogData("The PBI handbook says we should find an alternate escape route,", "Elinah"));
        weirdVoicesDialogue.Add(new DialogData("so we can avoid a dangerous situation.", "Elinah"));
        weirdVoicesDialogue.Add(new DialogData("This forest? Well, it's a pretty dense forest, so it might be difficult for me to navigate.", "Elinah"));
        DialogData weirdVoicesData = new DialogData("But it does provide an alternative route to the campsite! Great thinking, fox!.", "Elinah");
        weirdVoicesDialogue.Add(weirdVoicesData);
        weirdVoicesData.Callback = () => WeirdVoiceCallBackFunction();
        

        forestDialogue.Add(new DialogData("I’m not as small as you are, fox. I can’t move through the forest as easily.", "Elinah"));
        forestDialogue.Add(new DialogData("You're much smaller. Perhaps you could crawl your way through these piles?", "Elinah"));
        DialogData forestDialogueData = new DialogData("Fox, is there anything you can do on the other side that would allow me to pass as well?", "Elinah");
        forestDialogue.Add(forestDialogueData);
        forestDialogueData.Callback = () => ForestCallBackFunction();
        //forestDialogue.Add(new DialogData("Wait before you go on, I'm still stuck here!", "Elinah"));
        //forestDialogue.Add(new DialogData("It worked! Let's continue.", "Elinah"));
        //forestDialogue.Add(new DialogData("We can't go there, it's too dangerous. We'll go through the forest.", "Elinah"));


        //INTRO CUTSCENE

        dialogTexts.Add(new DialogData("Today is the day of my big journey.", "Elinah"));
        dialogTexts.Add(new DialogData("The Peace Brigades International organization said it'd be very risky to go to the event,", "Elinah"));
        dialogTexts.Add(new DialogData("but this is too important.", "Elinah"));
        dialogTexts.Add(new DialogData("I have to get there for everyone who's counting on me.", "Elinah"));
        dialogTexts.Add(new DialogData("The organization agreed with me, on the condition that they can send a guide.", "Elinah"));
        dialogTexts.Add(new DialogData("Protection so that nothing bad can happen to me on my way to the event.", "Elinah"));
        dialogTexts.Add(new DialogData("They told me a guiding figure could help me. But I don't know what exactly they meant with that", "Elinah"));

        dialogTexts.Add(new DialogData("Ah, this letter is from the Peace Brigades organization.", "Elinah"));

        dialogTexts.Add(new DialogData("There's a fox stamp on it and wow, it looks kind of magical!", "Elinah"));

        dialogTexts.Add(new DialogData("You must be the guide I was told about. Well, Fox, if you're supposed to guide me on my journey, then let's begin this adventure.", "Elinah"));

        dialogTexts.Add(new DialogData("Are you ready?", "Elinah"));

        /*
        //Puzzle One

        dialogTexts.Add(new DialogData("Come on, fox, follow me!", "Elinah"));

        dialogTexts.Add(new DialogData("Today's event is very important, people from around the whole region will show up.", "Elinah"));

        dialogTexts.Add(new DialogData("So come on, let's get going!", "Elinah"));

        dialogTexts.Add(new DialogData("I lost something last night. It's somewhat important for today, so we should make a quick stop before we can continue.", "Elinah"));

        dialogTexts.Add(new DialogData("Let's stay on the path, alright?", "Elinah"));

        dialogTexts.Add(new DialogData("Come on, we shouldn't take too long or we'll be late.", "Elinah"));
        

        //Puzzle Two
        //Before cave retrieve
        dialogTexts.Add(new DialogData("After I dropped my bag yesterday evening, I thought I saw an animal take it into this tunnel.", "Elinah"));
        dialogTexts.Add(new DialogData("I don't think I could reach it, but maybe you can?", "Elinah"));
        dialogTexts.Add(new DialogData("If you get close to that little hole, you could probably dig your way in!", "Elinah"));

        //After retrieve
        dialogTexts.Add(new DialogData("Yes, that's my bag! Thank you for retrieving it!", "Elinah"));
        dialogTexts.Add(new DialogData("I needed this bag, because there's a lot of stuff in it. I brought some flyers and banners for the protest we're heading to", "Elinah"));
        dialogTexts.Add(new DialogData("But also things like make-up, because I do want to look good!", "Elinah"));
        

        //Puzzle Three
        //WeirdVoices Dialogue
        dialogTexts.Add(new DialogData("The human rights defender should be passing this road. Let's make sure she can't reach the city!", "Voice1"));
        
        dialogTexts.Add(new DialogData("Hold up, it's a woman? Well, that should make this easy", "Voice2"));

        dialogTexts.Add(new DialogData("Oh no, do you hear that? They will try to block me on the road ahead.", "Voice2"));
        dialogTexts.Add(new DialogData("The PBI handbook says we should find an alternate escape route, so we can avoid a dangerous situation.", "Elinah"));
        

        //Forest part
        dialogTexts.Add(new DialogData("This forest? Well, it's a pretty dense forest, so it might be difficult for me to navigate.", "Elinah"));
        dialogTexts.Add(new DialogData("But it does provide an alternative route to the campsite! Great thinking, fox!.", "Elinah"));

        dialogTexts.Add(new DialogData("I’m not as small as you are, fox. I can’t move through the forest as easily.", "Elinah"));

        dialogTexts.Add(new DialogData("You're much smaller. Perhaps you could crawl your way through these piles?", "Elinah"));

        dialogTexts.Add(new DialogData("Fox, is there anything you can do on the other side that would allow me to pass as well?", "Elinah"));

        dialogTexts.Add(new DialogData("Wait before you go on, I'm still stuck here!", "Elinah"));

        dialogTexts.Add(new DialogData("It worked! Let's continue.", "Elinah"));

        dialogTexts.Add(new DialogData("We can't go there, it's too dangerous. We'll go through the forest.", "Elinah"));

        */
        //Puzzle Four

        dialogTexts.Add(new DialogData("That letter is my protest permit, so it's very important. Can you see it from that height?", "Elinah"));

        dialogTexts.Add(new DialogData("Oh, you found it! Please, bring it back to me now.", "Elinah"));

        dialogTexts.Add(new DialogData("Now that we have the protest permission letter back, we can go on! There's no time to waste!", "Elinah"));


        //CUTSCENE MIDWAY

        dialogTexts.Add(new DialogData("Did you see all the chopped wood?", "Elinah"));
        dialogTexts.Add(new DialogData("That forest used to be much larger, but because of illegal wood cutting the forest has been severely damaged.", "Elinah"));
        dialogTexts.Add(new DialogData("Protecting forests like these is one of the main topics of our Environmental Rights protest today!", "Elinah"));

        dialogTexts.Add(new DialogData("I have a special letter with me. It's a protest permit, which states that I will lead today's protest.", "Elinah"));

        dialogTexts.Add(new DialogData("You can run around a little. I'll go check out the PBI tent. You can come back to me if you're ready to continue!", "Elinah"));

        dialogTexts.Add(new DialogData("Great, I'll show you the official PBI letter I received this morning.", "Elinah"));

        dialogTexts.Add(new DialogData("Another stamp, but with a dove on it? It has the same magical look as the fox one does.", "Elinah"));
        dialogTexts.Add(new DialogData("Perhaps I should see what this one does as well?", "Elinah"));

        dialogTexts.Add(new DialogData("I think that with this letter, you can change forms!", "Elinah"));

        dialogTexts.Add(new DialogData("Oh no, that's my protest permission letter. I need to have it back before we get to the protest.", "Elinah"));
        dialogTexts.Add(new DialogData("Well, if you can fly high, you could easily locate my letter. Could you go find it for me and then bring it back?", "Elinah"));

        //CUTSCENE EXTRA

        dialogTexts.Add(new DialogData("We then continued our journey together.", "Elinah"));
        dialogTexts.Add(new DialogData("After a while, we came across an area with a lot of smoke.", "Elinah"));
        dialogTexts.Add(new DialogData("Some people probably tried to obstruct me again by throwing smoke bombs that would keep me from seeing where I was going.", "Elinah"));
        dialogTexts.Add(new DialogData("The dove was smart and grabbed my flashlight and flew up high with it to show me the path.", "Elinah"));

        dialogTexts.Add(new DialogData("Finally, we arrived at the city. Some people had made a barrier there to keep me from entering the city.", "Elinah"));
        dialogTexts.Add(new DialogData("But when my little guide snuck inside of the city and grabbed a megaphone for me, I was able to speak loud enough so that the other protesters could hear me.", "Elinah"));
        dialogTexts.Add(new DialogData("They all gathered around the blockade in an attempt to help me get through!", "Elinah"));

        //CUTSCENE ENDING

        dialogTexts.Add(new DialogData("Ohno, they all came to support the human rights defender. This is a battle we cannot win, let's run!", "Voice1"));

        dialogTexts.Add(new DialogData("Thanks, everyone. If we all work together and with the help of PBI, they can't stop us that easily!", "Elinah"));

        dialogTexts.Add(new DialogData("Multinational companies are destroying our environments!! They have cut our trees and polluted our lands more than enough.", "Elinah"));
        dialogTexts.Add(new DialogData("And in the past, if someone stood up against them, those brave people would mysteriously disappear.", "Elinah"));
        dialogTexts.Add(new DialogData("So many of our local heroes have gone missing'", "Elinah"));
        dialogTexts.Add(new DialogData("But together with the Peace Brigades International, I will make sure that we stand strong and we are safe!", "Elinah"));

        //Template LineAdder
        //dialogTexts.Add(new DialogData("...", "Elinah"));

        //Dialogue end here!!
        //DialogManager.Show(dialogTexts);

    }

    public void TutorialDialogue()
    {
        DialogManager.Show(tutorialDialogue);
    }
    public void BeforeCaveDialogue()
    {
        DialogManager.Show(beforeCaveDialogue);
    }
    public void AfterCaveDialogue()
    {
        DialogManager.Show(afterCaveDialogue);
    }
    public void WeirdVoicesDialogue()
    {
        DialogManager.Show(weirdVoicesDialogue);
    }
    public void ForestBlockadeDialogue()
    {
        DialogManager.Show(forestDialogue);
    }
    private void WeirdVoiceCallBackFunction()
    {
        HRDTaskList.Instance.ForestTextActive = true;
        if(WeirdVoicesEvent != null)
        {
            WeirdVoicesEvent(true);
        }
    }

    private void ForestCallBackFunction()
    {
        HRDTaskList.Instance.DoForestTextOnce = false;
    }
}