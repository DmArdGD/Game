using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class ObjectExcelOpener : MonoBehaviour
{
    private GameObject hoveredObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsMouseOverObject())
        {
            string objectName = hoveredObject.name;
            string excelFilePath = SearchForExcelFile(objectName);

            if (!string.IsNullOrEmpty(excelFilePath))
            {
                OpenExcelFile(excelFilePath);
            }
        }
    }

    private bool IsMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hoveredObject = hit.collider.gameObject;
            return true;
        }

        return false;
    }

    private string SearchForExcelFile(string objectName)
    {
        // Provide the directory path where your Excel files are located
        string directoryPath = "D:\\Desktop\\3D\\";

        // Search for Excel files with names matching the object name
        string[] excelFiles = Directory.GetFiles(directoryPath, "*.xlsx*")
            .Where(file => Path.GetFileNameWithoutExtension(file) == objectName)
            .ToArray();

        if (excelFiles.Length > 0)
        {
            return excelFiles[0]; // Return the first matching Excel file
        }

        return null;
    }

    private void OpenExcelFile(string filePath)
    {
        Process.Start(filePath);
    }
}
