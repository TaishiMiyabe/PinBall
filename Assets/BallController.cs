using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性があるz軸の最大値
    private float visiblePosZ = -6.5f;

    //gameoverを表示するテキスト
    private GameObject gameoverText;

    //Scoreを表示するテキスト
    private GameObject ScoreText;
    private int GameScore;

    //gameoverTextの透明度
    private float clearColor;

    //ボールがぶつかるオブジェクトごとのスコア
    private int smallCloudScore = 100;
    private int largeCloudScore = 300;
    private int smallStarScore = 50;
    private int largeStarScore = 200;
    

    // Start is called before the first frame update
    void Start()
    {
        clearColor = 1.0f;
        this.gameoverText = GameObject.Find("GameOverText");
        this.gameoverText.GetComponent<Text>().color = new Color(1, 1, 1, clearColor);

        //Scoreテキストを取得
        this.ScoreText = GameObject.Find("Score");
        GameScore = 0;
        this.ScoreText.GetComponent<Text>().text = $"Score: {GameScore}";

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            clearColor = 1.0f;
            this.gameoverText.GetComponent<Text>().color = new Color(1, 1, 1, clearColor);
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        else
        {
            if (clearColor > 0.0f)//ゲーム開始直後にtextを表示して、徐々に透明にしてみたかった。
            {
                clearColor -= 0.01f;
                this.gameoverText.GetComponent<Text>().color = new Color(1, 1, 1, clearColor);//これが必須。無しで42行目onlyだとテキストが消えていかない。

            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "SmallStarTag")
        {
            GameScore += smallStarScore;
        }
        else if(other.gameObject.tag == "LargeStarTag")
        {
            GameScore += largeStarScore;
        }
        else if(other.gameObject.tag == "SmallCloudTag")
        {
            GameScore += smallCloudScore;
        }
        else if(other.gameObject.tag == "LargeCloudTag")
        {
            GameScore += largeCloudScore;
        }

        //衝突点数加算後に、得点表示を更新
        this.ScoreText.GetComponent<Text>().text = $"Score: {GameScore}";
    }
}
