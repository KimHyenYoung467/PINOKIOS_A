using Sprite.UGUI.UIscript;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class config : MonoBehaviour
{
    //Todo ���� ����â�� ���ùٸ� inventory ���� �ִ� ���ù� �̵� �Լ��� ����� �� ����? 
    //Todo X��ư ���ý� Config â�� ���� �ϱ� 
    //Todo ����â�� ���� ��� ���� �� ���� â�� ���� ���� =>  �׷��� �����հ� ���� ������ ���� ��ȯ �� �� �ִ� ��� 
    //Todo ���� �� �����̴� , ���� �ػ� ���� => mainsoundSlider , voiceSoundSlider, BackSoundSlider /// DropDown x 3 /// Button 1
    
    [Header("script")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private Animator animator;

   

    [Header("Object")]
    [SerializeField] private GameObject configObj;      // ����â ���� ������Ʈ 
    [SerializeField] private GameObject selectbar;      // ���� ���ù� 
    [SerializeField] private Slider mainSlider;         // ��ü ���� 
    [SerializeField] private Slider subSlider;          // ���� ������ ��� ����. ��ü ������ �ڽĵ�� ���� �Ǿ� ����.  
    [SerializeField] private Dropdown viewPortDd;       // �ػ� 
    [SerializeField] private Dropdown cussor;           // ���콺 Ŀ�� ���
    [SerializeField] private Button closeBtn;           // ���� ��ư 

    [SerializeField] private TMP_Text soundValue;       // ���� �� text  ����� 

    private bool _isClick = true;
    //Todo ��ü ���� => ��ü ������ �����̴� ���� �� ����, ��� �� �����̴� ���� ���� 
    //Todo ���� ���� �� ���̽�, ���� ���� ������ �� �ִ� ���� �Ŵ��� Ŭ���� ���� �ʿ� 

    void Start() // ���߿� �������� ������ 
    {
        mainSlider = mainSlider.GetComponent<Slider>();
        subSlider = mainSlider.GetComponentInChildren<Slider>();
        viewPortDd = viewPortDd.GetComponent<Dropdown>();
        cussor = cussor.GetComponent<Dropdown>();
        closeBtn = closeBtn.GetComponent<Button>();

    }
    //Todo (First) x ��ư ���� �� ���� ���� â ���ֱ� 
    //Todo (Second) ���ùٰ� ���콺 ������ ��ġ�� �̵��� �� ���ù��� ���� �ణ ��� ����� 
    //Todo (Third) �κ��丮 cs ���ο� �ִ� ���ù� �̵� �Լ��� ����� ���� ������? 
    //Todo (Four) �����̴� ���� �Լ� 

    //Todo ����, ����� ���� ��ġ�� �����ؼ� ��ü ������ �����̴� ���� �� �Բ� �����̵��� �Ѵ�. 
    //Todo �ػ� ���� DropDown�� ����� ���콺�� Ŭ�� �ÿ� �ػ󵵸� ���� �Ѵ�. => �ػ� ���� ��� Ž�� �ʿ�. 
    //Todo ���콺 Ŀ�� ��� => ����� ���� �����ϳ�, ����� ��������Ʈ�� ���콺 Ŀ���� ����� ���� �ʿ�

    //Todo ���콺 Ŀ�� ����� ��� �ȿ� �ִ� ����� ������ �� �ؽ�Ʈ�� �´� �̹����� ���콺 Ŀ���� ����� �Ǿ�� �Ѵ�. 
    //Todo ����� ���̵�, ������ �޾ƾ� �ұ�? 

 

    private void DeleteConfig(GameObject conObj)       // x ��ư Ŭ�� �� ���� 
    {
        if (!Input.GetMouseButtonDown(0) || !closeBtn.gameObject) return;

        Destroy(conObj);
        Debug.Log("���� â ����");
    }

    private void SliderBar()
    {
        if (mainSlider == null) return;

        mainSlider.minValue = 0;
        mainSlider.maxValue = 1;

        if (!(mainSlider.value <= mainSlider.minValue) || !(mainSlider.value >= mainSlider.maxValue)) return;

        var SoundValue = mainSlider.value.ToString();
        soundValue.text = SoundValue;
        //Todo ���� �Ŵ��� ���� �ʿ� 
    }

    private void PCViewChange() //�ػ� ���� 
    {
        //Todo ���� �ػ󵵸� DropDown ��� �ٿ� ǥ�� Option �߰� 
        //Todo DropDown ����� Ŭ�� ���� ��, �ػ� ���� 
    } 
        
}
