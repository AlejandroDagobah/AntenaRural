using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutAntena : MonoBehaviour
{
    [SerializeField] private GameObject m_antenna;
    [SerializeField] private int m_totalAntennas;

    private List<GameObject> m_quads;
    private List<GameObject> m_antennas;

    // Start is called before the first frame update
    void Start()
    {
        m_antennas = new List<GameObject>();
        m_quads = new List<GameObject>(GameObject.FindGameObjectsWithTag("Quad"));

        for (int i = 0; i < m_totalAntennas; ++i)
        {
            int index = Random.Range(0, m_quads.Count - 1);

            GameObject quad = m_quads[index];
            GameObject newAntenna = Instantiate(m_antenna);

            m_quads.Remove(quad);
            positionateAntenna(newAntenna, quad);
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

    private void positionateAntenna(GameObject antenna, GameObject quad)
    {
        RectTransform quadSize = quad.GetComponentInChildren<RectTransform>();

        float quadWidth = quadSize.sizeDelta.x / 2;
        float quadHeight = quadSize.sizeDelta.y / 2;
        float quadXPos = quad.transform.position.x;
        float quadYPos = quad.transform.position.y;
        float xMinLimit = quadXPos - quadWidth;
        float xMaxLimit = quadXPos + quadWidth;
        float yMinLimit = quadYPos - quadHeight;
        float yMaxLimit = quadYPos + quadHeight;


        float xPos = Random.Range(xMinLimit, xMaxLimit);
        float yPos = Random.Range(yMinLimit, yMaxLimit);

        Vector3 pos = new Vector3(xPos, yPos, transform.position.z);

        antenna.transform.position = pos;

    }

    #endregion
}
