using NavKeypad;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PhysicalButton : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private Outline outline;
    private KeypadButton KeypadButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KeypadButton = GetComponent<KeypadButton>();
        outline = GetComponent<Outline>();
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(pressButton);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        outline.enabled = true;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        outline.enabled = false;
    }

    private void pressButton(SelectEnterEventArgs args)
    {
        KeypadButton.PressButton();
    }

    //public void PressButton(XRBaseInteractor interactor)
    //{
    //    onPress.Invoke();
    //    Debug.Log("Button Pressed by " + interactor.name);
    //}
}
