using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background2D : MonoBehaviour 
{

    private GameObject CloudObject;
    private GameObject BGCLayerObject;
    private GameObject BGFLayerObject;
    private GameObject BGF0;
    private GameObject BGC0;
    private GameObject BGF1;
    private GameObject BGC1;
    private float BGCDistance = 0.5f;
    private float BGFDistance = 1.0f;
    private List<GameObject> Clouds;
    private float cloudSpeed = -0.008f;
    private float cloudDepth = 5.0f;
    private float BGLayerCSpeed = 0.2f;
    private float BGLayerFSpeed = 0.05f;
    //Repeat the backgrounds with counters to duplicate distance
    private float BGLayerCCounter = 0f;
    private float BGLayerFCounter = 0f;

    private int iCloudCompare = 0;
    private bool bPause = false;
    private float newPositionX;
    private EnumTypes.CloudState CloudDensity;
    private EnumTypes.BackgroundSelection BackgroundSelection;
    private EnumTypes.DayState DaySelection;
    private static Skybox SBox;

    private List<ParticleSystem> FX;

    private Main main;

	//Use this for initialization
	void Awake () 
    {
        main = GameObject.FindObjectOfType<Main>();
        SBox = main.GetComponent<Skybox>();
        CloudObject = GameObject.Find("CloudBackground");
        BGCLayerObject = GameObject.Find("BGLayerClose");
        BGFLayerObject = GameObject.Find("BGLayerFar");
	}

    public void SetDaySelection(EnumTypes.DayState myDay)
    {
        DaySelection = myDay;
        switch (DaySelection)
        {
            case EnumTypes.DayState.Morning:
                SBox.material = Resources.Load("Background/SkyBoxBG_Morning", typeof(Material)) as Material;
                break;
            case EnumTypes.DayState.Afternoon:
                SBox.material = Resources.Load("Background/SkyBoxBG_Afternoon", typeof(Material)) as Material;
                break;
            case EnumTypes.DayState.Evening:
                SBox.material = Resources.Load("Background/SkyBoxBG_Evening", typeof(Material)) as Material;
                break;
            case EnumTypes.DayState.Night:
                SBox.material = Resources.Load("Background/SkyBoxBG_Night", typeof(Material)) as Material;
                break;
            default:
                break;
        }
    }

    public void Pause()
    {
        bPause = true;
    }
    public void unPause()
    {
        bPause = false;
    }

    void CreateBackground()
    {
        BGC0 = Instantiate(Resources.Load("Background/Hills00",typeof(GameObject)), Vector3.zero , new Quaternion()) as GameObject;
        BGC0.transform.parent = BGCLayerObject.transform;
        BGC0.transform.localPosition = new Vector3(0f, -4f, 1f);
        BGC0.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.35f, 0.35f, 0.35f,1.0f);
        BGC1 = Instantiate(Resources.Load("Background/Hills00", typeof(GameObject)), Vector3.zero, new Quaternion()) as GameObject;
        BGC1.transform.parent = BGCLayerObject.transform;
        BGC1.transform.localPosition = new Vector3(50f, -4f, 1f);
        BGC1.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.35f, 0.35f, 0.35f, 1.0f);

        BGF0 = Instantiate(Resources.Load("Background/Hills00",typeof(GameObject)), Vector3.zero , new Quaternion()) as GameObject;
        BGF0.transform.parent = BGFLayerObject.transform;
        BGF0.transform.localPosition = new Vector3(0f, -1f, 1f);
        BGF0.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.25f);
        BGF1 = Instantiate(Resources.Load("Background/Hills00", typeof(GameObject)), Vector3.zero, new Quaternion()) as GameObject;
        BGF1.transform.parent = BGFLayerObject.transform;
        BGF1.transform.localPosition = new Vector3(50f, -1f, 1f);
        BGF1.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.25f);
    }

    public void setupClouds(EnumTypes.CloudState myDense)
    {
        CloudDensity = myDense;
        //CreateCloudScape();
    }

    public void setupBackground(EnumTypes.BackgroundSelection mySelection)
    {
        BackgroundSelection = mySelection;
        CreateBackground();
    }

    //DO NOT CALL ME YET
    void CreateCloudScape()
    {
        //Check for menu or level height
        Clouds = new List<GameObject>();

        
        //Create the starting clouds in the scene
        //Need a random?
        
        switch (CloudDensity)
        {
            //None
            case EnumTypes.CloudState.Clear:
                //Do nothing
                iCloudCompare = 0;
                break;
            //Lightly
            case EnumTypes.CloudState.PartlyCloudy:
                //X Range -18f to 4f
                iCloudCompare = Random.Range(2, 4);
                for (int i = 0; i < iCloudCompare; i++)
                {
                    
                    Clouds.Add(Instantiate(Resources.Load("Clouds/Cloud " + Random.Range(0,2).ToString(), typeof(GameObject)), new Vector3(0,0,0), new Quaternion()) as GameObject);
                    Clouds[i].transform.parent = CloudObject.transform;
                    Clouds[i].transform.localPosition = new Vector3(Random.Range(-50f, 30f), Random.Range(-1.0f, 1.0f), cloudDepth);
                }
                InvokeRepeating("CloudUpdate", 0.09f, 0.09f);
                break;
            //Partly
            case EnumTypes.CloudState.MostlyCloudy:
                iCloudCompare = Random.Range(5, 8);
                for(int i = 0; i < iCloudCompare; i++)
                {
                    Clouds.Add(Instantiate(Resources.Load("Clouds/Cloud " + Random.Range(0,2).ToString(), typeof(GameObject)), new Vector3(0,0,0), new Quaternion()) as GameObject);
                    Clouds[i].transform.parent = CloudObject.transform;
                    Clouds[i].transform.localPosition = new Vector3(Random.Range(-50f, 30f), Random.Range(-1.0f, 1.0f), cloudDepth);
                }
                InvokeRepeating("CloudUpdate", 0.09f, 0.09f);
                break;
            //Cloudy
            case EnumTypes.CloudState.Cloudy:
                iCloudCompare = Random.Range(9, 12);
                for(int i = 0; i < iCloudCompare; i++)
                {
                    Clouds.Add(Instantiate(Resources.Load("Clouds/Cloud " + Random.Range(0,2).ToString(), typeof(GameObject)), new Vector3(0,0,0), new Quaternion()) as GameObject);
                    Clouds[i].transform.parent = CloudObject.transform;
                    Clouds[i].transform.localPosition = new Vector3(Random.Range(-50f, 30f), Random.Range(-1.0f, 1.0f), cloudDepth);
                }
                InvokeRepeating("CloudUpdate", 0.09f, 0.09f);
                break;
            case EnumTypes.CloudState.Random:
                iCloudCompare = Random.Range(0, 12);
                for(int i = 0; i < iCloudCompare; i++)
                {
                    Clouds.Add(Instantiate(Resources.Load("Clouds/Cloud " + Random.Range(0,2).ToString(), typeof(GameObject)), new Vector3(0,0,0), new Quaternion()) as GameObject);
                    Clouds[i].transform.parent = CloudObject.transform;
                    Clouds[i].transform.localPosition = new Vector3(Random.Range(-50f, 30f), Random.Range(-1.0f, 1.0f), cloudDepth);
                }
                InvokeRepeating("CloudUpdate", 0.09f, 0.09f);
                break;
   
            //None
            default:
                iCloudCompare = 0;
                //Do Nothing
                break;
        }


    }
    public void BackgroundUpdate(float positionX)
    {
        if (BackgroundSelection != EnumTypes.BackgroundSelection.Clear)
        {
            //Shift background over to repeat
            //if ((int)positionX % 100 == 0)
            {
              //  BGC0.gameObject.transform.localPosition = new Vector3( 
            }

                BGCLayerObject.transform.localPosition = new Vector3((positionX - (BGLayerCCounter * 250)) * -BGLayerCSpeed, main.transform.position.y * 0.02f, BGCDistance);
                BGFLayerObject.transform.localPosition = new Vector3((positionX - (BGLayerFCounter * 1000)) * -BGLayerFSpeed, main.transform.position.y * 0.01f, BGFDistance);

                if (BGCLayerObject.transform.localPosition.x <= -50f)
                {
                      BGLayerCCounter++;
                }
                if (BGFLayerObject.transform.localPosition.x <= -50f)
                {
                      BGLayerFCounter++;
                }


    //private float BGLayerFCounter = 1f;
                
            
            //else
            {
            //    BGCLayerObject.transform.localPosition = new Vector3(positionX * -BGLayerCSpeed, main.transform.position.y * 0.02f, BGCDistance);
              //  BGFLayerObject.transform.localPosition = new Vector3(positionX * -BGLayerFSpeed, main.transform.position.y * 0.01f, BGFDistance);
            }

        }
    }

    void CloudUpdate()
    {
        if(!bPause)
            for (int i = 0; i < iCloudCompare; i++)
            {
                if(Clouds[i].transform.localPosition.x < -70.0f)
                    Clouds[i].transform.localPosition = new Vector3(Random.Range(25.0f, 75.0f),Random.Range(-1.0f, 1.0f), 0);
                Clouds[i].transform.Translate(cloudSpeed, 0, 0);
            }
    }

    // Update is called once per fixed frame
    void FixedUpdate() 
    {
      //  for(int i = 0; i < iCloudCompare; i++)
      //      Clouds[i].transform.Translate(-0.1f, 0, 0);
	}
}
