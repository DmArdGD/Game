using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveTXTCoordinate : MonoBehaviour
{
   
    public void SaveTxt(string filename)
    {
        System.IO.File.AppendAllText("D:\\TestFile.txt", " Vector3 spawnPosition = new Vector3(data.objectPositions[i].x, data.objectPositions[i].y, data.objectPositions[i].z);");
    }
   
}
