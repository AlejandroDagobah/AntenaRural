using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] 
    float m_Speed;
    [SerializeField] 
    float m_MoveLimit = 0.7f;

    [SerializeField] 
    float m_buildPercentage = 0;
    [SerializeField] 
    Rigidbody2D m_rb;
    [SerializeField] 
    float horizontal; 
    [SerializeField] 
    float vertical;
    
    [SerializeField] 
    GameObject m_buildBar;

    [SerializeField] private GameObject m_antena;

    GameObject m_Canvas;

    Animator m_anim;



    // Start is called before the first frame update
    void Start()
    {
     //   Canvas = 
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update() {

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");  
            m_anim.SetFloat("Horizontal", horizontal);
            m_anim.SetFloat("Vertical", vertical);

    }
    
    
    void FixedUpdate()
    {

        if(horizontal != 0 && vertical != 0)
        {
            horizontal *= m_MoveLimit;
            vertical *= m_MoveLimit;
          
        }        
        //m_rb.velocity = transform.forward * m_Speed;
        m_rb.velocity = new Vector2(horizontal * m_Speed, vertical * m_Speed);

    }

       void OnTriggerStay2D(Collider2D col)
        {
            GameObject buildingPlace = col.gameObject;
                 

           // col.gameObject
          
                
            if(Input.GetKey("space") && buildingPlace.tag == "BuildingPlace")
            {
                    
                        AntennaValues bpScript = buildingPlace.GetComponent<BuildingPlace>().GetAntennaValues();

                        if(bpScript == null)
                        {

                        

                            GameObject antena = Instantiate(m_antena, new Vector2(buildingPlace.transform.position.x, buildingPlace.transform.position.y), Quaternion.identity);                               
                            
                            AntennaValues antenaScript = antena.GetComponent<AntennaValues>();

                            Collider2D[] collider2D = buildingPlace.GetComponents<Collider2D>();

                            for (int i = 0; i < collider2D.Length; i++)
                            {
                                collider2D[i].isTrigger = true;
                                
                            }

                            buildingPlace.GetComponent<BuildingPlace>().SetAntennaValues(antenaScript);

                            GameObject Alerta = buildingPlace.transform.Find("alert").gameObject;
                            Alerta.SetActive(false);
                            

                          


                       
                        }else{

                              if(!bpScript.getIsBuilding()){
                                
                                bpScript.setIsInfected(false);
                        
                            }
                        }

                        

                      //  GameObject Viruses = buildingPlace.transform.Find("Viruses").gameObject;

                        


                         /* 
                        antenaScript.m_isEmpty = false;
                        m_buildPercentage += 10;
/*

                       
*/




                      //  antenaScript.setIsInfected(false);




                         /* 
                      if(antenaScript.m_hasVirus == true)
                        {
                            
                            Debug.Log("Tiene Virus");
                            /*
                                antenaScript.Repair();
                                if(antenaScript.m_hasVirus){
                                Viruses.SetActive(true);    
                                                  
                        }else{
                            Debug.Log("Antena en estado óptimo");
                        }
                         */ 
                   
            }

        }

}
