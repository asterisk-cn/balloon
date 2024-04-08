using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Camera m_MainCamera; // メインカメラ
    Vector3 BottomLeft;//左下
    Vector3 TopRight; //右上
    float Width; //x座標系、幅
    float Height; //y座標系、高さ
    float ObjectWidth; //オブジェクトの幅
    float ObjectHeight; //オブジェクトの高さ
    // Start is called before the first frame update

    void Start()
    {
        m_MainCamera = Camera.main;
        //カメラ領域の左下の座標を取得
        BottomLeft = m_MainCamera.ScreenToWorldPoint(Vector3.zero);
        // カメラ領域の右上の座標を取得
        TopRight = m_MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        //オブジェクトの幅・高さを取得
        // ObjectWidth = this.GetComponent<MeshRenderer>().bounds.size.x;
        // ObjectHeight = this.GetComponent<MeshRenderer>().bounds.size.y;
        //カメラの領域の幅・高さをワールド座標系数値で取得
        Width = (TopRight.x - BottomLeft.x) ;
        Height = (TopRight.y - BottomLeft.y) ;
        //上記二値からスケール（ローカル座標系）を調整
        // transform.localScale = new Vector3(Width/ ObjectWidth, Height/ ObjectHeight, 0);
        Debug.Log("Width: " + Width + " Height: " + Height);
    }
}