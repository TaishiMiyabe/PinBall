using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//using UnityEngineではカバーできない？例えばGameObjectクラスはUnityEngine.GameObject...using UnityEngineしてるから、GameObjectでいいという認識。

public class BallController : MonoBehaviour
{
    //ボールが見える可能性があるz軸の最大値
    private float visiblePosZ = -6.5f;

    //gameoverを表示するテキスト
    private GameObject gameoverText;

    private float clearColor;
    

    // Start is called before the first frame update
    void Start()
    {
        clearColor = 1.0f;
        this.gameoverText = GameObject.Find("GameOverText");
        this.gameoverText.GetComponent<Text>().color = new Color(1, 1, 1, clearColor);
        //while (clearColor>0) {
        //    clearColor -= 0.1f;
        //    this.gameoverText.GetComponent<Text>().color = new Color(1, 1, 1, clearColor);
        //}
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
                this.gameoverText.GetComponent<Text>().color = new Color(1, 1, 1, clearColor);//これが必須。無しで42行目onlyだとテキストが消えていかない。…が、どう理解したらいい？

            }
        }
    }
}
