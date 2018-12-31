using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class loadDataLoading : MonoBehaviour
{
    public GameObject myText;
    public GameObject desc;
    public GameObject descDetail;
    public string LevelName = "Level";

    public Image BackGround_1 = null;
    public Image BackGround_2 = null;
    public Sprite[] Images;
    [SerializeField] private AnimationClip LoopAnim;
    [Space(5)]
    [HideInInspector]
    public bool Firts = true;
    [Range(0.01f, 10f)]
    public float m_Delay = 2.0f;
    [Space(7)]
    public Image PlayerGallery;
    public Sprite PlaySprite;
    public Sprite PauseSprite;
    //Privates
    private int NextImage = 0;

    void Awake()
    {
        StartCoroutine(FirtsFade());
    }

    void Start()
    {
        LevelName = PlayerPrefs.GetString("LevelName");
        TextAsset loadDesc = (TextAsset)Resources.Load("TextFile/" + LevelName);
        TextAsset loadDescDetail = (TextAsset)Resources.Load("TextFile/" + LevelName + "2");
        Images[0] = Resources.Load<Sprite>("Background/" + LevelName + "2");
        Images[1] = Resources.Load<Sprite>("Background/" + LevelName + "1");
        desc.GetComponent<Text>().text = loadDesc.text;
        descDetail.GetComponent<Text>().text = loadDescDetail.text;
        //Material skybox = (Material)AssetDatabase.LoadAssetAtPath("Assets/Menu UI/UMenu Gallery/Content/Art/UI/Material/undersea.mat", typeof(Material));

        Material skybox = Resources.Load("Background/undersea") as Material;
        RenderSettings.skybox = skybox;
    }

    // Update is called once per frame
    void Update()
    {
        myText.GetComponent<Text>().text = LevelName.ToString();
    }

    void Change()
    {
        NextImage = (NextImage + 1) % Images.Length;
        if (Firts)
        {
            BackGround_2.sprite = Images[NextImage];
            StartCoroutine(FirtsFade());
        }
        else
        {
            BackGround_1.sprite = Images[NextImage];
            StartCoroutine(SecondFade());
        }
    }
    
    IEnumerator FirtsFade()
    {
        Color FadeIn = BackGround_1.color;
        Color FadeOut = BackGround_2.color;
        float t = 0.0f;
        while (FadeIn.a > 0.0f)
        {
            t += Time.deltaTime / 25;
            FadeIn.a = Mathf.Lerp(FadeIn.a, 0.0f, t);
            FadeOut.a = Mathf.Lerp(FadeOut.a, 1.0f, t);
            BackGround_1.color = FadeIn;
            BackGround_2.color = FadeOut;
            yield return null;
        }
        Firts = !Firts;
        StartCoroutine(Delay());
    }
    
    IEnumerator SecondFade()
    {
        Color FadeIn = BackGround_2.color;
        Color FadeOut = BackGround_1.color;
        float t = 0.0f;
        while (FadeIn.a > 0.0f)
        {
            t += Time.deltaTime / 25;
            FadeIn.a = Mathf.Lerp(FadeIn.a, 0.0f, t);
            FadeOut.a = Mathf.Lerp(FadeOut.a, 1.0f, t);
            BackGround_2.color = FadeIn;
            BackGround_1.color = FadeOut;
            yield return null;
        }
        Firts = !Firts;
        StartCoroutine(Delay());
    }

    private bool m_state = true;
    public void GalleryState()
    {
        m_state = !m_state;
        Animation aa = BackGround_1.GetComponent<Animation>();
        Animation ab = BackGround_2.GetComponent<Animation>();

        aa[LoopAnim.name].speed = (m_state) ? 1.0f : 0.0f;
        ab[LoopAnim.name].speed = (m_state) ? 1.0f : 0.0f;
        PlayerGallery.sprite = (m_state) ? PlaySprite : PauseSprite;
    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(m_Delay);
        Change();
    }

}