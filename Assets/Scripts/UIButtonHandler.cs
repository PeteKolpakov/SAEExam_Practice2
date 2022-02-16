using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


    public class UIButtonHandler : MonoBehaviour 
    {
        public delegate void OnContinuePressed();
        public static event OnContinuePressed onContinuePressed;
        public void ContinueButtonPressed()
        {
            onContinuePressed.Invoke();
        }
    }

