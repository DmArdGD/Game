using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image mainImage;
    private Material mainMaterial;

    public Material MainMaterial
    {
        get
        { return mainMaterial; }
        set
        {
            if (value != null)
            {
                mainMaterial = value;
                if (mainImage != null)
                    mainImage.color = mainMaterial.color;

            }
        }
    }

    private Transform defaultParentTransform;
    public Transform DefaultParentTransform
    {
    get { return defaultParentTransform; }
    set
        {
        if (value != null)
        {
            defaultParentTransform = value;
        }
    }
    }

    private Transform dragParentTransform;
    public Transform DragParentTransform
    {
        get    { return dragParentTransform; }
        set
        {
            if (value != null)
            {
            dragParentTransform = value;
            }
        }
    }
    private int siblingIndex;
    public int SiblingIndex
    {
    get    { return siblingIndex; }
    set
        {
            if (value > 0)
            {
            siblingIndex = value;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(DragParentTransform);
    }


    public void OnDrag(PointerEventData eventData)
    {
     transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DefaultParentTransform);
        transform.SetSiblingIndex(SiblingIndex);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = mainMaterial;
        }
    }

}
