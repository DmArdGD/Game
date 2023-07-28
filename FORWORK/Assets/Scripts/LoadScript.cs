using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{
    public GameObject cloneParent; // Reference to the parent object of the instantiated clones
    public Button loadButton;
    public Button clearButton;
    private string bundleFolderPath = "D:\\SERV";
    private List<GameObject> instantiatedClones;
    private DropdownloadWithChildren dropdownScript;
  

    private void Start()
    {
       
        dropdownScript = GetComponent<DropdownloadWithChildren>();
        loadButton.onClick.AddListener(ButtonLoadSelectedBundles);
        clearButton.onClick.AddListener(ClearSelectedClones);
        instantiatedClones = new List<GameObject>();
    }

    public void ButtonLoadSelectedBundles()
    {
        List<string> selectedToggleNames = dropdownScript.GetSelectedToggleNames();
        LoadSelectedBundles(selectedToggleNames);
    }

    public void LoadSelectedBundles(List<string> selectedToggleNames)
    {
        // Clear previous loaded bundles if necessary
        ClearClones();

        foreach (string toggleName in selectedToggleNames)
        {
            // Load the bundle corresponding to the toggle name
            StartCoroutine(DownloadAndCache(toggleName));
        }
    }

    IEnumerator DownloadAndCache(string toggleName)
    {
      

        while (!Caching.ready)
            yield return null;

        var selectedObjectName = dropdownScript.GetSelectedObjectName();
        string bundleUrl = Path.Combine(bundleFolderPath, toggleName);
        int version = 0;
        var www = new WWW(bundleUrl);

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        Debug.Log("Bundle загружен" + toggleName);

        var assetBundle = www.assetBundle;

        var modelRequest = assetBundle.LoadAssetAsync<GameObject>(toggleName);
        yield return modelRequest;
        Vector3 PrefabPosition = modelRequest.asset.GameObject().transform.position;
        Quaternion PrefabRotation = modelRequest.asset.GameObject().transform.rotation;
        var loadedObject = Instantiate(modelRequest.asset, PrefabPosition,PrefabRotation, cloneParent.transform);
        instantiatedClones.Add(loadedObject as GameObject);
        Debug.Log("Модель создана");

        assetBundle.Unload(false); 

        foreach (GameObject go in instantiatedClones)
        {
            Debug.Log(go.name);
        }
    }

    public void ClearSelectedClones()
    {
        List<string> selectedToggleNames = dropdownScript.GetSelectedToggleNames();

        foreach (string toggleName in selectedToggleNames)
        {
            string cloneName = toggleName + "(Clone)";
          

            try
            {
                // GameObject clone;
                GameObject clone = GameObject.Find(cloneName);

                if (clone != null && !clone.GetComponent<Toggle>() == true )
                {
                    Destroy(clone);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                throw;
            }
            
        }

        // Clear the selected toggle names
        selectedToggleNames.Clear();
    }
    public void ClearClones()
    {
        foreach (GameObject clone in instantiatedClones)
        {
            Destroy(clone);
        }
        instantiatedClones.Clear();
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using UnityEngine.UI;

//public class LoadScript : MonoBehaviour
//{
//    string bundleFolderPath = "C:\\Users\\Дмитрий\\Desktop\\Ардашкин\\серв";
//    private DropdownloadWithChildren dropdownScript;

//    private void Start()
//    {
//        dropdownScript = GetComponent<DropdownloadWithChildren>();
//        if (dropdownScript == null)
//        {
//            Debug.LogError("Dropdown script is not assigned.");
//        }
//    }

//    // Create a new public method to be bound to the button
//    public void ButtonLoadSelectedBundles()
//    {
//        if (dropdownScript == null)
//        {
//            Debug.LogError("Dropdown script is not assigned.");
//            return;
//        }

//        List<string> selectedToggleNames = dropdownScript.GetSelectedToggleNames();
//        LoadSelectedBundles(selectedToggleNames);
//    }

//    public void LoadSelectedBundles(List<string> selectedToggleNames)
//    {
//        // Clear previous loaded bundles if necessary

//        foreach (string toggleName in selectedToggleNames)
//        {
//            // Load the bundle corresponding to the toggle name
//            StartCoroutine(DownloadAndCache(toggleName));
//        }
//    }

//    IEnumerator DownloadAndCache(string toggleName)
//    {
//        while (!Caching.ready)
//            yield return null;

//        var selectedObjectName = dropdownScript.GetSelectedObjectName();
//        string bundleUrl = Path.Combine(bundleFolderPath, toggleName);
//        int version = 0;
//        var www = new WWW(bundleUrl);

//        yield return www;

//        if (!string.IsNullOrEmpty(www.error))
//        {
//            Debug.Log(www.error);
//            yield break;
//        }
//        Debug.Log("Bundle загружен" + toggleName);

//        var assetBundle = www.assetBundle;

//        var modelRequest = assetBundle.LoadAssetAsync<GameObject>(toggleName);
//        yield return modelRequest;

//        var loadedObject = Instantiate(modelRequest.asset, Vector3.zero, Quaternion.identity);
//        Debug.Log("Модель создана");

//        assetBundle.Unload(false);
//    }
//}
