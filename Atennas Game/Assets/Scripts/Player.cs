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
    Rigidbody2D m_rb;
    [SerializeField] 
    float horizontal; 
    [SerializeField] 
    float vertical;
    
    [SerializeField] 
    GameObject antena;




    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update() {

          horizontal = Input.GetAxisRaw("Horizontal");
          vertical = Input.GetAxisRaw("Vertical");  

        if(Input.GetKeyDown("space"))
        {
            Instantiate(antena, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);    
        }    
    
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

       void OnCollisionEnter2D(Collision2D col)
        {
            
            Debug.Log(col, col.gameObject);     

           // col.gameObject


            
            //GameObject other = col.gameObject;
        }

}
