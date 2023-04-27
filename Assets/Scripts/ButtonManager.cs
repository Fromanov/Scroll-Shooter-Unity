using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject myText;

    public void OnButtonTextClick()
    {
        bool textSwitch = myText.activeSelf;
        myText.SetActive(!textSwitch);
    }
}
