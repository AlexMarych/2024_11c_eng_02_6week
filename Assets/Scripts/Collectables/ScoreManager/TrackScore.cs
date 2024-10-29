using UnityEngine;

public class TrackScore : MonoBehaviour
{
    public int Score;
    private int _silverCoinCount;
    public int LastGoldCoinCount;
    public int GoldCoinCount;
    private FadeAlpha _fadeAlpha;

    public void IncrementCoinCount(Collectable.Type Type) 
    {
        switch (Type) 
        {
            case Collectable.Type.Silver:
                _silverCoinCount++;
                return;

            case Collectable.Type.Gold:
                GoldCoinCount++;
                GetComponent<FadeAlpha>().StartFade();
                GetComponent<CanvasTextEditor>().SetText(GoldCoinCount.ToString());
                return;
        }
    }

    //The methods SaveGoldCoinCount() and LoadLastGoldCoinCount() are used by the LevelManager of our scene on resets
    public void SaveGoldCoinCount()
    {
        LastGoldCoinCount = GoldCoinCount;
    }

    public void LoadLastGoldCoinCount()
    {
        GoldCoinCount = LastGoldCoinCount;
    }

    public void CalculateScore()
    {
        Score = _silverCoinCount * (int) Collectable.Type.Silver + GoldCoinCount * (int) Collectable.Type.Gold;
    }
}
