using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = transform.GetComponent<Button>();
    }

    public void ActiveButton()
    {
        button.interactable = true;
    }

    public void DeActivateButton()
    {
        button.interactable = false;
    }
}
