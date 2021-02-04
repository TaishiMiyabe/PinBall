using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//障害物オブジェクトすべてにアタッチしていたこのスクリプトに関しては、最終的に使わないことに。無念。
public class ScoreCalculator : MonoBehaviour
{

    private int smallCloudScore = 100;
    private int largeCloudScore = 300;
    private int smallStarScore = 50;
    private int largeStarScore = 200;

    private GameObject ScoreText;

    private int GameScore;

    // Start is called before the first frame update
    void Start()
    {
        this.ScoreText = GameObject.Find("Score");
        GameScore = 0;
        this.ScoreText.GetComponent<Text>().text = $"Score: {GameScore}";
    }

    // Update is called once per frame
    void Update()
    {
       // this.ScoreText.GetComponent<Text>().text = $"Score: {GameScore}";//スコア表示がグダグダになる…。
    }

    void OnCollisionEnter(Collision other)
    {
        //衝突したオブジェクトの種類によって加算される得点が変わる
        if (tag == "SmallStarTag")
        {
            GameScore += smallStarScore;
        }
        else if(tag == "LargeStarTag")
        {
            GameScore += largeStarScore;
        }
        else if(tag == "SmallCloudTag")
        {
            GameScore += smallCloudScore;
        }
        else if(tag == "LargeCloudTag")
        {
            GameScore += largeCloudScore;
        }
        //加算された後で表示の更新
        this.ScoreText.GetComponent<Text>().text = $"Score: {GameScore}";//スコア表示がグダグダになる…。
    }
}
