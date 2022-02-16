using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRunner : MonoBehaviour
{
    [SerializeField] DialogDisplayer dialogDisplayer;

    private int _dialogIndex = 0;

    [SerializeField] private Conversation_SO _conversation;

    private void OnEnable()
    {
        UIButtonHandler.onContinuePressed += OnContinueButtonPressed;
    }
    private void OnDisable()
    {
        UIButtonHandler.onContinuePressed -= OnContinueButtonPressed;
    }
    public void OnContinueButtonPressed()
    {
        // progress text
        ProgressDialog(_dialogIndex);
        if (_dialogIndex >= _conversation.elements.Count - 1)
        {
            return;
        }
        _dialogIndex++;
    }
    
    private void Start()
    {
        //StartCoroutine(DialogRoutineTest());
        _dialogIndex = 0;
    }

    private void ProgressDialog(int index)
    {
        dialogDisplayer.SetInterlocutor(_conversation.elements[index].interlocutor);
        dialogDisplayer.SetImage(_conversation.elements[index].image, _conversation.elements[index].interlocutor);
        dialogDisplayer.SetName(_conversation.elements[index].speakerName);
        dialogDisplayer.SetText(_conversation.elements[index].dialogText);
    }
}
