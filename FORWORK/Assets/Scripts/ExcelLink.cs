using System.Data;
using System.IO;
using UnityEngine;
using ExcelDataReader;
using System.Diagnostics;
using System.Threading;



public class ExcelLink : MonoBehaviour
{
    private string excelFolderPath = "C:\\Users\\Дмитрий\\Desktop\\"; // Путь к файлу Excel
    private int rowIndex = -1; // Индекс строки, полученный из функции нажатия кнопки "E"
    // Имя объекта, которое мы ищем в таблице Excel
    //public string objectNameToFind;
    private bool isMouseOver = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isMouseOver)
        {
            // Создаем объект для работы с файлом Excel
            string objectNameToFind = gameObject.name;
            string fileName = objectNameToFind + ".xlsx";
            string excelFilePath = Path.Combine(excelFolderPath, fileName);
          
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                // Создаем читатель Excel-файла
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Получаем таблицу Excel
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // Использовать первую строку таблицы в качестве заголовков столбцов
                        }
                    });

                    // Получаем первую таблицу в датасете
                    var table = result.Tables[0];

                    // Ищем имя объекта в столбце "A"
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
                        // Устанавливаем позицию курсора на найденную строку в Excel-файле
                        string cellAddress = string.Format("A{0}", rowIndex + 1);
                        //string cellAddress = string.Format("A{0}", rowIndex + 1);
                        UnityEngine.Debug.Log(string.Format("Найден объект {0} в строке {1}", objectNameToFind, rowIndex + 1));
                    }
                    else
                    {
                        UnityEngine.Debug.Log(string.Format("Объект {0} не найден в таблице Excel", objectNameToFind));
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && rowIndex != -1 && isMouseOver)
        {
            string objectNameToFind = gameObject.name;
            string fileName = objectNameToFind + ".xlsx";
            string filePath = Path.Combine(excelFolderPath, fileName);

            // Имя листа, на котором находится нужная ячейка
            string sheetName = "";

            // Номер строки, на которой находится нужная ячейка
            int rowNumber = rowIndex + 1;

            // Запускаем Excel
            var excel = new Process();

            // Указываем путь к Excel
            excel.StartInfo.FileName = "excel.exe";
            string cellAddress = string.Format("A{0}", rowIndex + 1);
            // Указываем аргументы
            excel.StartInfo.Arguments = string.Format("/x \"{0}\" /select,\"{1}!{2}\"", filePath, sheetName.Replace("\"", "\"\""), "A" + rowNumber);
            Thread.Sleep(1000);
            // Запускаем Excel с аргументами
            excel.Start();

            // Добавляем задержку в 1 секунду
            Thread.Sleep(1000);

            // Ожидаем закрытия Excel
            excel.WaitForExit();

            // Закрываем процесс Excel
            excel.Close();
        }

        //if (Input.GetKeyDown(KeyCode.R) && rowIndex != -1)
        //{
        //    string filePath = "C:\\Users\\Дмитрий\\Desktop\\Cube.xls";

        //    // Имя листа, на котором находится нужная ячейка
        //    string sheetName = "Новые зав.314";

        //    // Номер строки, на которой находится нужная ячейка
        //    int rowNumber = rowIndex + 1;

        //    // Запускаем Excel
        //    var excel = new Process();

        //    // Указываем путь к Excel
        //    excel.StartInfo.FileName = "excel.exe";

        //    // Указываем аргументы
        //    excel.StartInfo.Arguments = string.Format("/e \"{0}\" /select,\"{2}\"", filePath, sheetName, rowNumber);

        //    // Запускаем Excel с аргументами
        //    excel.Start();

        //    // Ожидаем закрытия Excel
        //    excel.WaitForExit();

        //    // Закрываем процесс Excel
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