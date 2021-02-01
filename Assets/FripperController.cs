using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //はじいた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押したときに左フリッパーを動かす
        if((Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A))&& tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キーを押したときに右フリッパーを動かす
        if ((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D)) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //発展①
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetAngle(this.flickAngle);
        }
        //矢印キーを離したときにフリッパーを元に戻す
        if ((Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.A)) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.D)) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //発展①
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            SetAngle(this.defaultAngle);
        }
        
        //発展②
        if(Input.touchCount > 0)
        {
            //Touch構造体をゲットする
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2 && tag =="LeftFripperTag")
            {
                SetAngle(this.flickAngle);

                if (touch.phase == TouchPhase.Ended)
                {
                    SetAngle(this.flickAngle);
                }
            }

            if (touch.position.x > Screen.width / 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);

                if (touch.phase == TouchPhase.Ended)
                {
                    SetAngle(this.flickAngle);
                }
            }

        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}
