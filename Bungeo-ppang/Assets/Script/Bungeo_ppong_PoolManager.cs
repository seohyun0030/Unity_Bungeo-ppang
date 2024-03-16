using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bungeo_ppong_PoolManager : MonoBehaviour
{
    public static Bungeo_ppong_PoolManager i;
    [SerializeField]GameObject bungeo_ppong_Prefeds;
    [SerializeField] int initBungeo_ppongCount = 30;

    private void Awake()
    {
        i = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatBungeo_ppong(initBungeo_ppongCount);
    }

    public void CreatBungeo_ppong(int cnt = 1)
    {
        for (int i = 0; i <cnt; i++)
        {
            Instantiate(bungeo_ppong_Prefeds, transform);   //�ؾ ����
        }
    }

    public void UseBuneo_ppong(Vector2 p, Quaternion rot)
    {
        if(transform.childCount == 0)
        {
            CreatBungeo_ppong(); //�ؾ�� ���ٸ� ����
        }

        Bungeo_ppong_BulletComponent bbp = transform.GetChild(0).GetComponent<Bungeo_ppong_BulletComponent>(); //pool 0��° ������Ʈ�� ����

        bbp.transform.position = p;         //�ؾ ��ġ ����
        bbp.transform.rotation = rot;       //�ؾ ���� ����
        bbp.gameObject.SetActive(true);     //���� Ȱ��ȭ
        bbp.transform.parent = null;        //�θ� ���� ����
        bbp.Move();                         //������ ����
    }

    public void ReturnBungeo_ppong(GameObject bbp)
    {
        bbp.gameObject.SetActive(false);
        bbp.transform.SetParent(transform);
        //��� �� �ٽ� pool������ ������

    }
}