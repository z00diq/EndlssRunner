using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _notOppositeEnemySpeed;

    public void SetNotOppositeEnemy()
    {
        _speed = _notOppositeEnemySpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
