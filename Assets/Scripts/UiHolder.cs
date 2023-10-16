
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UiHolder : MonoBehaviour
{
    public static BoolReactiveProperty UIOn = new BoolReactiveProperty(false);
    
    public Button uiSwitch;
    public TextMeshProUGUI text;
    
    void Start()
    {
        text.text = "UI " + (UIOn.Value ? "On" : "Off");
        uiSwitch.OnClickAsObservable().Subscribe(
            _ =>
            {
                UIOn.SetValueAndForceNotify(!UIOn.Value);
                text.text = "UI " + (UIOn.Value ? "On" : "Off");
            });
    }
    
}
