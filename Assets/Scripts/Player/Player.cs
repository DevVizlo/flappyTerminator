using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction DiedEvent;


    private void Die() => DiedEvent?.Invoke();
}
