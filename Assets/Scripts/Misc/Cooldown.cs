using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public bool Ready { get; private set; }
    private float _lastAct;
    [SerializeField] private float _cooldown;

    void Update()
    {
        if (!Ready)
        {
            Ready = _lastAct + _cooldown <= Time.time;
        }
    }

    public void Act()
    {
        Ready = false;
        _lastAct = Time.time;
    }
}
