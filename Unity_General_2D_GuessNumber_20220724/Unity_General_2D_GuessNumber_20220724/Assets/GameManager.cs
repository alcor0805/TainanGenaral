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
        UpdateHintMessage("�п�J 0~99 ���Ʀr");
    }

    void Update()
    {
        
    }

    void UpdateHintMessage(string message)
    {
        hintMessage.text = message;
    }
}
