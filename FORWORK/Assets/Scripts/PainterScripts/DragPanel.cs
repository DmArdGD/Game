using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPanel : MonoBehaviour
{
    [Tooltip("Ссылка на префаб драгуемого элемента")]
    [SerializeField] private GameObject dragColorPrefab;

    [Tooltip("Ссылка на Content ScrollView")]
    [SerializeField] private Transform scrollViewContent;

    [Tooltip("Материалы для перекраски объектов")]
    [SerializeField] private List<Material> materials;

    private void Start()
    {
        for (int i = 0; i < materials.Count; ++i)
        {
            var dragObject = Instantiate(dragColorPrefab, scrollViewContent);
            var script = dragObject.GetComponent<DragElement>();

            script.MainMaterial = materials[i];
            script.DefaultParentTransform = scrollViewContent;
            script.DragParentTransform = transform;
            script.SiblingIndex = i;
        }
    }
}
