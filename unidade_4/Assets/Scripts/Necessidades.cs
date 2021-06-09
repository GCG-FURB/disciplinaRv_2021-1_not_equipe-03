using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;


public class Necessidades : MonoBehaviour
{
    
        
        [SerializeField] private Axis distanceAxis;
        [SerializeField, Range(0, 1f)] public float directionThreshold;
        [SerializeField, Range(0, 50f)] public float positionLengthThresholdMin;
        [SerializeField, Range(0, 50f)] public float positionLengthThresholdMax;
        [SerializeField, Range(0, 10f)] public float positionYThresholdMin;
        [SerializeField, Range(0, 10f)] public float positionYThresholdMax;

    [SerializeField] private Animator controlador;
    private Barra barraSede;
    private Barra barraFome;
    private Barra barraDiversao;

    public float tempo;
    private bool instanciou;
    private int tipoInstanciado;
    private GameObject modeloInstanciado;
    private GameObject bolhaInstanciada;
    private int segundos = 0;
    private bool conta = false;

    public GameObject bolhaFome;
    public GameObject bolhaSede;
    public GameObject bolhaDiversao;

    public GameObject modeloFome;
    public GameObject modeloSede;
    public GameObject modeloDiversao;
    public GameObject target;
    
    
    public int sede = 100;
    public int fome = 100;
    public int diversao = 100;


    // Start is called before the first frame update
    void Start()
    {
        barraSede = GameObject.Find("Sede").GetComponent<Barra>();
        barraFome = GameObject.Find("Fome").GetComponent<Barra>();
        barraDiversao = GameObject.Find("Diversão").GetComponent<Barra>();


        barraSede.setValor(sede);
        barraFome.setValor(fome);
        barraDiversao.setValor(diversao);
        InvokeRepeating("diminuiNecessidades",0,tempo);
        InvokeRepeating("verificaPosicao",0,0.25f);
        InvokeRepeating("contaSegundos",0,1f);
    }

 
    public void verificaPosicao(){
        if(instanciou){
            if(!conta){

        Direction direcao = Direction.Forward;
        Axis eixoDirecao = Axis.Y;

        if(tipoInstanciado == 1){
            eixoDirecao = Axis.X;
            direcao = Direction.Forward;
            directionThreshold = 0.008f;
            positionLengthThresholdMin = 3f;
            positionLengthThresholdMax = 7f;
            positionYThresholdMin = -1f;
            positionYThresholdMax = 1f;
        }else if(tipoInstanciado == 2){
            eixoDirecao = Axis.Y;
            direcao = Direction.Up;
            directionThreshold = 0.008f;
            positionLengthThresholdMin = 0.4f;
            positionLengthThresholdMax = 0.6f;
            positionYThresholdMin = 5;
            positionYThresholdMax = 9;
        }else if(tipoInstanciado == 3){
            eixoDirecao = Axis.X;
            direcao = Direction.Forward;
            directionThreshold = 0.008f;
            positionLengthThresholdMin = 4f;
            positionLengthThresholdMax = 7f;
            positionYThresholdMin = -1f;
            positionYThresholdMax = 1f;
        }

        // Debug.Log(eixoDirecao);

        if(Verificador.posicaoCorreta(modeloInstanciado,direcao ,directionThreshold,positionLengthThresholdMin,positionLengthThresholdMax,positionYThresholdMin,positionYThresholdMax,eixoDirecao)){
            if(tipoInstanciado==1){
                instanciou = false;
                barraSede.setValor(100);
                sede = 100;
                conta = true;
            }else if(tipoInstanciado==2){
                barraFome.setValor(100);
                fome = 100;
                instanciou = false;
                conta = true;
            }else if(tipoInstanciado==3){
                barraDiversao.setValor(100);
                diversao = 100;
                instanciou = false;
                conta = true;
            }
            Object.Destroy(modeloInstanciado);
            // Object.Destroy(bolhaInstanciada);
        }
            }
        }
    }


    public void diminuiNecessidades(){
        int rd = Random.Range(1, 4);
        if(rd == 1){
            sede --;


        }else if(rd ==2){
                    fome --;
        
        }else if(rd ==3){
            diversao --;
        }
        
        if(sede <0)
            sede=0;

        if(fome <0)
            fome=0;

        if(diversao <0)
            diversao=0;

        barraSede.setValor(sede);
        barraFome.setValor(fome);
        barraDiversao.setValor(diversao);


        float x;
        float y;
        float z;
        Vector3 pos;

        x = Random.Range(-2, 2);
        y = 3;
        z = Random.Range(-2, 2);

        pos = new Vector3(target.transform.position.x + x,target.transform.position.y + y,target.transform.position.z + z);
        // Debug.Log(target.transform.position.x);
        
        if(!conta){
        if(sede <= 60){
            if(Random.value>0.5){
                y = 1;
                pos = new Vector3(target.transform.position.x + x,target.transform.position.y + y,target.transform.position.z + z);
                controlador.SetTrigger("sede");
                if(!instanciou){
                    modeloInstanciado = Instantiate(modeloSede, pos, Quaternion.identity);
                    modeloInstanciado.transform.parent = target.transform;
                    // modeloInstanciado.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);

                    
                    bolhaInstanciada = Instantiate(bolhaSede, target.transform);
                    bolhaInstanciada.transform.localPosition = new Vector3(0,1,0);
                    Object.Destroy(bolhaInstanciada,5);
                    instanciou = true;
                    tipoInstanciado = 1;
                }
                
            }
        }else if(fome <= 60){
            
            if(Random.value>0.5){
                controlador.SetTrigger("fome");
                if(!instanciou){
                    modeloInstanciado = Instantiate(modeloFome, pos, Quaternion.identity);
                    modeloInstanciado.transform.parent = target.transform;
                    
                    bolhaInstanciada = Instantiate(bolhaFome, target.transform);
                    bolhaInstanciada.transform.localPosition = new Vector3(0,1,0);
                    Object.Destroy(bolhaInstanciada,5);
                    instanciou = true;
                    tipoInstanciado = 2;
                }
                
                
            }
        }else if(diversao <= 60){
            
            if(Random.value>0.5){
                controlador.SetTrigger("diversao");
                if(!instanciou){
                    modeloInstanciado = Instantiate(modeloDiversao, pos, Quaternion.identity);
                    modeloInstanciado.transform.parent = target.transform;
                    
                    bolhaInstanciada = Instantiate(bolhaDiversao, target.transform);
                    bolhaInstanciada.transform.localPosition = new Vector3(0,1,0);
                    Object.Destroy(bolhaInstanciada,5);
                    instanciou = true;
                    tipoInstanciado = 3;
                }
                
            }
        }
        }
        
    }

    private void contaSegundos(){
        if(conta){
            
            segundos ++;
            if(segundos >= 5){
                conta = false;
            }
        
        }else{
            segundos = 0;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
