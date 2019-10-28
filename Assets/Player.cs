using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    
    public float speed = 3f;
    
    private Rigidbody playerRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();                         
    }
    
    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver == true)
        {
            return;
        }
     
        // A <-    ->D
        // -1.0  0   +1.0
        // 조이스틱을 왼쪽으로 살짝 밀면 - 1.2 -1.1 등이 나옴
        // 숫자로 받는 이유는 조이스틱을 살살 미는 정도를 알기 위해
        float inputX = Input.GetAxis("Horizontal"); // Horizontal 을 사용하여 여러가지 기기에 대응이 가능하다
        
        // S v      ^ W
        // -1.0  0    +1.0
        float inputZ = Input.GetAxis("Vertical");
        
        float fallSpeed = playerRigidbody.velocity.y;
        
        // playerRigidbody.AddForce(inputX* speed,0,inputZ* speed); // RigidBody.AddForce 는 속도를 주는것이 아닌 힘을 주는것이기 때문에 관성이 있다.
        
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        
        // (inputX, 0, inputZ)
        velocity = velocity * speed;
        velocity.y = fallSpeed;
        
        playerRigidbody.velocity = velocity;
                
    }
}
