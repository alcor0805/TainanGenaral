using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InputField playerAnswerUI;
    public int playerAnswer;
    public int correctAnswer;
    //public Text hintMessage;
    public Button restartButton;
    //public TextMesh hintMessage;
    //public Texture hintMessage;


    void Start()
    {
        UpdateHintMessage("請輸入 0~99 的數字");
    }

    void Update()
    {
        
    }

    void UpdateHintMessage(string message)
    {
        hintMessage.text = message;
    }
}
