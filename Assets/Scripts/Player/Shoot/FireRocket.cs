using System.Collections;
using UnityEngine;

public class FireRocket : MonoBehaviour
{
    [SerializeField] private ParticleSystem _rocket;
    [SerializeField] private float _recharge;
    [SerializeField] private AudioSource _rocketStartSound;

    private float _nextActionTime = 0f;

    public void RocketShoot(bool isShoot)
    {
        if (Time.time >= _nextActionTime)
        {
            if (isShoot)
                StartCoroutine(CouldDown());
        }
    }

    private IEnumerator CouldDown()
    {
        _nextActionTime = Time.time + _recharge;
        _rocket.Play();
        _rocketStartSound.Play();

        yield return new WaitForSeconds(.1f);
    }
}
