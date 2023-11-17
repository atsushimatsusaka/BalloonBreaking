using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Shooting_Interactive : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClip;
    [SerializeField] private PlayableDirector brokenBalloonTL;
    [SerializeField] private GameObject brokenBalloon;
    [SerializeField] private GameObject baseBalloonHead;
    [SerializeField] AutoRising autoRising;

    void Start()
    {
        //ベースバルーンのマテリアルを取得
        var baseBalMt = baseBalloonHead.GetComponent<MeshRenderer>().material;
        var baseBalCol = baseBalMt.GetColor("_BaseColor");
        //Debug.Log(baseBalMt + "   "+ baseBalCol);

        //ベースバルーンの色をランダムに変更
        Color.RGBToHSV(baseBalCol, out float h, out float s, out float v);
        h = Random.Range(0f, 1f);
        baseBalCol = UnityEngine.Color.HSVToRGB(h, s, v);
        baseBalMt.SetColor("_BaseColor", baseBalCol);
        //Debug.Log("h:"+h+" s:"+s+" v:"+v);

        //ブロークンバルーンの色を変更
        var brokMesh = brokenBalloon.transform.GetChild(0).gameObject;
        var brokBalMt = brokMesh.GetComponent<MeshRenderer>().material;
        brokBalMt.SetColor("_BaseColor", baseBalCol);

        var num = Random.Range(0, audioClip.Count);
        audioSource.clip = audioClip[num];
        //Debug.Log("audioClip num" + num);

        brokenBalloon.SetActive(false);
    }

    public void Shoot()
    {

        //ブロークンバルーンオブジェクトだけ取得して、階層外に出す
        var grandParent = this.gameObject.transform.parent;
        brokenBalloon.transform.SetParent(grandParent);

        //Balloonオブジェクトを非表示にする
        this.gameObject.SetActive(false);

        //破裂用Balloonを表示してタイムラインを再生
        brokenBalloon.SetActive(true);
        brokenBalloonTL.Play();

        //AudioSourceに設定されている音を再生
        audioSource.Play();
    }
}
