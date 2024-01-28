using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class HighScoreService : Singleton<HighScoreService>
{
    private const int MAX_HIGH_SCORES = 10;
    private const string SAVE_KEY = "HighScores";

    public int DefaultHighScore => 150; 
    
    public List<HighScoreModel> HighScores { get; private set; } = new List<HighScoreModel>();
    
    public void LoadHighScores()
    {
        JsonConvert.SerializeObject(HighScores);
    }

    public bool IsNewHighScore(int newHighScore)
    {
        if (HighScores.Count < MAX_HIGH_SCORES)
        {
            return true;
        }
        
        for (int i = 0; i < HighScores.Count; i++)
        {
            if (HighScores[i].Score < newHighScore)
            {
                return true;
            }
        }

        return false;
    }

    public void AddHighScore(string name, int highScore)
    {
        int index = HighScores.FindIndex(highScoreModel => highScoreModel.Score < highScore);
        HighScores.Insert(0, new HighScoreModel(name, highScore));
        HighScores.RemoveAt(HighScores.Count-1);
     }
}
