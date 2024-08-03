using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    const float m_fLimitTime = 180f;
    float m_fMaxWidth = 0;

    float m_fCurrentTime = 0.0f;

    [SerializeField]
    Image m_TimeBar = null;
    [SerializeField]
    Image m_BackgroundBar = null;


    // Start is called before the first frame update
    void Start()
    {
        m_fCurrentTime = m_fLimitTime;   
        m_fMaxWidth = m_BackgroundBar.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }

    private void LateUpdate()
    {
        SetTimeBar();
    }

    void CountTime()
    {
        if(m_fCurrentTime > 0) 
        {
            m_fCurrentTime -= Time.deltaTime;
        }
        else
        {
            //타임오버일 때
        }
    }

    void SetTimeBar()
    {
        float fRestRate = m_fCurrentTime / m_fLimitTime;
        float fCurrentWidth = m_fMaxWidth * fRestRate;

        Vector2 rectSize = m_TimeBar.rectTransform.sizeDelta;
        rectSize.x = fCurrentWidth;
        m_TimeBar.rectTransform.sizeDelta = rectSize;
    } 

}
