using UnityEngine;

public class HerpCoinCounter : MonoBehaviour
{
    [SerializeField]
    private int _money;

    public void AddSilver()
    {
        _money += 1;
        Debug.Log($"Silver coin added, Total: {_money}");
    }

    public void AddGold()
    {
        _money += 10;
        Debug.Log($"Gold coin added, Total: {_money}");
    }
}
