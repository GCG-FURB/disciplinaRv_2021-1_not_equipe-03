using System.Transactions;
using Enum;
using UnityEngine;
using UnityEngine.UI;




    public class Verificador : MonoBehaviour
    {
        
        [SerializeField] static private Camera _cam = GameObject.Find("ARCamera").GetComponent<Camera>();

        public static bool posicaoCorreta(GameObject objeto, Direction direcao, float directionThreshold,
        float positionLengthThresholdMin,float positionLengthThresholdMax, float positionYThresholdMin,float positionYThresholdMax, Axis distanceAxis)
        {

            var camDirection = DirecaoCamera.IsCameraDirectionCorrect(_cam, objeto, direcao,
                directionThreshold);
            
            var camPosition = DirecaoCamera.IsCameraPositionCorrect(_cam, objeto, positionLengthThresholdMin,positionLengthThresholdMax,
                positionYThresholdMin,positionYThresholdMax, distanceAxis);
            Debug.Log(camDirection + ","+ camPosition[1] + ","+camPosition[2]);
           
            return camDirection && camPosition[0];
        }

        

        
    }
