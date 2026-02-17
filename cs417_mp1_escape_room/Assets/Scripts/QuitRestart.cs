using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitRestart : MonoBehaviour
{
    [SerializeField] private Button quitButton;
    [SerializeField] private Button restartButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quitButton.onClick.AddListener(quit);
        restartButton.onClick.AddListener(restart);
    }

    // Update is called once per frame
    void Update()
    {
        
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
