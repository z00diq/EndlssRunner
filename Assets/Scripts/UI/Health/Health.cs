using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Health : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0,1,_lerpDuration,Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, Destroy));
    }

    private void Destroy(float value)
    {
        _image.fillAmount = 0;
        Destroy(_image.gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private IEnumerator Filling(float startValue, float endValue, float duration,UnityAction<float> LerpingEnd)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }
        LerpingEnd?.Invoke(endValue);
    }
}
