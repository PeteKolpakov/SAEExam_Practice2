using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;
    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] DialogSection[] manualTestDialog;
    [SerializeField] TextAsset dialogSceneScript;

    [SerializeField] RunSelection runSelection;

    private void Start()
    {
        RunDialog();
    }

    private void RunDialog()
    {
        switch (runSelection)
        {
            case RunSelection.Manual:
                StartCoroutine(RunDialogFromSecionArray(manualTestDialog));
                break;

            case RunSelection.Random:
                if (sceneLoader != null)
                {
                    DialogSection[] sections = DialogSceneScriptConverter.Convert(sceneLoader.GetRandomScene());
                    StartCoroutine(RunDialogFromSecionArray(sections));
                }
                else
                {
                    Debug.LogError("DialogRunner: Trying to run random dialog with no scene loader assigned");
                }
                break;

            case RunSelection.FromFile:
                if (dialogSceneScript != null)
                {
                    DialogSection[] sections = DialogSceneScriptConverter.Convert(dialogSceneScript.text);
                    StartCoroutine(RunDialogFromSecionArray(sections));
                }
                else
                {
                    Debug.LogError("DialogRunner: Trying to run dialog with no dialog script assigned");
                }
                break;
        }
    }

    private IEnumerator RunDialogFromSecionArray(DialogSection[] dialogSections)
    {
        Debug.Log("Running Test");

        if (dialogDisplayer == null)
        {
            Debug.LogError("No DialogDisplayer assigned.");
            yield break;
        }

        if (dialogSections == null)
        {
            Debug.LogError("Trying to run from empty dialog.");
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

    public enum RunSelection
    {
        Manual,
        Random,
        FromFile
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