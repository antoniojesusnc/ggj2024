using System;
using Newtonsoft.Json;

[Serializable]
public class HighScoreModel
{
    [JsonProperty("name")]
    public string Name { get; private set; }
    [JsonProperty("score")]
    public int Score { get; private set; }

    public HighScoreModel(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
