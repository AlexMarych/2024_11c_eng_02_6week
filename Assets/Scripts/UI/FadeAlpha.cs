using UnityEngine;

[RequireComponent(typeof(Cooldown))]
public class FadeAlpha : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _speed;
    private Cooldown _cooldown;
    private bool _fadeIn;

    void Start()
    {
        _cooldown = GetComponent<Cooldown>();
    }

    void Update()
    {
        if (_fadeIn)
        {
            if (_canvasGroup.alpha < 1)
                _canvasGroup.alpha += _speed;
            _fadeIn = !_cooldown.Ready;
        }
        else
            if(_canvasGroup.alpha > 0)
                _canvasGroup.alpha -= _speed;
    }

    public void StartFade()
    {
        _cooldown.Act();
        _fadeIn = !_cooldown.Ready;
    }
}
