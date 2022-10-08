using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardSO data;
    private BuffManager _buffManager;

    private void Awake() => _buffManager = FindObjectOfType<BuffManager>();

    private void OnMouseDown()
    {
        Add();
        Destroy(gameObject);
    }

    private void Add()
    {
        for (int i = 0; i < data.buffs.Count; i++)
        {
            _buffManager.Add(data.buffs[i]);
        }
    }
}