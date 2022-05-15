using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AntennaInfection : MonoBehaviour
{
    [SerializeField] private float m_timerStart;

    private float m_timeLeft;
    private List<GameObject> m_antennas;

    // Start is called before the first frame update
    void Start()
    {
        m_timeLeft = m_timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        countDownTimer();
    }

    #region Private

    private void countDownTimer()
    {
        m_timeLeft -= Time.deltaTime;

        if (m_timeLeft < 0)
        {
            m_antennas = new List<GameObject>(GameObject.FindGameObjectsWithTag("Antenna"));
            m_timeLeft = m_timerStart;

            if (m_antennas.Count > 0)
            {
                infectAntenna();
            }
        }
    }

    private void infectAntenna()
    {
        int index = Random.Range(0, m_antennas.Count() - 1);
        GameObject antenna = m_antennas[index];

        antenna.GetComponent<AntennaValues>().setIsBeingInfected(true);
        antenna.tag = "InfectedAntenna";
    }

    #endregion
}
