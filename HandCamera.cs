using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class HandCamera : MonoBehaviour
{
    Camera cam;
    public int count = 0;

    public GameObject Thumb_Prox_pos;
    public GameObject Thumb_Inter_pos;
    public GameObject Thumb_Distal_pos;

    public GameObject Index_Prox_pos;
    public GameObject Index_Inter_pos;
    public GameObject Index_Distal_pos;

    public GameObject Middle_Prox_pos;
    public GameObject Middle_Inter_pos;
    public GameObject Middle_Distal_pos;

    public GameObject Ring_Prox_pos;
    public GameObject Ring_Inter_pos;
    public GameObject Ring_Distal_pos;

    public GameObject Pinky_Prox_pos;
    public GameObject Pinky_Inter_pos;
    public GameObject Pinky_Distal_pos;

    string folderPath = Directory.GetCurrentDirectory();

    string imgfolderPath;
    string metafolderPath;

    string imgfolderName = "/Hand/ImageData/";
    string metafolderName = "/Hand/MetaData/";


    public void SaveData(Vector2 Thumb_Prox, Vector2 Thumb_Inter, Vector2 Thumb_Distal, 
                        Vector2 Index_Prox, Vector2 Index_Inter, Vector2 Index_Distal, 
                        Vector2 Middle_Prox, Vector2 Middle_Inter, Vector2 Middle_Distal, 
                        Vector2 Ring_Prox, Vector2 Ring_Inter, Vector2 Ring_Distal,
                        Vector2 Pinky_Prox, Vector2 Pinky_Inter, Vector2 Pinky_Distal){

        string filename = Path.Combine(metafolderPath, (count.ToString()+ ".txt"));

        string[] lines = {Thumb_Prox.ToString() + Thumb_Inter.ToString() + Thumb_Distal.ToString(),
                                Index_Prox.ToString() + Index_Inter.ToString() + Index_Distal.ToString(), 
                                Middle_Prox.ToString() + Middle_Inter.ToString() + Middle_Distal.ToString(), 
                                Ring_Prox.ToString() + Ring_Inter.ToString() + Ring_Distal.ToString(), 
                                Pinky_Prox.ToString() + Pinky_Inter.ToString() + Pinky_Distal.ToString()};

        File.WriteAllLines(filename, lines);
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        Thumb_Prox_pos = GameObject.Find("Right_ThumbProximal");
        Thumb_Inter_pos = GameObject.Find("Right_ThumbIntermediate");
        Thumb_Distal_pos = GameObject.Find("Right_ThumbDistal");

        Index_Prox_pos = GameObject.Find("Right_IndexProximal");
        Index_Inter_pos = GameObject.Find("Right_IndexIntermediate");
        Index_Distal_pos = GameObject.Find("Right_IndexDistal");

        Middle_Prox_pos = GameObject.Find("Right_MiddleProximal");
        Middle_Inter_pos = GameObject.Find("Right_MiddleIntermediate");
        Middle_Distal_pos = GameObject.Find("Right_MiddleDistal");

        Ring_Prox_pos = GameObject.Find("Right_RingProximal");
        Ring_Inter_pos = GameObject.Find("Right_RingIntermediate");
        Ring_Distal_pos = GameObject.Find("Right_RingDistal");

        Pinky_Prox_pos = GameObject.Find("Right_PinkyProximal");
        Pinky_Inter_pos = GameObject.Find("Right_PinkyIntermediate");
        Pinky_Distal_pos = GameObject.Find("Right_PinkyDistal");

        imgfolderPath = folderPath + imgfolderName;
        metafolderPath = folderPath + metafolderName;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Thumb_Prox_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Thumb_Prox_pos.transform.position);
        Vector2 Thumb_Inter_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Thumb_Inter_pos.transform.position);
        Vector2 Thumb_Distal_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Thumb_Distal_pos.transform.position);

        Vector2 Index_Prox_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Index_Prox_pos.transform.position);
        Vector2 Index_Inter_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Index_Inter_pos.transform.position);
        Vector2 Index_Distal_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Index_Distal_pos.transform.position);

        Vector2 Middle_Prox_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Middle_Prox_pos.transform.position);
        Vector2 Middle_Inter_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Middle_Inter_pos.transform.position);
        Vector2 Middle_Distal_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Middle_Distal_pos.transform.position);

        Vector2 Ring_Prox_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Ring_Prox_pos.transform.position);
        Vector2 Ring_Inter_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Ring_Inter_pos.transform.position);
        Vector2 Ring_Distal_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Ring_Distal_pos.transform.position);

        Vector2 Pinky_Prox_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Pinky_Prox_pos.transform.position);
        Vector2 Pinky_Inter_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Pinky_Inter_pos.transform.position);
        Vector2 Pinky_Distal_screenPos = RectTransformUtility.WorldToScreenPoint (cam, Pinky_Distal_pos.transform.position);

        ScreenCapture.CaptureScreenshot(Path.Combine(imgfolderPath, (count.ToString()+ ".png")));

        SaveData(Thumb_Prox_screenPos, Thumb_Inter_screenPos, Thumb_Distal_screenPos, 
                    Index_Prox_screenPos, Index_Inter_screenPos, Index_Distal_screenPos, 
                    Middle_Prox_screenPos, Middle_Inter_screenPos, Middle_Distal_screenPos, 
                    Ring_Prox_screenPos, Ring_Inter_screenPos, Ring_Distal_screenPos,
                    Pinky_Prox_screenPos, Pinky_Inter_screenPos, Pinky_Distal_screenPos);
        
        count++;
    }
}
