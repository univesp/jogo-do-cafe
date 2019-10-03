using UnityEngine;
using UnityEngine.EventSystems;

public class JanelaInformativa : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Vector3 fabricaPos;
    [SerializeField] private Vector3 distribuidorPos;
    [SerializeField] private Vector3 atacadoPos;
    [SerializeField] private Vector3 varejoPos;

    [SerializeField] private GameObject fabricaSeta;
    [SerializeField] private GameObject distribuidorSeta;
    [SerializeField] private GameObject atacadoSeta;
    [SerializeField] private GameObject varejoSeta;

    private bool estaDentro;

    private GameObject informacao;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !estaDentro)
        {
            informacao.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void FabricaInfo(GameObject _informacao)
    {
        transform.localPosition = fabricaPos;
        fabricaSeta.SetActive(true);
        distribuidorSeta.SetActive(false);
        atacadoSeta.SetActive(false);
        varejoSeta.SetActive(false);

        informacao = _informacao;
        informacao.SetActive(true);
    }

    public void DistribuidorInfo(GameObject _informacao)
    {
        transform.localPosition = distribuidorPos;
        fabricaSeta.SetActive(false);
        distribuidorSeta.SetActive(true);
        atacadoSeta.SetActive(false);
        varejoSeta.SetActive(false);

        informacao = _informacao;
        informacao.SetActive(true);
    }

    public void AtacadoInfo(GameObject _informacao)
    {
        transform.localPosition = atacadoPos;
        fabricaSeta.SetActive(false);
        distribuidorSeta.SetActive(false);
        atacadoSeta.SetActive(true);
        varejoSeta.SetActive(false);

        informacao = _informacao;
        informacao.SetActive(true);
    }

    public void VarejoInfo(GameObject _informacao)
    {
        transform.localPosition = varejoPos;
        fabricaSeta.SetActive(false);
        distribuidorSeta.SetActive(false);
        atacadoSeta.SetActive(false);
        varejoSeta.SetActive(true);

        informacao = _informacao;
        informacao.SetActive(true);
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
