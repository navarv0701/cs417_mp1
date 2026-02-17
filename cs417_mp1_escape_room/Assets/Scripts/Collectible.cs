using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        ScoreManager.Instance.AddScore(value);

        Destroy(gameObject);
    }
}
