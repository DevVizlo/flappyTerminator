using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class InputHandler : MonoBehaviour
{
    private PlayerMover _player;
    private FireRocket _rocket;

    private bool _isMoveUp;
    private bool _isMoveDown;
    private bool _isShoot;

    private void Start()
    {
        _player = GetComponent<PlayerMover>();
        _rocket = GetComponent<FireRocket>();
    }

    private void Update()
    {
        _isMoveUp = Input.GetKey(KeyCode.W);
        _player.MoveUp(_isMoveUp);

        _isMoveDown = Input.GetKey(KeyCode.S);
        _player.MoveDown(_isMoveDown);

        _isShoot = Input.GetKeyDown(KeyCode.Space);
        _rocket.RocketShoot(_isShoot);
    }
}
