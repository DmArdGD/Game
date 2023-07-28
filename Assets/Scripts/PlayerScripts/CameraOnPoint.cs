using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnPoint : MonoBehaviour
{
    public GameObject Player;

    public GameObject CanvasGrid;
    private bool CanVasGrid = true;

    public GameObject CamMain;
    private bool CamMaiN = false;

    public GameObject PhotoCam;
    private bool PhotoCAM = true;
    public GameObject Setka;
    private bool SetkA = true;

    public GameObject CaMTranC;
    private bool CamMTranc = true;
    public GameObject SetkaTranc;
    private bool SetkTranC = true;

    public GameObject CaMOP;
    private bool CamMOPP = true;
    public GameObject SetkaOP;
    private bool SetkaOPP = true;

    public GameObject CaMDP;
    private bool CamMDP = true;
    public GameObject SetkaDP;
    private bool SetkaDPP = true;

    public float movementDistance = 5f;
    private bool isFrozen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

            ToggleFreezeTransformations();

            CamMaiN = !CamMaiN;
            CamMain.SetActive(CamMaiN);

            //PhotoCam.SetActive(false);
            //SetkaDP.SetActive(false);

            //SetkaOP.SetActive(false);
            //CaMOP.SetActive(false);

            PhotoCAM = !PhotoCAM;
          PhotoCam.SetActive(PhotoCAM);

            //CanVasGrid = !CanVasGrid;
            //CanvasGrid.SetActive(CanVasGrid);
            //SetkTranC = !SetkTranC;
            //SetkaTranc.SetActive(SetkTranC);

        }
        //if (CaMTranC.activeSelf && CanvasGrid.activeSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.UpArrow))
        //    {
        //        //MoveForward();
        //        MoveForwardGR();
        //    }
        //    else if (Input.GetKeyDown(KeyCode.DownArrow))
        //    {
        //        //MoveBackward();
        //        MoveBackwardGR();
        //    }
        //    else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //    {
        //        //MoveLeft();
        //        MoveLeftGR();
        //    }
        //    else if (Input.GetKeyDown(KeyCode.RightArrow))
        //    {
        //       // MoveRight();
        //        MoveRightGR();  
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        //MoveUp();
        //        MoveUpGR(); 
        //    }
        //    else if (Input.GetKeyDown(KeyCode.LeftControl))
        //    {
        //        //MoveDown();
        //        MoveDownGR();   
        //    }
        //}






        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //        CamMaiN = !CamMaiN;
        //        CamMain.SetActive(CamMaiN);

        //        PhotoCAM = !PhotoCAM;
        //        PhotoCam.SetActive(PhotoCAM);
      
        //        Player.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        //        CamMain.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        //        PhotoCam.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);


        //}

        //if (PhotoCam.activeSelf /*&& Setka.activeSelf*/)
        //{
        //    CamRotiton();
        //}
    }









    void ToggleFreezeTransformations()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            isFrozen = !isFrozen;
            rigidbody.constraints = isFrozen ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.None;
        }
    }

    void MoveUp()
    {
        Vector3 newPosition1 = CaMTranC.transform.position + new Vector3(0f, movementDistance, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaTranc.transform.position + new Vector3(0f, movementDistance, 0f);
        SetkaTranc.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveUpGR()
    {
        Vector3 newPosition1 = CaMTranC.transform.position + new Vector3(0f, movementDistance, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = CanvasGrid.transform.position + new Vector3(0f, movementDistance, 0f);
        CanvasGrid.transform.position = newPosition2;

       // AdjustDistanceGR();
    }
    void MoveUpDP()
    {
        Vector3 newPosition1 = CaMDP.transform.position + new Vector3(0f, movementDistance, 0f);
        CaMDP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaDP.transform.position + new Vector3(0f, movementDistance, 0f);
        SetkaDP.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveUpOP()
    {
        Vector3 newPosition1 = CaMOP.transform.position + new Vector3(0f, movementDistance, 0f);
        CaMOP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaOP.transform.position + new Vector3(0f, movementDistance, 0f);
        SetkaOP.transform.position = newPosition2;

        AdjustDistanceOP();
    }
    void MoveDown()
    {
        Vector3 newPosition1 = CaMTranC.transform.position - new Vector3(0f, movementDistance, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaTranc.transform.position - new Vector3(0f, movementDistance, 0f);
        SetkaTranc.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveDownGR()
    {
        Vector3 newPosition1 = CaMTranC.transform.position - new Vector3(0f, movementDistance, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = CanvasGrid.transform.position - new Vector3(0f, movementDistance, 0f);
        CanvasGrid.transform.position = newPosition2;

       // AdjustDistanceGR();
    }
    void MoveDownDP()
    {
        Vector3 newPosition1 = CaMDP.transform.position - new Vector3(0f, movementDistance, 0f);
        CaMDP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaDP.transform.position - new Vector3(0f, movementDistance, 0f);
        SetkaDP.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveDownOP()
    {
        Vector3 newPosition1 = CaMOP.transform.position - new Vector3(0f, movementDistance, 0f);
        CaMOP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaOP.transform.position - new Vector3(0f, movementDistance, 0f);
        SetkaOP.transform.position = newPosition2;

        AdjustDistanceOP();
    }
    void MoveForward()
    {
        Vector3 newPosition1 = CaMTranC.transform.position - new Vector3(movementDistance, 0f, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaTranc.transform.position - new Vector3(movementDistance, 0f, 0f);
        SetkaTranc.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveForwardGR()
    {
        Vector3 newPosition1 = CaMTranC.transform.position - new Vector3(movementDistance, 0f, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = CanvasGrid.transform.position - new Vector3(movementDistance, 0f, 0f);
        CanvasGrid.transform.position = newPosition2;

       // AdjustDistanceGR();
    }
    void MoveForwardDP()
    {
        Vector3 newPosition1 = CaMDP.transform.position + new Vector3(0f, 0f, movementDistance);
        CaMDP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaDP.transform.position + new Vector3(0f, 0f, movementDistance);
        SetkaDP.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveForwardOP()
    {
        Vector3 newPosition1 = CaMOP.transform.position - new Vector3(movementDistance, 0f, 0f);
        CaMOP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaOP.transform.position - new Vector3(movementDistance, 0f, 0f);
        SetkaOP.transform.position = newPosition2;

        AdjustDistanceOP();
    }
    void MoveBackward()
    {
        Vector3 newPosition1 = CaMTranC.transform.position + new Vector3(movementDistance, 0f, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaTranc.transform.position + new Vector3(movementDistance, 0f, 0f);
        SetkaTranc.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveBackwardGR()
    {
        Vector3 newPosition1 =  CanvasGrid.transform.position + new Vector3(movementDistance, 0f, 0f);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = CanvasGrid.transform.position + new Vector3(movementDistance, 0f, 0f);
        CanvasGrid.transform.position = newPosition2;

       // AdjustDistanceGR();
    }
    void MoveBackwardDP()
    {
        Vector3 newPosition1 = CaMDP.transform.position - new Vector3(0f, 0f, movementDistance);
        CaMDP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaDP.transform.position - new Vector3(0f, 0f, movementDistance);
        SetkaDP.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveBackwardOP()
    {
        Vector3 newPosition1 = CaMOP.transform.position + new Vector3(movementDistance, 0f, 0f);
        CaMOP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaOP.transform.position + new Vector3(movementDistance, 0f, 0f);
        SetkaOP.transform.position = newPosition2;

        AdjustDistanceOP();
    }
    void MoveLeftGR()
    {
        Vector3 newPosition1 = CaMTranC.transform.position - new Vector3(0f, 0f, movementDistance);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = CanvasGrid.transform.position - new Vector3(0f, 0f, movementDistance);
        CanvasGrid.transform.position = newPosition2;

     //   AdjustDistanceGR();
    }
    void MoveLeft()
    {
        Vector3 newPosition1 = CaMTranC.transform.position - new Vector3(0f, 0f, movementDistance);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaTranc.transform.position - new Vector3(0f, 0f, movementDistance);
        SetkaTranc.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveLeftDP()
    {
        Vector3 newPosition1 = CaMDP.transform.position - new Vector3(movementDistance, 0f, 0f);
        CaMDP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaDP.transform.position - new Vector3(movementDistance, 0f, 0f);
        SetkaDP.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveLeftOP()
    {
        Vector3 newPosition1 = CaMOP.transform.position - new Vector3(0f, 0f, movementDistance);
        CaMOP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaOP.transform.position - new Vector3(0f, 0f, movementDistance);
        SetkaOP.transform.position = newPosition2;

        AdjustDistanceOP();
    }
    void MoveRight()
    {
        Vector3 newPosition1 = CaMTranC.transform.position + new Vector3(0f, 0f, movementDistance);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaTranc.transform.position + new Vector3(0f, 0f, movementDistance);
        SetkaTranc.transform.position = newPosition2;

        AdjustDistance();
    }
    void MoveRightGR()
    {
        Vector3 newPosition1 = CaMTranC.transform.position + new Vector3(0f, 0f, movementDistance);
        CaMTranC.transform.position = newPosition1;

        Vector3 newPosition2 = CanvasGrid.transform.position + new Vector3(0f, 0f, movementDistance);
        CanvasGrid.transform.position = newPosition2;

        //AdjustDistance();
    }
    void MoveRightDP()
    {
        Vector3 newPosition1 = CaMDP.transform.position + new Vector3(movementDistance, 0f, 0f);
        CaMDP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaDP.transform.position + new Vector3(movementDistance, 0f, 0f);
        SetkaDP.transform.position = newPosition2;

        AdjustDistanceDP();
    }
    void MoveRightOP()
    {
        Vector3 newPosition1 = CaMOP.transform.position + new Vector3(0f, 0f, movementDistance);
        CaMOP.transform.position = newPosition1;

        Vector3 newPosition2 = SetkaOP.transform.position + new Vector3(0f, 0f, movementDistance);
        SetkaOP.transform.position = newPosition2;

        AdjustDistanceOP();
    }
    void AdjustDistance()
    {
        // Calculate the distance between the objects
        float currentDistance = Vector3.Distance(CaMTranC.transform.position, SetkaTranc.transform.position);

        // Calculate the desired distance
        float desiredDistance = 15f;

        // Calculate the direction vector between the objects
        Vector3 direction = (SetkaTranc.transform.position - CaMTranC.transform.position).normalized;

        // Calculate the offset to adjust the positions
        Vector3 offset = direction * (desiredDistance - currentDistance) / 2f;

        // Apply the offset to maintain the desired distance
        CaMTranC.transform.position -= offset;
        SetkaTranc.transform.position += offset;
    }
    void AdjustDistanceGR()
    {
        // Calculate the distance between the objects
        float currentDistance = Vector3.Distance(CaMTranC.transform.position, CanvasGrid.transform.position);

        // Calculate the desired distance
        float desiredDistance = 0.1f;

        // Calculate the direction vector between the objects
        Vector3 direction = (CanvasGrid.transform.position - CaMTranC.transform.position).normalized;

        // Calculate the offset to adjust the positions
        Vector3 offset = direction * (desiredDistance - currentDistance) / 2f;

        // Apply the offset to maintain the desired distance
        CaMTranC.transform.position -= offset;
        CanvasGrid.transform.position += offset;
    }
    void AdjustDistanceDP()
    {
        // Calculate the distance between the objects
        float currentDistance = Vector3.Distance(CaMDP.transform.position, SetkaDP.transform.position);

        // Calculate the desired distance
        float desiredDistance = 15f;

        // Calculate the direction vector between the objects
        Vector3 direction = (SetkaDP.transform.position - CaMDP.transform.position).normalized;

        // Calculate the offset to adjust the positions
        Vector3 offset = direction * (desiredDistance - currentDistance) / 2f;

        // Apply the offset to maintain the desired distance
        CaMDP.transform.position -= offset;
        SetkaDP.transform.position += offset;
    }
    void AdjustDistanceOP()
    {
        // Calculate the distance between the objects
        float currentDistance = Vector3.Distance(CaMOP.transform.position, SetkaOP.transform.position);

        // Calculate the desired distance
        float desiredDistance = 15f;

        // Calculate the direction vector between the objects
        Vector3 direction = (SetkaOP.transform.position - CaMOP.transform.position).normalized;

        // Calculate the offset to adjust the positions
        Vector3 offset = direction * (desiredDistance - currentDistance) / 2f;

        // Apply the offset to maintain the desired distance
        CaMOP.transform.position -= offset;
        SetkaOP.transform.position += offset;
    }
    public void CamRotiton()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Player.transform.rotation *= Quaternion.Euler(0f, 90f, 0f);
            CamMain.transform.rotation *= Quaternion.Euler(0f, 90f, 0f);
            CaMTranC.transform.rotation *= Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Player.transform.rotation *= Quaternion.Euler(0f, -90f, 0f);
            CamMain.transform.rotation *= Quaternion.Euler(0f, -90f, 0f);
            CaMTranC.transform.rotation *= Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Player.transform.rotation *= Quaternion.Euler(-90f, 0f, 0f);
            CamMain.transform.rotation *= Quaternion.Euler(-90f, 0f, 0f);
            CaMTranC.transform.rotation *= Quaternion.Euler(-90f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Player.transform.rotation *= Quaternion.Euler(90f, 0f, 0f);
            CamMain.transform.rotation *= Quaternion.Euler(90f, 0f, 0f);
            CaMTranC.transform.rotation *= Quaternion.Euler(90f, 0f, 0f);
        }
    }

}



