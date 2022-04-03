using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collegeManager : MonoBehaviour
{ 
    [SerializeField] Text HumanName;
    [SerializeField] GameObject HumanPanel;
    [SerializeField] Text messagetext;
    public string[] texts;//Unity上で入力するstringの配列
    int textNumber;//何番目のtexts[]を表示させるか
    string displayText;//表示させるstring
    int textCharNumber;//何文字目をdisplayTextに追加するか
    int displayTextSpeed; //全体のフレームレートを落とす変数
    bool click;//クリック判定
    bool textStop; //テキスト表示を始めるか
    [SerializeField] PlayerManager playerManager;

    private void Update()
    {
        if (textStop == true)
        {
            message();
        }
    }
    public void LieHumanEvent()
    {
        HumanPanel.SetActive(true);
        HumanName.text = "村人（嘘つき）";
        playerManager.MoveChangeFalse();
        Debug.Log("LeiHuman");
        textStop = true;
        texts = new string[4];
        texts[0] = "どうしたんだい？";
        texts[1] = "なるほど";
        texts[2] = "ボスを倒すために鍵が欲しいのね";
        texts[3] = "鍵ならさっき〇〇がとって草原の方に逃げていったよ。";
    }
    public void PureHumanEvent()
    {
        HumanName.text = "村人（本当）";
        HumanPanel.SetActive(true);
        playerManager.MoveChangeFalse();
        Debug.Log("PureHuman");
        textStop = true;
        texts = new string[4];
        texts[0] = "どうしたんだい？";
        texts[1] = "そうなんだ";
        texts[2] = "ボスのところに行くために鍵が欲しいのね";
        texts[3] = "鍵ならさっき〇〇がとって森の方に逃げていったよ。";
    }

    void message()
    {
        displayTextSpeed++;
        if (displayTextSpeed % 5 == 0)//５回に一回プログラムを実行するif文
        {

            if (textCharNumber != texts[textNumber].Length)//もしtext[textNumber]の文字列の文字が最後の文字じゃなければ
            {
                displayText = displayText + texts[textNumber][textCharNumber];//displayTextに文字を追加していく
                textCharNumber = textCharNumber + 1;//次の文字にする
            }
            else//もしtext[textNumber]の文字列の文字が最後の文字だったら
            {
                if (textNumber != texts.Length - 1)//もしtexts[]が最後のセリフじゃないときは
                {
                    if (click == true)//クリックされた判定
                    {
                        displayText = "";//表示させる文字列を消す
                        textCharNumber = 0;//文字の番号を最初にする
                        textNumber = textNumber + 1;//次のセリフにする
                    }
                }
                else //もしtexts[]が最後のセリフになったら
                {
                    if (click == true) //クリックされた判定
                    {
                        displayText = ""; //表示させる文字列も消す
                        textCharNumber = 0; //文字の番号を最初にする
                        textNumber = 0;
                        textStop = false; //セリフ表示を止める
                        HumanPanel.SetActive(false);
                        playerManager.MoveChangeTrue();
                    }
                }
            }

          messagetext.text = displayText;//画面上にdisplayTextを表示
            click = false;//クリックされた判定を解除
        }
        if (Input.GetMouseButton(0))//マウスをクリックしたら
        {
            click = true; //クリックされた判定にする
        }
    }
}
