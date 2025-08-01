using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviourPun
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI notMeText;
    public Button clickButton;

    private int myScore = 0;
    private int notMeScore = 0;

    void Start()
    {
        // UI는 항상 보이고, 버튼만 내 것만 켜기
        clickButton.interactable = photonView.IsMine;

        // 클릭 리스너도 내 것만 추가
        if (photonView.IsMine)
        {
            clickButton.onClick.AddListener(() =>
            {
                myScore++;
                scoreText.text = "Score: " + myScore;
                photonView.RPC("AddScoreToOthers", RpcTarget.Others);
            });
        }
    }

    [PunRPC]
    void AddScoreToOthers()
    {
        notMeScore++;
        notMeText.text = "NotMe: " + notMeScore;
    }
}
