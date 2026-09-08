using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI textbox;

    public void OnClick()
    {
        textbox.text = "I have changed";
    }
}
