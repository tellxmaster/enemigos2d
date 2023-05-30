using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public float velocidad = 2;
    public GameObject columna;
    public GameObject roca1;
    public GameObject roca2;
    public Renderer fondo;

    public List<GameObject> columnaLista;
    public List<GameObject> obstaculos;

    public bool start = false;
    public bool gameOver = false;

    public int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        //Crear Mapa
        for (int i = 0; i < 21; i++) {
            columnaLista.Add(Instantiate(columna, new Vector2(-10 + i,-3), Quaternion.identity));
        }

        //Obstaculos
        obstaculos.Add(Instantiate(roca1, new Vector2(15, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(roca2, new Vector2(20, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if(start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if(start == true  && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        if(start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * velocidad * Time.deltaTime;

            if (vidas <= 0)
            {
                gameOver = true;
            }

            //Mover Mapa
            for (int i = 0; i < columnaLista.Count; i++)
            {
                if (columnaLista[i].transform.position.x <= -10)
                {
                    columnaLista[i].transform.position = new Vector3(10f, -3, 0);
                }
                columnaLista[i].transform.position = columnaLista[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
            }


            //Mover Obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randowmObs = Random.Range(11, 10);
                    obstaculos[i].transform.position = new Vector3(randowmObs, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
            }
        }
    }

}
