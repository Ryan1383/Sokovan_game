using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ItemBox 가 충돌을 인식 할 수 있도록 하는 코드
public class ItemBox : MonoBehaviour
{
    // Update is called once per frame
    public bool isOveraped = false;
    
    private Renderer myRenderer;
    
    public Color touchColor;
    private Color originalColor;
    
    
    void Start() {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }

    // box 가 어떠한 물체와 충돌할 때 Collider로 받아온다
    // Enter는 충돌을 한 그 순간
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "EndPoint"){
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
        
    }
    
    
    // Exit는 붙어있다가 떨어질때
    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "EndPoint")
        {
            isOveraped = false;
            myRenderer.material.color = originalColor;
        }
    }
    
    //stay는 붙어있는 동안임
    
    void OnTriggerStay(Collider other) 
    {
        if(other.tag == "EndPoint")
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
    }
    
    // // 트리거인 콜라이더와 충돌할 때 자동으로 실행된다.
    // void OnCollisionEnter(Collision other) 
    // {
    //     Debug.Log("충돌했음");
    // }
}
