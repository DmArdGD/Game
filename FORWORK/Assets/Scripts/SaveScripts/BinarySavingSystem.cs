using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySavingSystem // static - нам нужна всего одна копия этого класса
{
   
    
    public static void SaveScene(Transform parentObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/scene.txt";
       // string path = Application. + "/scene.b";
        FileStream stream = new FileStream(path, FileMode.Create);

        SceneData data = new SceneData(parentObject);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static SceneData LoadScene()
    {
        string path = Application.persistentDataPath + "/scene.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SceneData data = formatter.Deserialize(stream) as SceneData;
            stream.Close();
            
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
