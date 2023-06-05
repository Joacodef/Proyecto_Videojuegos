using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour {

    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "3d0bd7887d21728a37f8731afafff4b614ba4d1d4b0c31ca584df031f8399563";

    private void Start() {
        GetLeaderboard();
    }

    public void GetLeaderboard() {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; ++i) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score) {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => {
            GetLeaderboard();
        }));
    }
}
