using UnityEngine;
using UnityEngine.EventSystems;

public class UISons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip pointerEnterClip;
    [SerializeField] private AudioClip pointerClickClip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(pointerEnterClip);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(pointerClickClip);
    }    
}
