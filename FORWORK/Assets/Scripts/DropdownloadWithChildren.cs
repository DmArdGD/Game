using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownloadWithChildren : MonoBehaviour
{
    public GameObject parentObject;
    public Dropdown dropdown;
    public Toggle togglePrefab;
    public VerticalLayoutGroup layoutGroup;

    private Dictionary<string, List<Transform>> parentChildMap;
    private List<Toggle> toggles;

    public LoadScript loadScript;

    private void Start()
    {
        BuildParentChildMap();
        PopulateDropdownList();
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        toggles = new List<Toggle>();
        OnDropdownValueChanged(dropdown.value);
    }

    private void BuildParentChildMap()
    {
        parentChildMap = new Dictionary<string, List<Transform>>();
        foreach (Transform parent in parentObject.transform)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in parent)
            {
                children.Add(child);
            }
            parentChildMap[parent.name] = children;
        }
    }

    private void PopulateDropdownList()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(new List<string>(parentChildMap.Keys));
    }

    public void OnDropdownValueChanged(int index)
    {
        string selectedParentName = dropdown.options[index].text;

        // Clear existing toggles from the container
        foreach (Transform child in layoutGroup.transform)
        {
            Destroy(child.gameObject);
        }

        if (parentChildMap.ContainsKey(selectedParentName))
        {
            List<Transform> children = parentChildMap[selectedParentName];
            foreach (Transform child in children)
            {
                // Instantiate the toggle under the toggle container
                Toggle toggle = Instantiate(togglePrefab, layoutGroup.transform);
                toggle.GetComponentInChildren<Text>().text = child.name;
                toggles.Add(toggle);

                toggle.onValueChanged.AddListener((isOn) => OnToggleValueChanged(isOn, toggle));
            }
        }

        // Force a layout update to arrange the toggles in a column
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
    }

    private void OnToggleValueChanged(bool isOn, Toggle toggle)
    {
        // Implement your logic here when a toggle value changes
    }

    public List<string> GetSelectedToggleNames()
    {
        List<string> selectedToggleNames = new List<string>();
        foreach (Toggle t in toggles)
        {
            if (t.isOn)
            {
                selectedToggleNames.Add(t.GetComponentInChildren<Text>().text);
            }
        }
        return selectedToggleNames;
    }

    public string GetSelectedObjectName()
    {
        // Implement your logic to get the selected object name
        // This method should return the selected object name as a string
        return "";
    }
}