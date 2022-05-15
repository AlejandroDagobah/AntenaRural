using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

//using Image = UnityEngine.UIElements.Image;

public class AntennaValues : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float m_infectionTime;
    [SerializeField] private float m_buildTime;

    [SerializeField] private GameObject m_virus;

    private Image m_bar;
    private Image m_buildProgress;
    private float m_timeLeft; 
    private bool m_isInfected = false;
    private bool m_isBeingInfected = false;
    private bool m_isBuilding = true; 

    // Start is called before the first frame update
    void Start()
    {
        m_timeLeft = m_buildTime;

        foreach (Image child in GetComponentsInChildren<Image>())
        {
            if (child.tag == "ImfectionBar")
            {
                m_bar = child;
            }

            if (child.tag == "BuildImg")
            {
                m_buildProgress = child;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        countDownTimer();
    }

    public void setIsInfected(bool isInfected)
    {
        m_isInfected = isInfected;
        
        if(!isInfected)
        {
            m_bar.fillAmount = 0;
            m_virus.SetActive(false);
        }
    }

    public bool getIsInfected()
    {
        return m_isInfected;
    }

    public void setIsBeingInfected(bool isBeingInfected)
    {
        m_isBeingInfected = isBeingInfected;
    }

    public bool getIsBeingInfected()
    {
        return m_isBeingInfected;
    }

    public void setIsBuilding(bool isBuilding)
    {
        m_isBuilding = isBuilding;
    }

    public bool getIsBuilding()
    {
        return m_isBeingInfected;
    }

    private void countDownTimer()
    {
        if (m_isBeingInfected)
        {
            m_timeLeft -= Time.deltaTime;
            m_bar.fillAmount = 1 - (m_timeLeft / m_infectionTime);

            if (m_timeLeft <= 0)
            {
                m_isInfected = true;
                m_isBeingInfected = false;
                m_timeLeft = m_infectionTime;
                m_virus.SetActive(true);
            }
        }
        else if (m_isBuilding)
        {
            m_timeLeft -= Time.deltaTime;
            m_buildProgress.fillAmount = 1 - (m_timeLeft / m_buildTime);

            if (m_timeLeft <= 0)
            {
                SpriteRenderer spriteAntenna = GetComponent<SpriteRenderer>();
                Color color = spriteAntenna.color;

                color.a = 1;
                spriteAntenna.color = color;
                m_buildProgress.fillAmount = 0;
                m_isBuilding = false;
                tag = "Antenna";
                m_timeLeft = m_infectionTime;
            }
        }
    }
}
