using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPainSound : MonoBehaviour
{
    [SerializeField] SoundsController soundController;

    private void OnEnable()
    {
        soundController.PlayPainSound();
    }

    private void OnJointBreak(float breakForce)
    {
        soundController.PlayNeakBreak();
    }
}
