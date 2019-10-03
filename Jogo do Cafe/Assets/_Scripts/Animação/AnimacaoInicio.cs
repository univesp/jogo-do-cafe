using UnityEngine;

public class AnimacaoInicio : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.Play("TransicaoInicioSai");
    }
}
