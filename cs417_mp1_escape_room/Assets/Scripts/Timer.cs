using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeLeft;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
