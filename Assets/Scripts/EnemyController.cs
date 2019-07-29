using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;

    //移動時間のカウンター(減算していく)
    [SerializeField, Header("移動時間設定用")]
    public float moveCount = 5.0f;

    private float timer;

    [SerializeField, Header("移動軸設定用 trueだと縦")]
    public bool vertical;

    Rigidbody2D rigidbody2d;

    void Start()
    {
        //Rigidbodyを使えるようにしている
        rigidbody2d = GetComponent<Rigidbody2D>();

        //moveCountの初期値を代入
        timer = moveCount;
}

    void Update()
    {
        //初期ポジションを取得
        Vector2 position = rigidbody2d.position;

        if(vertical)
        {
            position.y = position.y + speed * Time.deltaTime;

        }
        else
        {
            position.x = position.x + speed * Time.deltaTime;
        }

        timer -= Time.deltaTime;

        //if 5秒間経ったら　逆方向に
        if(timer < 0)
        {
            timer = moveCount;
            //speed = speed * -1;
            speed = -speed;
        }

        rigidbody2d.MovePosition(position);
    }
}
