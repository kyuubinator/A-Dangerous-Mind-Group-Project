using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class SafeManager : MonoBehaviour
{
    [SerializeField] private int currentInput;
    [SerializeField] private int[] solution;
    [SerializeField] private int[] inputs;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject fakeButtons;
    [SerializeField] private Animator animator;
    [SerializeField] private XRGrabInteractable interactable;

    [SerializeField] private bool complete;

    public void RecieveInput(int value)
    {
        if (!complete)
        {
            for (int i = 0; i < inputs.Length; i++) 
            {
                if (inputs[i] == 0)
                {
                    inputs[i] = value;
                    CheckifComplete();
                    break;
                }
            }
            if (solution[currentInput] != inputs[currentInput])
            {
                ResetInputList();
            }
            else
            {
                currentInput++;
            }
        }
    }

    private void ResetInputList()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = 0;
        }
        currentInput = 0;
    }

    private void CheckifComplete()
    {
        
        for (int i = 0; i < solution.Length; i++)
        {
            if (solution[i] != inputs[i])
            {
                return;
            }
        }
        buttons.SetActive(false);
        fakeButtons.SetActive(true);
        interactable.enabled = true;
        animator.enabled = true;
        complete = true;
        
    }
}
