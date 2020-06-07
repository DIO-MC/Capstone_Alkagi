using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class StoneBehavior : MonoBehaviour
//{
//    Rigidbody rigid;
//    // /* 초기화!! */
//    // void Awake(){//게임 오브젝트 생성할 때 최초 실행
//    //     Debug.Log("플레이어 데이터가 준비되었습니다.");
//    // }

//    // void OnEnable(){ //게임 오브젝트 활성화!!
//    //     Debug.Log("플레이어가 로그인 했습니다.");
//    // }
//    // // Start is called before the first frame update
//    void Start()
//    {
//        rigid = GetComponent<Rigidbody>(); //초기화
//        //rigid.velocity = new Vector3(2,4,3);
//    }
//    void FixedUpdate()
//    {//물리연산 하기 전에 실행, CPU 부하 많음
//        if (Input.GetButton("Jump"))
//        {
//            //rigid.AddForce(Vector3.up * 4, ForceMode.Acceleration);
//            //rigid.velocity = new Vector3(2, 4, 3);//change velocity
//            Debug.Log(rigid.velocity);
//        }
//    }


//    // Update is called once per frame
//    void Update()
//    {//게임로직 업데이트, 환경에 따라 실행주기떨어질수잇음. 1초에 60회씩 동작함!


//        // Vector3 vec = new Vector3(0, 0.01f, 0);//x 크기, y 크기, z 크기: 벡터 값
//        Vector3 vec = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime, 0);
//        transform.Translate(vec);//Translate: 안에 있는 벡터 값 만큼 현재 위치에 더해준다. Vector3: 3차원의 벡터


//        if (Input.anyKeyDown)
//        {
//            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
//        }
//        // if(Input.GetKeyDown(KeyCode.Return)){
//        //     Debug.Log("아이템을 구입하셨습니다.");
//        //}
//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
//            Debug.Log("왼쪽으로 이동 중.");
//        }
//        if (Input.GetKey(KeyCode.RightArrow))
//        {
//            Debug.Log("오른쪽으로 이동 중.");
//        }
//        if (Input.GetKeyUp(KeyCode.RightArrow))
//        {
//            Debug.Log("오른쪽 이동을 멈췄습니다.");
//        }
//        if (Input.GetKeyUp(KeyCode.LeftArrow))
//        {
//            Debug.Log("왼쪽 이동을 멈췄습니다.");
//        }

//        if (Input.GetMouseButtonDown(0))
//        {
//            Debug.Log("미사일 발사!");
//        }
//        if (Input.GetMouseButton(0))
//        {
//            Debug.Log("미사일 모으는 중...");
//        }
//        if (Input.GetMouseButtonUp(0))
//        {
//            Debug.Log("슈퍼 미사일 발사!");
//        }

//        if (Input.GetButtonDown("Jump"))
//        {
//            Debug.Log("점프!");
//        }
//        if (Input.GetButton("Jump"))
//        {
//            Debug.Log("점프 기 모으는 중....");
//        }
//        if (Input.GetButtonUp("Jump"))
//        {
//            Debug.Log("슈퍼점프!");
//        }
//        if (Input.GetButton("Vertical"))
//        {
//            Debug.Log("종 이동 중..." + Input.GetAxisRaw("Vertical"));
//        }
//        if (Input.GetButton("Horizontal"))
//        {
//            Debug.Log("횡 이동 중..." + Input.GetAxisRaw("Horizontal"));
//            //GetAxis: 수평, 수직 버튼 입력을 받으면 float return!! 마리오 게임에서 방향키 살짝 누르면 캐릭터 살짝 움직이는 원리임 ㅇㅇ
//            //GetAxisRaw: 가중치 없고 -1, 1, 0(두 버튼 한번에 누를 때), 1 단위로 바뀜
//        }
//        // if(Input.anyKey){
//        //     Debug.Log("플레이어가 아무 키를 누르고 있습니다.");
//        // }
//    }

//    // void LateUpdate(){//업뎃 끝난 후, 로직 후 처리 또는 카메라
//    //     Debug.Log("경험치 획득!");
//    // }

//    // void OnDisable(){ //게임 오브젝트 비활성화!
//    //     Debug.Log("플레이어가 로그아웃 했습니다.");
//    // }
//    // void OnDestroy(){//게임 오브젝트 삭제될 때, awake랑 반대
//    //     Debug.Log("플레이어 데이터 해체");
//    // }
//}
public class StoneController : MonoBehaviour
{
    public float speed; //regulate speed inside of UNITY
    Rigidbody rb;   //rigidbody of stone
    GameObject stone;   //object stone

    Vector3 movement;
    //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


    //initialize!
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //update called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Run(moveHorizontal, moveVertical);



    }

    void Run(float moveHorizontal, float moveVertical)
    {
        movement.Set(moveHorizontal, 0, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }

    void Update()
    {
        


    }

}
