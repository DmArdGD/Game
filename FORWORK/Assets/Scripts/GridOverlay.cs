//using UnityEngine;

//[RequireComponent(typeof(Canvas))]
//public class GridOverlay : MonoBehaviour
//{
//    public int gridSizeX = 10; // Number of grid lines horizontally
//    public int gridSizeY = 10; // Number of grid lines vertically
//    public float gridSpacing = 50f; // Spacing between grid lines
//    public float lineThickness = 2f; // Thickness of the grid lines

//    private void Start()
//    {
//        GenerateGridLines();
//    }

//    private void GenerateGridLines()
//    {
//        RectTransform canvasRect = GetComponent<RectTransform>();
//        float canvasWidth = canvasRect.rect.width;
//        float canvasHeight = canvasRect.rect.height;

//        float startX = -canvasWidth / 2;
//        float startY = -canvasHeight / 2;

//        for (int i = 0; i <= gridSizeX; i++)
//        {
//            float xPos = startX + (i * gridSpacing);
//            DrawGridLine(new Vector2(xPos, startY), new Vector2(xPos, -startY));
//        }

//        for (int j = 0; j <= gridSizeY; j++)
//        {
//            float yPos = startY + (j * gridSpacing);
//            DrawGridLine(new Vector2(startX, yPos), new Vector2(-startX, yPos));
//        }
//    }

//    private void DrawGridLine(Vector2 startPos, Vector2 endPos)
//    {
//        GameObject gridLine = new GameObject("GridLine", typeof(RectTransform), typeof(UnityEngine.UI.Image), typeof(LineRenderer));
//        gridLine.transform.SetParent(transform);

//        RectTransform lineRectTransform = gridLine.GetComponent<RectTransform>();
//        lineRectTransform.pivot = Vector2.zero;
//        lineRectTransform.anchoredPosition = Vector2.zero;
//        lineRectTransform.anchorMin = Vector2.zero;
//        lineRectTransform.anchorMax = Vector2.one;

//        UnityEngine.UI.Image image = gridLine.GetComponent<UnityEngine.UI.Image>();
//        image.enabled = false;

//        LineRenderer lineRenderer = gridLine.GetComponent<LineRenderer>();
//        lineRenderer.startWidth = lineThickness;
//        lineRenderer.endWidth = lineThickness;
//        lineRenderer.positionCount = 2;
//        lineRenderer.useWorldSpace = false;
//        lineRenderer.SetPositions(new Vector3[] { startPos, endPos });
//    }
//}
using UnityEngine;

public class GridOverlay : MonoBehaviour
{
    public int gridSizeX = 10; // Number of grid lines horizontally
    public int gridSizeY = 10; // Number of grid lines vertically
    public float gridSpacing = 50f; // Spacing between grid lines
    public float lineThickness = 2f; // Thickness of the grid lines

    private void Start()
    {
        GenerateGridLines();
    }

    private void GenerateGridLines()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float centerX = screenWidth / 2;
        float centerY = screenHeight / 2;

        float startX = -screenWidth / 2;
        float startY = -screenHeight / 2;

        for (int i = 0; i <= gridSizeX; i++)
        {
            float xPos = startX + (i * gridSpacing);
            DrawGridLine(new Vector2(xPos + centerX, startY + centerY), new Vector2(xPos + centerX, -startY + centerY));
        }

        for (int j = 0; j <= gridSizeY; j++)
        {
            float yPos = startY + (j * gridSpacing);
            DrawGridLine(new Vector2(startX + centerX, yPos + centerY), new Vector2(-startX + centerX, yPos + centerY));
        }
    }

    private void DrawGridLine(Vector2 startPos, Vector2 endPos)
    {
        GameObject gridLine = new GameObject("GridLine", typeof(UnityEngine.UI.Image));
        gridLine.transform.SetParent(transform);

        UnityEngine.UI.Image image = gridLine.GetComponent<UnityEngine.UI.Image>();
        image.color = Color.black;

        RectTransform lineRectTransform = gridLine.GetComponent<RectTransform>();
        lineRectTransform.anchorMin = Vector2.zero;
        lineRectTransform.anchorMax = Vector2.zero;
        lineRectTransform.pivot = Vector2.zero;
        lineRectTransform.anchoredPosition = startPos;

        // Set the length and thickness of the line
        float lineLength = Vector2.Distance(startPos, endPos);
        lineRectTransform.sizeDelta = new Vector2(lineLength * 2f, lineThickness);

        lineRectTransform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(endPos.y - startPos.y, endPos.x - startPos.x) * Mathf.Rad2Deg);
    }
}
