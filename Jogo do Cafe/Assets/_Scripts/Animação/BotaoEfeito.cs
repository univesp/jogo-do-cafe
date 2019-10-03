using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotaoEfeito : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image efeito;
    private bool estaDentro;

    private void Update()
    {
        if(estaDentro)
        {
            if(efeito.fillAmount < 1)
            {
                efeito.fillAmount += Time.deltaTime * 4.0f;
            }
        }
        else
        {
            if(efeito.fillAmount > 0)
            {
                efeito.fillAmount -= Time.deltaTime * 4.0f;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        estaDentro = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        estaDentro = false;
    }
}
