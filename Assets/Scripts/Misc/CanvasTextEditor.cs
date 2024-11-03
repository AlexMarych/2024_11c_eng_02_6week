using TMPro;
using UnityEngine;

public class CanvasTextEditor : MonoBehaviour
{
    [SerializeField] private TMP_Text _TMP_text;

    public void SetText(string text) { _TMP_text.text = text; }
}
