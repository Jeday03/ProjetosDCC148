using UnityEngine;

public class GameController : MonoBehaviour
{

    // variáveis usadas
    public GameObject deathCube;
    public GameObject niceCube;

    public float tempoDecorrido = 0;
    private GameObject activeCube;
    public float tempoMaximo = 2.00f;
    public int points = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeCube = Instantiate(niceCube);
    }

    // Update is called once per frame
    void Update()
    {
        tempoDecorrido += Time.deltaTime;

        if(tempoDecorrido > tempoMaximo)
        {
            if(activeCube.tag != "Death" && points > 0)
                points -= 1;
            tempoDecorrido = 0;
            NewCube();
        }

        if(points < 10)
            tempoMaximo = 2.00f;

        if(Input.GetKeyDown(KeyCode.Space)) 
        {  

            tempoDecorrido = 0;
            if(activeCube.tag == "Death")
            {
                Debug.Log("Points: " + points);
                UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                points++;
                

                if(points % 10 == 0)
                    tempoMaximo /= 2;

            }
            
            NewCube();
        }
        

    }

    void NewCube()
    {
        Destroy(activeCube);

        float randVal = Random.Range(0.0f, 1.0f);
        if(randVal > 0.8)
            activeCube = Instantiate(deathCube);
        else
            activeCube = Instantiate(niceCube);

        float randX = Random.Range(-6.0f, 6.0f);
        float randY = Random.Range(-3.0f, 3.0f);
        Vector3 pos = new Vector3(randX, randY, 0);
        activeCube.transform.position = pos;
    }

}
