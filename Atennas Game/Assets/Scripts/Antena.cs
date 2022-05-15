using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antena : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D col)
    {
            Debug.Log(col, col.gameObject);

        GameObject other = col.gameObject;

        //Stuff that happens when the collider collides with something
   

    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
