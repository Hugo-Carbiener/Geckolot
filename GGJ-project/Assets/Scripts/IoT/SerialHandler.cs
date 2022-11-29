using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.IO.Ports;

public class SerialHandler : MonoBehaviour
{
    private SerialPort _serial;

    [SerializeField] private string serialPort = "COM1";
    [SerializeField] private int baudrate = 115200;

    private void Start()
    {
        _serial = new SerialPort(serialPort, baudrate);
        _serial.ReadTimeout = 1;
        _serial.NewLine = "\n";
        _serial.Open();
    }

    private void Update()
    {
        if (_serial.BytesToRead <= 0)
        {
            return;
        }
        //string message = "";
        try
        {
            string message = _serial.ReadLine();
            if (message != "")
            {
                if (message.Split(",").Length > 0)
                {
                    //Debug.Log("DIST : " + message.Split(",")[0]);
                    Debug.Log("X : " + message.Split(",")[0]);
                    Debug.Log("Y : " + message.Split(",")[1]);

                }
            }
        }
        catch(Exception e)
        {

        }
    }
}
