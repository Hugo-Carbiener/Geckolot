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
    public int isTakingPower;

    private PlayerController player;

    private void Start()
    {
        _serial = new SerialPort(serialPort, baudrate);
        _serial.ReadTimeout = 1;
        _serial.NewLine = "\n";
        _serial.Open();
        isTakingPower = 0;
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_serial.BytesToRead <= 0)
        {
            //Unity has received no bytes of information, then it will quit here.
            //before that, it sends to the arduino a message telling it to send the next frame the required informations
            _serial.WriteLine(5.ToString());
            return;
        }
        try
        {
            if(_serial.BytesToRead > 0)
            {
                //we receive the informations :
                string message = _serial.ReadLine();
                if (message != "")
                {
                    Debug.Log(" ----------------------------------------------------------------------- ");
                    Debug.Log(message);
                    if (message.Split(",").Length > 0)
                    {
                        Debug.Log("X : " + message.Split(",")[0]);
                        Debug.Log("Y : " + message.Split(",")[1]);
                        int x;
                        int y;
                        if (int.TryParse(message.Split(",")[0], out x) && int.TryParse(message.Split(",")[1], out y))
                        {
                            Debug.Log("CLEANED X : " + x);
                            Debug.Log("CLEANED Y : " + y);
                            player.IoTX = x;
                            player.IoTY = y;
                        }
                    }
                    Debug.Log(" ----------------------------------------------------------------------- ");

                }
                //we send the data of wether or not to light up the diode :
                _serial.WriteLine(isTakingPower.ToString());
            }

        }
        catch(Exception e)
        {

        }
    }
}
