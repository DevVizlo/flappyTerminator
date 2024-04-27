using UnityEngine;

public class RocketPlayer : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        gameObject.SetActive(false);
        Debug.Log("Set");
    }
}
