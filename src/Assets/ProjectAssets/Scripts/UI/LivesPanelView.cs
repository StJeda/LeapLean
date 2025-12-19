using UnityEngine;
using UnityEngine.UI;

public class LivesPanelView : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;

    public void SetLives(int lives)
    {
        if (_hearts == null) return;

        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i].enabled = i < lives;
    }
}
