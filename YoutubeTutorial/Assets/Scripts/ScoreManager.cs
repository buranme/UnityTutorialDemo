using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text jumpSpeedText;
    public Text moveSpeedText;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        jumpSpeedText.text = "Jump Speed: lll";
        moveSpeedText.text = "Move Speed:  lll";
    }

    public void UpdateJumpText()
    {
        jumpSpeedText.text += "l";
    }

    public void UpdateMoveText()
    {
        moveSpeedText.text += "l";
    }
}
