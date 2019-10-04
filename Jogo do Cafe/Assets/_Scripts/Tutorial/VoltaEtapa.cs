using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class VoltaEtapa : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip entraClip;    

    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Color selecionado;

    [SerializeField] private UnityEvent action;

    public void OnPointerClick(PointerEventData eventData)
    {
        action.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(entraClip);
        texto.color = selecionado;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        texto.color = Color.white;
    }
}
