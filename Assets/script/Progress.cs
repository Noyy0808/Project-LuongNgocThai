using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Progress : MonoBehaviour
{
    public Transform a; // Khai b�o ?i?m b?t ??u
    public Transform b; // Khai b�o ?i?m k?t th�c
    public Transform character; // Khai b�o nh�n v?t
    public Slider slider; // Khai b�o thanh slider


    private void Start()
    {
        slider.value = 0;
    }
    void Update()
    {
        if (character == null)
        {
            character = GameObject.FindGameObjectWithTag("Player").transform;
        }
        float distanceFromStart = Vector2.Distance(a.position, character.position);
        float totalDistance = Vector2.Distance(a.position, b.position);
        float ratio = distanceFromStart / totalDistance;
        slider.value = ratio * (slider.maxValue - slider.minValue) + slider.minValue;
    }
}
