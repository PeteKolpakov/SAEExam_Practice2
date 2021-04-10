using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;

    [SerializeField] DialogSection[] manualTestDialog;
    [SerializeField] bool runManualDialog;


    private void Start()
    {
        if (runManualDialog)
            StartCoroutine(RunDialogFromSecionArray(manualTestDialog));
    }

    private IEnumerator RunDialogFromSecionArray(DialogSection[] dialogSections)
    {
        Debug.Log("Running Test");

        if(dialogDisplayer == null)
        {
            Debug.LogError("No DialogDisplayer assigned.");
            yield break;
        }

        for (int i = 0; i < dialogSections.Length; i++)
        {
            yield return new WaitForContinueClick(dialogDisplayer);

            var current = dialogSections[i];
            dialogDisplayer.SetInterlocutor(current.Interlocutor);
            dialogDisplayer.SetName(current.InterlocutorName);
            dialogDisplayer.SetText(current.Text);
        }

        Debug.Log("Running Test finished.");
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

[System.Serializable]
public class DialogSection
{
    public Interlocutor Interlocutor;
    public string InterlocutorName;
    [TextArea(5, 50)]
    public string Text;
}