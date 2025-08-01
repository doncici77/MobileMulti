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
        // UI�� �׻� ���̰�, ��ư�� �� �͸� �ѱ�
        clickButton.interactable = photonView.IsMine;

        // Ŭ�� �����ʵ� �� �͸� �߰�
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
