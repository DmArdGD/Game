using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    public GameObject QuickSlotPanel;
    //public GameObject UIBG;
    //public GameObject crosshair;
    //public Camera mainCamera;
    //public CinemachineVirtualCamera CVC;
    //public Transform inventoryPanel;
    //public bool isOpened;
    //private void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.C))
        //isOpened = !isOpened;
        //if (isOpened)
        //{
        //    CVC.gameObject.SetActive(true);
        //    UIBG.SetActive(true);
        //    inventoryPanel.gameObject.SetActive(true);
        //    crosshair.SetActive(false);
        //    CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
        //    CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
        //    CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
        //    CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
        //    // Прекрепляем курсор к середине экрана
        //    Cursor.lockState = CursorLockMode.None;
        //    // и делаем его видимым
        //    Cursor.visible = true;
        //}
        //else
        //{
        //    CVC.gameObject.SetActive(false);
        //    UIBG.SetActive(false);
        //    inventoryPanel.gameObject.SetActive(false);
        //    crosshair.SetActive(true);
        //    CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
        //    CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
        //    // Прекрепляем курсор к середине экрана
        //    Cursor.lockState = CursorLockMode.Locked;
        //    // и делаем его невидимым
        //    Cursor.visible = false;
     //}
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Escape ))
        {
          QuickSlotPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            QuickSlotPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        }
    }
}
