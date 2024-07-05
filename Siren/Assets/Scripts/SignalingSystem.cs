using UnityEngine;

public class SignalingSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    private float _currentSoundLevel = 0;
    private bool _isEmpty = true;

    private void Update()
    {
        CorrectStatus();
        _alarmSound.volume = _currentSoundLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Robber robber))
            _isEmpty = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Robber robber))
            _isEmpty = true;
    }

    private void CorrectStatus()
    {
        float soundStep = 0.1f;

        if (_isEmpty)
        {
            if (_currentSoundLevel < 0)
                _currentSoundLevel = 0;
            else if (_currentSoundLevel > 0)
                _currentSoundLevel -= soundStep * Time.deltaTime;
        }
        else
        {
            if (_currentSoundLevel > 1)
                _currentSoundLevel = 1;
            else if (_currentSoundLevel < 1)
                _currentSoundLevel += soundStep * Time.deltaTime;
        }
    }
}
