using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class VRAssistedCrawlController : MonoBehaviour
{
    [Header("References")]
    public Transform cameraHead; // Drag your Main Camera (HMD) here

    private CharacterController controller;

    [Header("Standing Settings")]
    public float standingHeight = 1.8f;
    public float standingSpeed = 3f;

    [Header("Crawl Assist Settings")]
    [Tooltip("Head height required to ENTER crawl mode")]
    public float crawlEnterHeight = 1.4f;

    [Tooltip("Head height required to EXIT crawl mode")]
    public float crawlExitHeight = 1.55f;

    [Tooltip("Actual collider height used while crawling")]
    public float assistedCrawlHeight = 1.0f;

    public float crawlSpeed = 1.5f;

    [Header("Smoothing")]
    public float heightSmoothSpeed = 8f;

    [Header("Ceiling Protection")]
    public LayerMask ceilingMask;
    public float ceilingCheckDistance = 0.1f;

    [Header("Optional Vent Restriction")]
    public bool requireVentTrigger = false;
    private bool insideVentZone = false;

    private bool isCrawling = false;
    private float targetHeight;
    private float currentSpeed;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        controller.height = standingHeight;
        controller.center = new Vector3(0, standingHeight / 2f, 0);

        targetHeight = standingHeight;
        currentSpeed = standingSpeed;
    }

    void Update()
    {
        HandleCrawlState();
        SmoothHeightAdjust();
    }

    void HandleCrawlState()
    {
        float headHeight = cameraHead.localPosition.y;

        if (requireVentTrigger && !insideVentZone)
        {
            SetStanding();
            return;
        }

        // ENTER crawl
        if (!isCrawling && headHeight < crawlEnterHeight)
        {
            isCrawling = true;
        }
        // EXIT crawl (only if ceiling allows)
        else if (isCrawling && headHeight > crawlExitHeight && CanStand())
        {
            isCrawling = false;
        }

        if (isCrawling)
        {
            targetHeight = assistedCrawlHeight;
            currentSpeed = crawlSpeed;
        }
        else
        {
            SetStanding();
        }
    }

    void SetStanding()
    {
        targetHeight = standingHeight;
        currentSpeed = standingSpeed;
    }

    void SmoothHeightAdjust()
    {
        float newHeight = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * heightSmoothSpeed);

        controller.height = newHeight;
        controller.center = new Vector3(0, newHeight / 2f, 0);
    }

    bool CanStand()
    {
        Vector3 origin = transform.position + Vector3.up * controller.height;
        return !Physics.Raycast(origin, Vector3.up, ceilingCheckDistance, ceilingMask);
    }

    // Example movement function (optional)
    public void Move(Vector3 direction)
    {
        Vector3 move = direction * currentSpeed;
        controller.Move(move * Time.deltaTime);
    }

    // Optional: Use trigger volumes for vents
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vent"))
            insideVentZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vent"))
            insideVentZone = false;
    }
}
