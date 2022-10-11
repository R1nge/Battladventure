using UnityEngine;

public class CardManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject blockInput;

    public void BlockInput() => blockInput.SetActive(true);

    public void UnlockInput() => blockInput.SetActive(false);
}