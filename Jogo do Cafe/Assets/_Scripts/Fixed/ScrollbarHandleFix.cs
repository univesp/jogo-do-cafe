using UnityEngine;
using UnityEngine.UI;

public class ScrollbarHandleFix : MonoBehaviour
{
    [SerializeField] private Scrollbar sb;

    private void Start()
    {
        sb.value = 1;
        sb.size = 0;
    }

    public void ResetSize()
    {
        sb.size = 0;
    }
}
