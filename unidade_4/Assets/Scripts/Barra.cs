using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    public Image ImgBarra;

    public int min;
    public int max;
    private int valorAtual;
    private float percentual;

    public void setValor(int valor){
        if(valor != valorAtual){
            if(max - min == 0){
                valorAtual = 0;
                percentual = 0;

            }else{
                valorAtual = valor;
                percentual= (float)valorAtual /(max - min);

            }
            ImgBarra.fillAmount = percentual;
        }
    }

    public float Percentual
    {
        get { return percentual; }
    }

    
    public int ValorAtual
    {
        get { return valorAtual; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
