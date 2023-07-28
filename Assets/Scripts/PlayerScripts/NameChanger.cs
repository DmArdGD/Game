using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class NameChanger : MonoBehaviour
{
    public TMP_InputField nameChanger;
    public Button confirmName;
    bool isShowed/* = false*/;
    public CinemachineVirtualCamera CVC;
    public GameObject QuickSlotPanel;
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R) /*&& !isShowed*/)
        {
            isShowed = !isShowed;
            if (isShowed)
            {
                CVC.gameObject.SetActive(true);
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
                // Прекрепляем курсор к середине экрана
                Cursor.lockState = CursorLockMode.None;
                // и делаем его видимым
                Cursor.visible = true;

                nameChanger.gameObject.SetActive(true);
                confirmName.gameObject.SetActive(true);
                //QuickSlotPanel.SetActive(false);
                //isShowed = true;
            }
            else
            {
                CVC.gameObject.SetActive(false); ;
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
                // Прекрепляем курсор к середине экрана
                Cursor.lockState = CursorLockMode.Locked;
                // и делаем его видимым
                Cursor.visible = false;

                nameChanger.gameObject.SetActive(false);
                confirmName.gameObject.SetActive(false);
                //QuickSlotPanel.SetActive(true);
                //isShowed = true;
            }

        }
        //else
        //if (Input.GetKeyDown(KeyCode.R) && isShowed)
        //{
       //     nameChanger.gameObject.SetActive(false);
        //    confirmName.gameObject.SetActive(false);
       //     isShowed = false;
       // }

    }
    public void ConfirmChanges()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            hit.collider.gameObject.name = nameChanger.text;
            
        }
    }
}
