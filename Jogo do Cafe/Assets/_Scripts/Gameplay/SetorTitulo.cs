using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SetorTitulo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip mouseEntraClip;
    [SerializeField] private AudioClip clickClip;

    [SerializeField] private TextMeshProUGUI tituloText;

    [SerializeField] private Color corSelecionada;

    [SerializeField] private bool estaOculto = true;
    [SerializeField] private Animator animator;
    [SerializeField] private string nomeAnimacaoEntra;
    [SerializeField] private string nomeAnimacaoSai;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(mouseEntraClip);
        tituloText.color = corSelecionada;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tituloText.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(clickClip);
        if(estaOculto)
        {
            animator.Play(nomeAnimacaoEntra);
            estaOculto = false;
        }
        else
        {
            animator.Play(nomeAnimacaoSai);
            estaOculto = true;
        }
    }
}