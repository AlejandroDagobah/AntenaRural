using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAI : MonoBehaviour
{
    [SerializeField]
    float m_npcSpeed;

    private float waitTime;
    private float StartWaitTime;


    [SerializeField]
    public Transform[] moveSpots;
    private int randomSpot;

    Animator m_anim;
    

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
        m_anim.SetFloat("Horizontal", transform.position.x);

        m_anim.SetFloat("Vertical", transform.position.y);
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, m_npcSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            }
            else{
                waitTime -= Time.deltaTime;
            }

        }

    }
}
