using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Text timeT; //TimeText ������Ʈ�� ��Ƶ� ����
    float time = 0; //�÷��� Ÿ��



    bool isGameOver = false; //������ �������� �Ǵ��� ����

    public GameObject GameClear;
    void Start()
    {

        timeT = GameObject.Find("TimeText").GetComponent<Text>();
        //���̾��Ű�� �ִ� ������Ʈ �� TimeText��� �̸��� ������Ʈ�� ã��, �� ������Ʈ�� �ִ� Text ������Ʈ�� timeT������ �����. ����

        //UI��� ��Ȱ��ȭ

    }

    void Update()
    {
        if (isGameOver) return; //������ �����ٸ� Update�Լ��� ��������

        time += Time.deltaTime; //�÷��� Ÿ�� ����
        timeT.text = "TIME\n" + SetTime((int)time); //�ؽ�Ʈ�� �ð� ǥ��
    }

    string SetTime(int time) //00:00 �������� �ð� ǥ������ �Լ�
    {
        string min = (time / 60).ToString(); //��

        if (int.Parse(min) < 10) min = "0" + min; //10�� �Ʒ��� 0�� ������

        string sec = (time % 60).ToString(); //��

        if (int.Parse(sec) < 10) sec = "0" + sec; //10�� �Ʒ��� 0�� ������

        return min + ":" + sec;
    }

    public void GameOver()
    {

        //���� ���� �� UI Ȱ��ȭ
        GameClear.SetActive(true);

        //���� ���� ���·� ����
        Time.timeScale = 0; //���� �ð��� ����
    }

    public void RestartGame()
    {
        //���� �����
        Time.timeScale = 1; //���� �ð� �簳
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //���� �� �ٽ� �ε�
    }
}
