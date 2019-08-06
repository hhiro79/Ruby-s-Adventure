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

    public Rigidbody2D rigidbody2d;

    public Animator animator;

    private bool broken = true;

    public ParticleSystem smokeEffect;

    void Start()
    {
        //Rigidbodyを使えるようにしている
        //rigidbody2d = GetComponent<Rigidbody2D>();

        //moveCountの初期値を代入
        timer = moveCount;

        //smokeEffect.Play();

        //animator = GetComponent<Animator>();
}

    void Update()
    {
        //ロボットに歯車が当たったらフラグが切り替わり
        //動きを止める
        if (!broken)
        {
            return;
        }

        //初期ポジションを取得
        Vector2 position = rigidbody2d.position;

        if(vertical)
        {
            position.y = position.y + speed * Time.deltaTime;

            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", speed);
        }
        else
        {
            position.x = position.x + speed * Time.deltaTime;

            animator.SetFloat("Move X", speed);
            animator.SetFloat("Move Y", 0);
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

    void OnCollisionEnter2D(Collision2D col)
    {
        RubyController player = col.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    /// <summary>
    /// ロボットに歯車が当たったらフラグ切替
    /// 動きを止める
    /// </summary>
    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;

        animator.SetTrigger("Fixed");

        //smokeEffect.Stop();
        Destroy(smokeEffect.gameObject);
    }
}
