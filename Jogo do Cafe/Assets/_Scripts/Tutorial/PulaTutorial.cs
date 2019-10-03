using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PulaTutorial : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip entraClip;
    [SerializeField] private AudioClip clickClip;

    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Color selecionado;
    [SerializeField] private TransicaoDeTela transicao;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(clickClip);
        transicao.ChamaTransicao(0.0f);
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
