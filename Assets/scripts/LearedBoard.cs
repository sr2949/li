using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using UnityEngine.EventSystems;


public class LearedBoard : MonoBehaviour
{
    public Button nameInputBtn;
    //public InputField nameInput;
    [SerializeField]
    private List<Text> names;
    [SerializeField]
    private List<Text> scores;
    public InputField codeEnter;
    private float score = Timer.finalScore; 
    private string publicLeaderboardKey = "430b08ef25d7da7da1b02b41a6c7033c1c97d25621e7fb4bd39c2703448d1f1b";


    public GameObject message;
    public GameObject enterName;
    public GameObject TotalleaderBoard;
    // Start is called before the first frame update
    void Start()
    {
        codeEnter.onEndEdit.AddListener(SubmitInput);
        message.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            for (int i = 0; i < names.Count; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));

    }
    public void SubmitScore()
    {
        SetLeaderboardEntry(codeEnter.text, Mathf.RoundToInt(score));
        codeEnter.text = "";
    }
    public void SetLeaderboardEntry(string username, float score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, (int)score, ((msg) =>
        {
            GetLeaderboard();
        }));
        showLeaderBoard();
    }

    public void hideNames()
    {
        message.SetActive(false);
        enterName.SetActive(true);
        TotalleaderBoard.SetActive(false);
    }
    public void showLeaderBoard()
    {
        message.SetActive(false);
        enterName.SetActive(false);
        TotalleaderBoard.SetActive(true);
    }

    public void SubmitInput(string Input)
    {
        SetLeaderboardEntry(codeEnter.text, Mathf.RoundToInt(score));
        codeEnter.text = "";
        showLeaderBoard();
    }

    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }

}
