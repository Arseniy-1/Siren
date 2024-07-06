using System.Collections;
using UnityEngine;

public class SignalingSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    private float _currentSoundLevel = 0;
    private bool _isEmpty = true;

    private void Update()
    {
        _alarmSound.volume = _currentSoundLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Robber robber))
        {
            _isEmpty = false;
            StartCoroutine(UpStatus());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Robber robber))
            _isEmpty = true;
    }

    private IEnumerator UpStatus()
    {
        float alarmSoundStem = 0.1f;
        int delay = 1;
        var alarmDelay = new WaitForSeconds(delay);

        while (_isEmpty == false)
        {
            _currentSoundLevel += alarmSoundStem;
            yield return alarmDelay;
        }

        while (_currentSoundLevel > 0)
        {
            _currentSoundLevel -= alarmSoundStem;
            yield return alarmDelay;
        }
    }
}
