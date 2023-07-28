using System.Collections;
using System.Collections.Generic;
using SETUtil.Extend;
using UnityEngine;

public class SceneDataSaveLoad : MonoBehaviour
{
    [SerializeField] private Transform _savingEnvironment;
    
    public void SaveScene()
    {
        BinarySavingSystem.SaveScene(_savingEnvironment);
    
    }

    public void LoadScene()
    {
        for (int i = 0; i < _savingEnvironment.childCount; i++)
        {
            Destroy(_savingEnvironment.GetChild(i).gameObject);
        }
        SceneData data = BinarySavingSystem.LoadScene();
        for (int i = 0; i < data.objectNames.Length; i++)
            
        {
            
            var prefabName = GetPrefabName(data, i);

            GameObject goToSpawn = Resources.Load<GameObject>($"ItemPrefabs/{prefabName}");
            Vector3 spawnPosition = new Vector3(data.objectPositions[i].x, data.objectPositions[i].y, data.objectPositions[i].z);
           Quaternion rotaionPosition = new Quaternion(data.objectRotations[i].x, data.objectRotations[i].y, data.objectRotations[i].z, data.objectRotations[i].w);
            Vector3 markerScale = new Vector3(data.objectScale[i].x, data.objectScale[i].y, data.objectScale[i].z);

            GameObject sceneObject = Instantiate(goToSpawn, spawnPosition, rotaionPosition);
            sceneObject.transform.SetParent(_savingEnvironment);
         
        }
    }
    public static void SaveTxt(string filename)
    {
        System.IO.File.AppendAllText("D:\\TestFile.txt", " Vector3 spawnPosition = new Vector3(data.objectPositions[i].x, data.objectPositions[i].y, data.objectPositions[i].z);");
    }

    private static string GetPrefabName(SceneData data, int i)
    {
        string prefabName = "";
        if (data.objectNames[i].IndexOf("(") > 0)
        {
            int bracketIndex = data.objectNames[i].IndexOf("(");
            int length = data.objectNames[i].Length;
            prefabName = data.objectNames[i].Remove(bracketIndex, data.objectNames[i].Length- bracketIndex); 
            
        }
        else
        {
            prefabName = data.objectNames[i];
        }

        return prefabName;
    }
}
