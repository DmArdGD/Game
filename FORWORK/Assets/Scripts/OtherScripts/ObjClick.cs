using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ObjClick : MonoBehaviour, IPointerClickHandler
{
    public float delay = 0.2f;
    private float timer;
    private int clickNumber;
    public void OnPointerClick(PointerEventData eventData) 
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            clickNumber++;
            timer = Time.time;
        }
        if (clickNumber == 1 && Time.time > timer + delay)
        {
            print("One click");
            del();
        }
        if (clickNumber == 2 && timer < Time.time + delay)
        {
            SceneManager.LoadScene("Consol");
            del();
        }
    }
    private void del()
    {
        clickNumber = 0;
        timer = 0f;
    }


    
}
