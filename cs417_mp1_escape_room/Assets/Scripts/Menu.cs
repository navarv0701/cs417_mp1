using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] private InputActionReference action;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.enabled = false;
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            canvas.enabled = true;
        };

        resumeButton.onClick.AddListener(resume);
        quitButton.onClick.AddListener(quit);
        restartButton.onClick.AddListener(restart);
    }

    void resume()
    {
        canvas.enabled = false;
    }

    void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
