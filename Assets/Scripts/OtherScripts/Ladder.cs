using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool State1 = true;
    private bool State2 = true;
    private bool State3 = false;




   
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
    }

 
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            State1 = !State1;
            State2 = !State2;
            State3 = !State3;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = State1;          
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamController>().enabled = State2;            
            GameObject.FindGameObjectWithTag("Player").GetComponent<LadderController>().enabled = State3;
            

        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamController>().enabled = true;        
        GameObject.FindGameObjectWithTag("Player").GetComponent<LadderController>().enabled = false;


    }
}
