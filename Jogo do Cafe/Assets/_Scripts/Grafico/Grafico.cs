using System.Collections.Generic;
using UnityEngine;

public class Grafico : MonoBehaviour
{
    [SerializeField] private int[] gastos;
    [SerializeField] private int maiorGasto = 0;

    [SerializeField] private RectTransform areaGrafico;
    [SerializeField] private float tamanhoX;
    [SerializeField] private float tamanhoY;
    [SerializeField] private float distSeparadorX;    

    [SerializeField] private GameObject bolinhaPai;
    [SerializeField] private GameObject linhaPai;

    [SerializeField] private GameObject paiTemporario;

    [SerializeField] private Transform valorAnterior;
    [SerializeField] private Transform valorAtual;


    private void Awake()
    {
        Debug.Log(areaGrafico.sizeDelta.x);
        tamanhoX = areaGrafico.rect.width;
        tamanhoY = areaGrafico.rect.height;

        distSeparadorX = tamanhoX / gastos.Length;

        for(int i = 0; i < gastos.Length; i++)
        {
            if(maiorGasto < gastos[i])
            {
                maiorGasto = gastos[i];
            }
        }

        for(int i = 0; i < gastos.Length; i++)
        {
            if(valorAtual != null)
            {
                valorAnterior = valorAtual;
            }
            valorAtual = CriaBolinhas(new Vector2(i * distSeparadorX, tamanhoY * gastos[i] / maiorGasto));
            
            if(valorAnterior != null)
            {
                CriaLinha(Vector2.Distance(valorAtual.localPosition, valorAnterior.localPosition), Vector2.Lerp(valorAtual.localPosition, valorAnterior.localPosition, 0.5f), AngleBetweenVector2(valorAtual.localPosition, valorAnterior.localPosition));
            }
        }
    }

    private Transform CriaBolinhas(Vector2 _pos)
    {
        GameObject bolinha = bolinhaPai.transform.GetChild(0).gameObject;
        bolinha.gameObject.transform.parent = paiTemporario.transform;
        bolinha.gameObject.SetActive(true);
        bolinha.transform.localPosition = _pos;
        return bolinha.gameObject.transform;
    }

    private void CriaLinha(float _comprimento, Vector2 _pos, float _anguloRot)
    {
        Debug.Log(_comprimento + "**" + _pos);
        RectTransform linha = linhaPai.transform.GetChild(0).GetComponent<RectTransform>();
        linha.gameObject.transform.parent = paiTemporario.transform;
        linha.gameObject.SetActive(true);
        linha.sizeDelta = new Vector2(_comprimento, linha.sizeDelta.y);
        linha.anchoredPosition = _pos;
        linha.localEulerAngles = new Vector3(linha.localEulerAngles.x, linha.localEulerAngles.y, _anguloRot);
    }

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

}