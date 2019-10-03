using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransicaoDeTela : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private string animacaoNomeEntrada;
    [SerializeField] private string animacaoNomeSaida;

    [SerializeField] private UnityEvent acao;

    public void ChamaTransicao(float _delay)
    {
        animator.gameObject.SetActive(true);
        StartCoroutine(Animacao(_delay));
    }

    private IEnumerator Animacao(float _delay)
    {
        animator.Play(animacaoNomeEntrada);
        
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        acao.Invoke();
        yield return new WaitForSeconds(_delay);

        animator.Play(animacaoNomeSaida);
    }
}
