using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("타이머 텍스트")]
    public TextMeshProUGUI timerText;

    [Header("타이머 시간(분)")]
    public float totaltime; // 분으로 입력

    private void Start() 
    {
        totaltime *= 60f;
        StartCoroutine(UpdateTimer());        
    }

    public IEnumerator UpdateTimer()
    {
        while(totaltime > 0)
        {
        totaltime -= 1f;
        UpdateTimerText();

        yield return new WaitForSeconds(1f);
        }      
    }

    public void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(totaltime / 60f);
        int seconds = Mathf.FloorToInt(totaltime % 60f);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
