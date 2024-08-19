using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;
public class ChatSystem : MonoBehaviour
{
    private int id = 0;
    private DateTime dt;
    // firebase database インスタンス
    public static FirebaseFirestore db;
    // Mine用
    public static DocumentReference docRefMine;

    [SerializeField] InputField chatInputField;
    [SerializeField] GameObject chatNodePrefab;
    [SerializeField] GameObject content;
    void Start()
    {
        // Firebase databaseインスタンス作成
        db = FirebaseFirestore.DefaultInstance;

        // Firestoreからデータを取得して表示する
        LoadChatLogs();

    }
    public void OnClickMineButton()
    {
        CreateChatNode(ChatRoll.MINE);

    }
    public void OnClickOthersButton()
    {
        CreateChatNode(ChatRoll.OTHERS);
    }
    private void CreateChatNode(ChatRoll roll)
    {
        // 時刻の取得
        dt = DateTime.Now;
        // 時刻を文字列に変換
        // db格納キーとして使用
        string dt_str = dt.Year.ToString("0000") + "_" + dt.Month.ToString("00") + "_" + dt.Day.ToString("00") + "_" + dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00");
        Debug.Log(dt_str);

        id++;
        // InputFiledの値取得
        string str = chatInputField.text;
        chatInputField.text = ""; //　InputFiled値の初期化
        
        ChatData data = new ChatData(dt, roll, str);
        
        Debug.Log("dt:" + data.dt.ToString() + " roll:" + roll.ToString() + " body:" + str);
        
        // ***** 開始 *****
        var chatNode = Instantiate<GameObject>(chatNodePrefab, content.transform, false);
        chatNode.GetComponent<ChatNode>().Init(data);
        // ***** 終了 *****

        // firebase databse 登録
        docRefMine = db.Collection("chatlog").Document(dt_str);
        
        Dictionary<string, object> log = new Dictionary<string, object>{
            { "Roll", roll.ToString() },
            { "Time", dt.ToString("yyyy/MM/dd HH:mm:ss") },
            { "Text", str }
        };

        docRefMine.SetAsync(log).ContinueWithOnMainThread(task => {
            Debug.Log("Added data");
        });   
        
    }

    // DBからLogデータの読み込み 
    private void LoadChatLogs()
    {
        Firebase.Firestore.Query allChatLogQuery = db.Collection("chatlog");
        allChatLogQuery.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot allChatLogQuerySnapshot = task.Result;

            foreach (DocumentSnapshot documentSnapshot in allChatLogQuerySnapshot.Documents)
            {
                Dictionary<string, object> chatlogs = documentSnapshot.ToDictionary();

                // ChatDataのパース
                DateTime logTime = DateTime.Parse(chatlogs["Time"].ToString());
                ChatRoll logRoll = (ChatRoll)Enum.Parse(typeof(ChatRoll), chatlogs["Roll"].ToString());
                string logText = chatlogs["Text"].ToString();

                ChatData data = new ChatData(logTime, logRoll, logText);

                // ChatNodeをインスタンス化
                var chatNode = Instantiate<GameObject>(chatNodePrefab, content.transform, false);
                chatNode.GetComponent<ChatNode>().Init(data);

                Debug.Log($"Loaded log: {documentSnapshot.Id}");
            }
        });
    }
}

public enum ChatRoll
{
    MINE,
    OTHERS,
}
public class ChatData
{
    //public int id;
    public DateTime dt;
    public ChatRoll roll;
    public string body;
    public ChatData(DateTime dt, ChatRoll roll, string body)
    {
        this.dt = dt;
        this.roll = roll;
        this.body = body;
    }
}