using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UIM { 
    public class UIManagement : MonoBehaviour
    {
        /*
         * UI 다루는 법
         * 
         * UserInterface
         * 이미 구현되어있는 시스템을 보여주는 역할
         * 
         * Canvas
         * UGUI
         * Canvas에 올라가는 UI들은 월드에 올라가는 오브젝트와 다르게
         * 3D일 필요가 없음
         * 또한, 화면에 박혀있는 Canvas 안에서 좌표를 결정해야 하기 때문에
         * 월드에 있는 오브젝트와 다른 좌표계를 사용함
         * 이를 RectTransformm 이라고 함
         * 
         * EventSystem
         * UI를 다루다보면, 사용자와 인터렉션이 일어나야 하는것들이 생김
         * (버튼, 슬라이더, 인벤토리 등등)
         * 여기서 사용자의 입력을 감지하는 방식에는 2가지 정도가 있음
         * Update에서 매 프레임 사용자의 입력을 감시하는 방법,
         * 사용자가 입력했을때 한 순간을 감지하는 방법
         * 
         * 보통 후자를 많이 사용함
         * 이 방식을 Event라고 함
         * 
         * C# delegate, Action, Func
         */
        private TMP_Text text1 = null;
        private int score = 0;

        [SerializeField] private Image currentHpBar = null;
        [SerializeField] private float maxHp = 100f;
        [SerializeField] private float currentHp = 100f;

        [SerializeField] private Image scaleUpImage = null;
        [SerializeField] private float minScale = 1f;
        [SerializeField] private float maxScale = 1.5f;

        //1초동안 minScale에서 maxScale로 커지도록 할거임
        private float scaleUpDuration = 1f;
        //커졌다가 작아졌다가 하게 만들거라서, 그걸 구분하는 bool값이 하나 필요함
        private bool isScalingUp = true;

        private void Awake()
        {
            text1 = GetComponentInChildren<TMP_Text>();
        }

        //키보드 1을 누르면, text1의 값이 바뀌었으면 좋겠음
        private void Start()
        {
            text1.text = "현재 점수는 : "+score;
            currentHpBar.fillAmount = currentHp / maxHp;
            UpdateHpBar();
        }

        private void Update()
        {
            ChangeText();
            LessHp();
            ScaleImage();
        }

        private void UpdateHpBar()
        {
            //전체 체력 대비, 현재 체력
            //0.65 << 값을 fillAmount에 반영해주면 됨

            float hpRatio = currentHp / maxHp; // hp비율을 맞추는 변수
            currentHpBar.fillAmount = hpRatio; //비율을 currentHpBar에 적용하여서 hp가 줄어드는것 처럼 하기 위함
            currentHpBar.color = GetHpBarColor(hpRatio);
        }

        //키보드 숫자 1을 누르면 텍스트가 바뀌는 함수
        private void ChangeText()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //text1의 값이 바뀌면 될듯
                score += 10;

                text1.text = "현재 점수는 : " + score;
                text1.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
        }

        //숫자 2를 누르면 hp를 10씩 줄이는 함수
        private void LessHp()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentHp -= 10f;
                UpdateHpBar();
            }
        }

        private Color GetHpBarColor(float _value)
        {   
            Color result = default;
            if (_value > 0.6f)
            {
                result = Color.green;
            }
            else if (_value > 0.3f)
            {
                result = Color.yellow;
            }
            else
            {
                result = Color.red;
            }
            return result;
        }

        private void ScaleImage()
        {
            float currentScale = scaleUpImage.rectTransform.localScale.x;
            //얼마만큼 커져야 하는지에 대한 정보를 duration 만큼 나눠주면
            //한 프레임당 얼마나 커져야 하는지 나옴
            float scaleUpSpeed = (maxScale - minScale) / scaleUpDuration;

            if(isScalingUp == true) { 
            currentScale += scaleUpSpeed * Time.deltaTime;
                if(currentScale > maxScale)
                {
                    currentScale = maxScale;
                    isScalingUp = false; //다시 작아지기 하기 위함
                }
            }
            else
            {
                currentScale -= scaleUpSpeed * Time.deltaTime;
                if( currentScale < minScale )
                {
                    currentScale = minScale;
                    isScalingUp = true; //다시 커짐
                }
            }
            scaleUpImage.rectTransform.localScale = new Vector3(1, 1, 0) * currentScale;
        }
    }
}