using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    private MeshCollider MeshCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        MeshCollider = GetComponent<MeshCollider>();
    }

    public void stopAnimator()
    {
        animator.enabled = false;

        rb.isKinematic = false;
        rb.useGravity = true;

        grabInteractable.enabled = true;
        MeshCollider.enabled = true;
    }

    public void startAnimator()
    {
        animator.enabled = true;
        rb.isKinematic = true;
        rb.useGravity = false;
        grabInteractable.enabled = false;
        MeshCollider.enabled = false;
    }
}
