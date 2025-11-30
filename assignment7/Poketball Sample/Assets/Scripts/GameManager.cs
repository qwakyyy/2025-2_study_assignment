using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager MyUIManager;

    public GameObject BallPrefab;   // prefab of Ball

    // Constants for SetupBalls
    public static Vector3 StartPosition = new Vector3(0, 0, -6.35f);
    public static Quaternion StartRotation = Quaternion.Euler(0, 90, 90);
    const float BallRadius = 0.286f;
    const float RowSpacing = 0.02f;

    GameObject PlayerBall;
    GameObject CamObj;

    const float CamSpeed = 3f;

    const float MinPower = 15f;
    const float PowerCoef = 1f;

    void Awake()
    {
        // PlayerBall, CamObj, MyUIManager를 얻어온다.
        // ---------- TODO ---------- 
        PlayerBall = GameObject.Find("PlayerBall");   // 씬에 있는 PlayerBall 오브젝트
        CamObj = GameObject.Find("Main Camera");      // 카메라 오브젝트
        MyUIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        // -------------------- 
    }

    void Start()
    {
        SetupBalls();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 raycast하여 클릭 위치로 ShootBallTo 한다.
        // ---------- TODO ---------- 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ShootBallTo(hit.point);
            }
        }
        // -------------------- 
    }

    void LateUpdate()
    {
        CamMove();
    }

    void SetupBalls()
    {
        // 15개의 공을 삼각형 형태로 배치한다.
        // 가장 앞쪽 공의 위치는 StartPosition이며, 공의 Rotation은 StartRotation이다.
        // 각 공은 RowSpacing만큼의 간격을 가진다.
        // 각 공의 이름은 {index}이며, 아래 함수로 index에 맞는 Material을 적용시킨다.
        // Obj.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_1");
        // ---------- TODO ---------- 
        int index = 1;

        float horizontalGap = BallRadius * 2 + RowSpacing;  // 같은 줄 공 사이 간격
        float verticalGap   = BallRadius * 2 + RowSpacing;  // 줄 간격

        for (int row = 0; row < 5; row++)
        {
            // row가 커질수록 z축(아래쪽)으로 내려간다
            float zPos = StartPosition.z - row * verticalGap;

            // 이 줄을 x축 기준 가운데 정렬
            float xStart = StartPosition.x - (row * horizontalGap) / 2f;

            for (int col = 0; col <= row; col++)
            {
                float xPos = xStart + col * horizontalGap;

                Vector3 pos = new Vector3(xPos, StartPosition.y, zPos);

                GameObject ball = Instantiate(BallPrefab, pos, StartRotation);
                ball.name = index.ToString();

                ball.GetComponent<MeshRenderer>().material =
                    Resources.Load<Material>($"Materials/ball_{index}");

                index++;
            }
        }

        // -------------------- 
    }
    void CamMove()
    {
        // CamObj는 PlayerBall을 CamSpeed의 속도로 따라간다.
        // ---------- TODO ---------- 
        if (PlayerBall != null && CamObj != null)
        {
            Vector3 targetPos = new Vector3(
                PlayerBall.transform.position.x,
                15f, // 카메라 높이 고정
                PlayerBall.transform.position.z
            );

            CamObj.transform.position = Vector3.Lerp(
                CamObj.transform.position,
                targetPos,
                Time.deltaTime * CamSpeed
            );
        }
    }

    float CalcPower(Vector3 displacement)
    {
        return MinPower + displacement.magnitude * PowerCoef;
    }

    void ShootBallTo(Vector3 targetPos)
    {
        // targetPos의 위치로 공을 발사한다.
        // 힘은 CalcPower 함수로 계산하고, y축 방향 힘은 0으로 한다.
        // ForceMode.Impulse를 사용한다.
        // ---------- TODO ---------- 
        if (PlayerBall == null) return;

        Rigidbody rb = PlayerBall.GetComponent<Rigidbody>();
        Vector3 displacement = targetPos - PlayerBall.transform.position;
        displacement.y = 0; // y축 힘 제거

        float power = CalcPower(displacement);
        rb.AddForce(displacement.normalized * power, ForceMode.Impulse);
        // -------------------- 
    }
    
    // When ball falls
    public void Fall(string ballName)
    {
        // "{ballName} falls"을 1초간 띄운다.
        // ---------- TODO ---------- 
        MyUIManager.DisplayText($"{ballName} falls", 1f);
        // -------------------- 
    }
}
