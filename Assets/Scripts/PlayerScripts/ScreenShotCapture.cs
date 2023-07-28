using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShotCapture : MonoBehaviour
{
    private void Update()
    {
        ScreenShotMaker();
    }
    public void ScreenShotMaker()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var dateTimeOfTheScreenShot = DateTimeOfTheScreenShot();
            {
                Directory.CreateDirectory(ScreenShotsPath);

                while (File.Exists($"{ScreenShotsPath}/{dateTimeOfTheScreenShot}")) { }

                ScreenCapture.CaptureScreenshot($"{ScreenShotsPath}/{dateTimeOfTheScreenShot}");

            }

        }

    }

    public string DateTimeOfTheScreenShot()
    {
        return $"{DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}.{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}.{DateTime.Now.Millisecond}.png";
    }

    public string ScreenShotsPath { get; private set; } = "D:\\ScreenShotsUnity";
}
