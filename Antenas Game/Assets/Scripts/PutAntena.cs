using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutAntena : MonoBehaviour
{
    [SerializeField] private GameObject m_antenna;
    [SerializeField] private int m_totalAntennas;

    private List<GameObject> m_antennas;

    // Start is called before the first frame update
    void Start()
    {
        m_antennas = new List<GameObject>();

        for (int i = 0; i < m_totalAntennas; ++i)
        {
            GameObject newAntenna = Instantiate(m_antenna);

            positionateAntenna(newAntenna);
            m_antennas.Add(newAntenna);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newAntenna = Instantiate(m_antenna);

            worldPosition.z = transform.position.z;
            newAntenna.transform.position = worldPosition;
        }
    }

    #region private

    private void positionateAntenna(GameObject antenna)
    {
        while (true)
        {
            float xPos = Random.Range(-9, 9);
            float yPos = Random.Range(-4, 4);
            int index;

            Vector3 pos = new Vector3(xPos, yPos, transform.position.z);

            for (index = 0; index < m_antennas.Count; ++index)
            {
                Vector3 antennaPos = m_antennas[index].transform.position;

                if (Vector3.Distance(antennaPos, pos) < 3.5)
                {
                    break;
                }
            }

            if (index == m_antennas.Count)
            {
                antenna.transform.position = pos;
                return;
            }

        }
    }

    #endregion
}
