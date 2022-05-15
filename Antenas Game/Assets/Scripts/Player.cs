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
    GameObject antena;
    
    [SerializeField] 
    GameObject buildBar;

    GameObject Canvas;




    // Start is called before the first frame update
    void Start()
    {
     //   Canvas = 
        m_rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update() {

          horizontal = Input.GetAxisRaw("Horizontal");
          vertical = Input.GetAxisRaw("Vertical");  
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
                    Antena antenaScript = buildingPlace.GetComponent<Antena>();

                    if(antenaScript.m_isEmpty == false){
                        Instantiate(antena, new Vector2(buildingPlace.transform.position.x, buildingPlace.transform.position.y), Quaternion.identity);    
                        //Instantiate(buildBar, new Vector2(buildingPlace.transform.position.x, buildingPlace.transform.position.y), Quaternion.identity);    
                        
                        antenaScript.m_isEmpty = true;
                        m_buildPercentage += 10;
                    }

            }

        }

}
