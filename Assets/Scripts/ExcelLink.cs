using System.Data;
using System.IO;
using UnityEngine;
using ExcelDataReader;
using System.Diagnostics;
using System.Threading;



public class ExcelLink : MonoBehaviour
{
    private string excelFolderPath = "C:\\Users\\�������\\Desktop\\"; // ���� � ����� Excel
    private int rowIndex = -1; // ������ ������, ���������� �� ������� ������� ������ "E"
    // ��� �������, ������� �� ���� � ������� Excel
    //public string objectNameToFind;
    private bool isMouseOver = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isMouseOver)
        {
            // ������� ������ ��� ������ � ������ Excel
            string objectNameToFind = gameObject.name;
            string fileName = objectNameToFind + ".xlsx";
            string excelFilePath = Path.Combine(excelFolderPath, fileName);
          
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                // ������� �������� Excel-�����
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // �������� ������� Excel
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // ������������ ������ ������ ������� � �������� ���������� ��������
                        }
                    });

                    // �������� ������ ������� � ��������
                    var table = result.Tables[0];

                    // ���� ��� ������� � ������� "A"
                    rowIndex = -1;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow row = table.Rows[i];
                        if (row[0].ToString() == objectNameToFind)
                        {
                            rowIndex = i;
                            break;
                        }
                    }

                    if (rowIndex != -1)
                    {
                        // ������������� ������� ������� �� ��������� ������ � Excel-�����
                        string cellAddress = string.Format("A{0}", rowIndex + 1);
                        //string cellAddress = string.Format("A{0}", rowIndex + 1);
                        UnityEngine.Debug.Log(string.Format("������ ������ {0} � ������ {1}", objectNameToFind, rowIndex + 1));
                    }
                    else
                    {
                        UnityEngine.Debug.Log(string.Format("������ {0} �� ������ � ������� Excel", objectNameToFind));
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && rowIndex != -1 && isMouseOver)
        {
            string objectNameToFind = gameObject.name;
            string fileName = objectNameToFind + ".xlsx";
            string filePath = Path.Combine(excelFolderPath, fileName);

            // ��� �����, �� ������� ��������� ������ ������
            string sheetName = "";

            // ����� ������, �� ������� ��������� ������ ������
            int rowNumber = rowIndex + 1;

            // ��������� Excel
            var excel = new Process();

            // ��������� ���� � Excel
            excel.StartInfo.FileName = "excel.exe";
            string cellAddress = string.Format("A{0}", rowIndex + 1);
            // ��������� ���������
            excel.StartInfo.Arguments = string.Format("/x \"{0}\" /select,\"{1}!{2}\"", filePath, sheetName.Replace("\"", "\"\""), "A" + rowNumber);
            Thread.Sleep(1000);
            // ��������� Excel � �����������
            excel.Start();

            // ��������� �������� � 1 �������
            Thread.Sleep(1000);

            // ������� �������� Excel
            excel.WaitForExit();

            // ��������� ������� Excel
            excel.Close();
        }

        //if (Input.GetKeyDown(KeyCode.R) && rowIndex != -1)
        //{
        //    string filePath = "C:\\Users\\�������\\Desktop\\Cube.xls";

        //    // ��� �����, �� ������� ��������� ������ ������
        //    string sheetName = "����� ���.314";

        //    // ����� ������, �� ������� ��������� ������ ������
        //    int rowNumber = rowIndex + 1;

        //    // ��������� Excel
        //    var excel = new Process();

        //    // ��������� ���� � Excel
        //    excel.StartInfo.FileName = "excel.exe";

        //    // ��������� ���������
        //    excel.StartInfo.Arguments = string.Format("/e \"{0}\" /select,\"{2}\"", filePath, sheetName, rowNumber);

        //    // ��������� Excel � �����������
        //    excel.Start();

        //    // ������� �������� Excel
        //    excel.WaitForExit();

        //    // ��������� ������� Excel
        //    excel.Close();
        //}
    }
    void OnMouseEnter()
    {
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
    }
}