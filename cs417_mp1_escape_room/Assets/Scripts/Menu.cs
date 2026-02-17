using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] private InputActionReference action;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button resumeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            canvas.enabled = true;
        };

        resumeButton.onClick.AddListener(resume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resume()
    {
        canvas.enabled = false;
    }
}
