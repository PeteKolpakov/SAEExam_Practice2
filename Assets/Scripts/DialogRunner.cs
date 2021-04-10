using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;

    private void Start()
    {
        StartCoroutine(DialogRoutineTest());
    }

    private IEnumerator DialogRoutineTest()
    {
        Debug.Log("Running Test");
        yield return new WaitForContinueClick(dialogDisplayer);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("Joker takes a deep breath, pauses to see if it's over.");

        yield return new WaitForContinueClick(dialogDisplayer);
        dialogDisplayer.SetText("Beat.");

        yield return new WaitForContinueClick(dialogDisplayer);
        dialogDisplayer.SetInterlocutor(Interlocutor.Character1);
        dialogDisplayer.SetName("JOKER");
        dialogDisplayer.SetText("is it just me, or is it getting crazier out there?");

        yield return new WaitForContinueClick(dialogDisplayer);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("Despite the laughter, there's real pain in his eyes. Something broken in him.Looks like he hasn't slept in days.");

        yield return new WaitForContinueClick(dialogDisplayer);
        dialogDisplayer.SetInterlocutor(Interlocutor.Character2);
        dialogDisplayer.SetName("SOCIAL WORKER");
        dialogDisplayer.SetText("It's certainly tense. People are upset, they're struggling. Looking for work.The garbage strike seems like it's been going on forever.These are tough times.");

        yield return new WaitForContinueClick(dialogDisplayer);
        dialogDisplayer.SetInterlocutor(Interlocutor.None);
        dialogDisplayer.SetText("");
    }


}
public class WaitForContinueClick : CustomYieldInstruction
{
    bool waiting = true;
    DialogDisplayer displayer;
    public override bool keepWaiting => waiting;

    public WaitForContinueClick(DialogDisplayer displayer)
    {
        this.displayer = displayer;
        displayer.ContinueClicked += OnContinueClicked;
    }

    private void OnContinueClicked()
    {
        waiting = false;
        displayer.ContinueClicked -= OnContinueClicked;
    }
}
