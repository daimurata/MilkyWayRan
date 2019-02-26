using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private float impulseMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        this.impulseMagnitude = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        var rigid = collision.gameObject.GetComponent<Rigidbody>();

        var impulse = rigid.position.normalized * this.impulseMagnitude;
        //var impulse = (rigid.position - transform.parent.position).normalized * this.impulseMagnitude;
        // 衝突相手の座標から回転中心の座標(頭部から見てハンマー本体は親なので、transform.parent.positionで親の位置をとる)を引き、正規化してimpulseMagnitudeをかける
        // ※衝突相手とハンマーはどちらもシーンの一番上層にあるので、それらの座標がそのままワールド座標になる

        rigid.AddForce(impulse, ForceMode.Impulse);
        // 瞬間的な衝撃をかける場合(力積を加える場合)はForceMode.Impulseを使う
        // ※ちなみにVelocityChangeを使うと衝突相手の速度を直接変えられる
        //  今回は衝突相手の質量に応じて吹き飛び量を変えたかったため、Impulseとした
    }
}
