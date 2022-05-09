using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{

    public Slider slide;
    [SerializeField] FloatVariable SensitivityObject;

    public void Awake()
    {
        slide.value = SensitivityObject.Value;
    }
}

