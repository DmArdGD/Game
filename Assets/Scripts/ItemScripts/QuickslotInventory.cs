using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using TMPro;

public class QuickslotInventory : MonoBehaviour
{
    // Объект у которого дети являются слотами
    public Transform quickslotParent;
    public InventoryManager inventoryManager;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    private Vector3 X12 = new Vector3(0f, 0f, 0f);
    private Vector3 X13 = new Vector3(0f, 1f, 0f);
    private Vector3 X14 = new Vector3(0f, 0f, 1f);
    private Vector3 X15 = new Vector3(1f, 0f, 0f);
    private Vector3 X11 = new Vector3(0f, 0f, 0f);
    public GameObject quickSlotPanel;
    private GameObject selectedSlot;
    public TMP_InputField fieldY;

    // Update is called once per frame
    void Update()
    { 
        float mw = Input.GetAxis("Mouse ScrollWheel");
        // Используем колесико мышки
        if (mw < -0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки вперед и наше число currentQuickslotID равно последнему слоту, то выбираем наш первый слот (первый слот считается нулевым)
            if (currentQuickslotID >= quickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // Прибавляем к числу currentQuickslotID единичку
                currentQuickslotID++;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // Что то делаем с предметом:

        }
        if (mw > 0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки назад и наше число currentQuickslotID равно 0, то выбираем наш последний слот
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount - 1;
            }
            else
            {
                // Уменьшаем число currentQuickslotID на 1
                currentQuickslotID--;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // Что то делаем с предметом:

        }
        // Используем цифры
        for (int i = 0; i < quickslotParent.childCount; i++)
        {
            // если мы нажимаем на клавиши 1 по 5 то...
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                // проверяем если наш выбранный слот равен слоту который у нас уже выбран, то
                if (currentQuickslotID == i)
                {
                    // Ставим картинку "selected" на слот если он "not selected" или наоборот
                    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                    }
                    else
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    }
                }
                // Иначе мы убираем свечение с предыдущего слота и светим слот который мы выбираем
                else
                {
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentQuickslotID = i;
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                }
            }
        }
        // Используем предмет по нажатию на левую кнопку мыши
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            X12 = hit.normal;
            X11 = hit.point;
            selectedSlot = quickSlotPanel.transform.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item.itemPrefab;
            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item != null)
            {
                if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item != null && !inventoryManager.isOpened && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)
                {
                    if (hit.transform.CompareTag("ConnectPipePoint"))
                    {
                        var pipePoints = GameObject.FindGameObjectsWithTag("ConnectPipePoint");
                        for (int i = 0; i < pipePoints.Length; i++)
                        {
                            if (hit.transform.GetInstanceID() == pipePoints[i].transform.GetInstanceID())
                            {
                                GameObject childObject = Instantiate(selectedSlot, pipePoints[i].transform.position, Quaternion.FromToRotation(X13, X12)) as GameObject;
                                childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
                            }
                        }
                    }
                    else
                    {
                        GameObject childObject = Instantiate(selectedSlot, X11, Quaternion.FromToRotation(X13, X12)) as GameObject;
                        childObject.transform.SetParent(GameObject.Find("SavingEnviroment").transform);
                        Debug.Log("X1: " + X13 + " Z2: " + X12);
                    }
                }
            }
        }
     
        ScaleChanger();
    }

    public void ScaleChanger()
    {
        selectedSlot.transform.localScale = new Vector3(0.057f, ((float)Double.Parse(fieldY.text)) / 1000000, 0.057f);
    }


}