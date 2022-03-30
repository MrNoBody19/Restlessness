using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barradevida : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    public void CambiarMaxHP(float MaxHP){
        slider.maxValue = MaxHP;
    }
    
    public void CambiarCrtHP(float HPamount){
        slider.value = HPamount;
    }

    public void InicializarBarraDeVida(float HPamount)
    {
        CambiarMaxHP(HPamount);
        CambiarCrtHP(HPamount);
    }
}
