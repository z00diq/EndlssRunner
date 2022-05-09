using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionY;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionY += _speed * Time.deltaTime;

        if (_imagePositionY > 1)
            _imagePositionY = 0;

        _image.uvRect = new Rect(0, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }
}
