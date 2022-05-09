using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxWidth;
    [SerializeField] private float _minWidth;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    public void TryMoveLeft()
    {
        if(transform.position.x - _stepSize > _minWidth)
            SetNextPosition(-_stepSize);
    }

    public void TryMoveRight()
    {
        if(transform.position.x + _stepSize < _maxWidth)
            SetNextPosition(_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
    }




}
