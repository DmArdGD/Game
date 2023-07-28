using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleClick : MonoBehaviour
{
    public float delay = 0.2f;
    private float timer;
    private int clickNumber;
    public Transform MenuWindow;
    public GameObject UIBG;
    public GameObject crosshair;
    private Camera mainCamera;
    public CinemachineVirtualCamera CVC;
    public bool isOpened;
    private void Awake()
    {
        UIBG.SetActive(true);
    }
    void Start()
    {
        mainCamera = Camera.main;
        //for (int i = 0; i < MenuWindow.childCount; i++)
        //{
        //    if (MenuWindow.GetChild(i).GetComponent<InventorySlot>() != null)
        //    {
        //        slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
        //    }
        //}
        UIBG.SetActive(false);
        MenuWindow.gameObject.SetActive(false);
    }
    void Update()
    {
        //if (Input.GetKeyDown("escape"))
        //{
        //    SceneManager.LoadScene("StartScene");
        //}
        //if (clickNumber == 1 && Time.time > timer + delay)
        //{
        //    print("One click");
        //    del();
        //}
        //if (clickNumber == 2 && timer < Time.time + delay)
        //{
        //    SceneManager.LoadScene("StartScene");
        //    del();
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    clickNumber++;
        //    timer = Time.time;

        //}
        //if (clickNumber == 1 && Time.time > timer + delay)
        //{
        //    print("One click");
        //    del();
        //}
        //if (clickNumber == 2 && timer < Time.time + delay)
        //{
        //    SceneManager.LoadScene("Consol");
        //    del();
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpened = !isOpened;
            if (isOpened)
            {

                UIBG.SetActive(true);
                MenuWindow.gameObject.SetActive(true);
                crosshair.SetActive(false);
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
                //����������� ������ � �������� ������
                Cursor.lockState = CursorLockMode.None;
                //� ������ ��� �������
                Cursor.visible = true;
            }
            else
            {
                UIBG.SetActive(false);
                MenuWindow.gameObject.SetActive(false);
                crosshair.SetActive(true);
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
               // ����������� ������ � �������� ������
                Cursor.lockState = CursorLockMode.Locked;
               // � ������ ��� ���������
                Cursor.visible = false;
            }
        }
    }
    //private void del()
    //{
    //    clickNumber = 0;
    //    timer = 0f;
    //}
}
//using Cinemachine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DoubleClick : MonoBehaviour
//{
//    public GameObject UIBG;
//    public GameObject crosshair;
//    public Transform inventoryPanel;
//    public List<InventorySlot> slots = new List<InventorySlot>();
//    public bool isOpened;
//    public float reachDistance = 30f;
//    public Camera mainCamera;
//    public CinemachineVirtualCamera CVC;
//    // Start is called before the first frame update
//    private void Awake()
//    {
//        UIBG.SetActive(true);
//    }
//    void Start()
//    {
//        mainCamera = Camera.main;
//        for (int i = 0; i < inventoryPanel.childCount; i++)
//        {
//            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
//            {
//                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
//            }
//        }
//        UIBG.SetActive(false);
//        inventoryPanel.gameObject.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            isOpened = !isOpened;
//            if (isOpened)
//            {
//                UIBG.SetActive(true);
//                inventoryPanel.gameObject.SetActive(true);
//                crosshair.SetActive(false);
//                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
//                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
//                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
//                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
//                // ����������� ������ � �������� ������
//                Cursor.lockState = CursorLockMode.None;
//                // � ������ ��� �������
//                Cursor.visible = true;
//            }
//            else
//            {
//                UIBG.SetActive(false);
//                inventoryPanel.gameObject.SetActive(false);
//                crosshair.SetActive(true);
//                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
//                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
//                // ����������� ������ � �������� ������
//                Cursor.lockState = CursorLockMode.Locked;
//                // � ������ ��� ���������
//                Cursor.visible = false;
//            }
//        }
//        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;

//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            if (Physics.Raycast(ray, out hit, reachDistance))
//            {
//                if (hit.collider.gameObject.GetComponent<Item>() != null)
//                {
//                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
//                    Destroy(hit.collider.gameObject);
//                }
//            }
//        }
//    }
//    private void AddItem(ItemScriptableObject _item, int _amount)
//    {
//        foreach (InventorySlot slot in slots)
//        {
//            // � ����� ��� ������� ���� �������
//            if (slot.item == _item)
//            {
//                if (slot.amount + _amount <= _item.maximumAmount)
//                {
//                    slot.amount += _amount;
//                    slot.itemAmountText.text = slot.amount.ToString();
//                    return;
//                }
//                break;
//            }
//        }
//        foreach (InventorySlot slot in slots)
//        {
//            if (slot.isEmpty == true)
//            {
//                slot.item = _item;
//                slot.amount = _amount;
//                slot.isEmpty = false;
//                slot.SetIcon(_item.icon);
//                slot.itemAmountText.text = _amount.ToString();
//                break;
//            }
//        }
//    }
//}