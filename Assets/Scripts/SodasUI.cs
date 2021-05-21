using UnityEngine;
using UnityEngine.UI;

public class SodasUI : MonoBehaviour
{
    [SerializeField] Image[] sodas = new Image[3];

    void Start()
    {
        for (int i = 0; i < sodas.Length; i++)
            sodas[i].enabled = false;
    }

    public void Show (int count)
    {
        if (count <= 3)
        {
            for (int i = 0; i < count; i++)
                sodas[i].enabled = true;
        }
    }
}
