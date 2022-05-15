using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    private AntennaValues m_antennaValues;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAntennaValues(AntennaValues antennaVaules)
    {
        m_antennaValues = antennaVaules;
    }

    public AntennaValues GetAntennaValues(){return m_antennaValues;}
    

}
