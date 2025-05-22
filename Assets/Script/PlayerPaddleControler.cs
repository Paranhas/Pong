using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public float speed = 5f;
    public string movementAxisName = "Vertical";

    public bool isPLayer = true;
    public SpriteRenderer spriteRenderer;


    // Update is called once per frame
    void Update()
    {
        //Captura da entrada vertical(seta para cima, seta para baixo, tecla W e S
        float moveInput = Input.GetAxis(movementAxisName);

        //Calcula a nova posicção da raquete baseada na entrada e velociadade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        //Limita a posição vertical da raquete para que ela não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        //Atualiza a posição da raquete
        transform.position = newPosition;
    }

    private void Start()
    {
        if (isPLayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer01;
        }
        else { 
            spriteRenderer.color = SaveController.Instance.colorPlayer02;
        }
    }
}
