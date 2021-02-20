using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public Text txtSaniye;
    public Text txtPuan;

    int saniye = 50;
    int puan = 0;

    private void Start()
    {
        InvokeRepeating("DecreaseSecond", 0.0f, 1f);
    }

    void DecreaseSecond()
    {
        saniye -= 1;

        txtSaniye.text = "SANIYE : " + saniye;

        if (saniye <= 0)
        {
            saniye = 0;

            txtSaniye.text = "OYUN BİTTİ";
            GameOver();
        }
    }

    public void PuanArtir(int _puan)
    {
        this.puan += _puan;
        txtPuan.text = "PUAN : " + this.puan;
    }

    void GameOver()
    {
        Time.timeScale = 0f;
    }

    void Exit()
    {
        Application.Quit();
    }

}
