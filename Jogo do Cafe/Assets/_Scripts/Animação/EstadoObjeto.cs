using UnityEngine;

public class EstadoObjeto : MonoBehaviour
{
    [SerializeField] private GameObject objeto;

    public void Ativa()
    {
        objeto.SetActive(true);
    }

    public void Desativa()
    {
        objeto.SetActive(false);
    }
}
