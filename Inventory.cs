using Sprite.UGUI.UIscript.Item;
using Sprite.UGUI.UIscript.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;


// Todo (Clear) SelectBar 를 받아와서, SelectBar 의 현재 위치에서 마우스 포인터의 위치로 이동하여, (Clear) 

// Todo 클릭 시에 ImgBG(부분 Clear) 및 ItemStatus 에 설명창 띄우기 

// Todo Item의 Text 오브젝트 내의 내용을 아이템 아이디에 맞춰서 변경하고, 이미지 또한 변경이 필요하다.


//Todo Item의 셀렉트 바의 위치에 따라 선택된 설명 창의 이미지를 변경 하고, 설명 창의 설명 란 내용을 변경.

namespace Sprite.UGUI.UIscript
{
    public abstract class Inventory : MonoBehaviour
    {
        [Header("Script")] 
        private InventoryManager _inventoryManager;
        private Animation _animation;
        [SerializeField] private ItemUnitInfo _itemUnit;
        [SerializeField] private InvenSetInit _setinven;
        
        [Header("Object")] 
        private RectTransform _rect;
        [SerializeField] private RectTransform selectBar; // SelectBar 오브젝트 
        private GameObject _itemTable; // 아이템 테이블 오브젝트 
        private GameObject _itemStatus; // 아이템 스테이터스 오브젝트 
        private TMP_Text _iStatusText; // Text_MeshPro 텍스트 상자 내용
        
        [Header("Sprite")]
        [SerializeField] private Image _itemthisImg;  // 아이템 이미지 변경용 
   
        //Todo 클릭 위치에 따라서 인벤토리 테이블을 선택하는 SelectBar 이동 
        public  Vector3 MoveSelectBar(RectTransform SelectBar, GameObject gameObject)
        {
            // 현재 선택바 가 어디에 위치해 있는 지 확인.
            // 클릭 시 선택바의 위치를 클릭한 위치로 이동. 
            // 필요 변수 : 선택바의 현재 위치를 담을 변수, 클릭한 위치를 담을 변수.

            //_selectBar.transform.SetParent(_itemTable.transform);

            var selPos = SelectBar.transform.position; // 선택바의 현재 위치 저장 
            selPos.z = 0f;

            if (Input.GetMouseButtonDown(0) && gameObject.CompareTag(gameObject.name) || gameObject.CompareTag("Quest")) 
            {
                SelectBar.transform.position = Input.mousePosition; // 선태바의 위치를 마우스 포인터로 선택한 아이템 테이블 위치로 이동. 
                selPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, selPos.z);
            }

            if (SelectBar.transform.position != Input.mousePosition) return SelectBar.position; //Todo 현재 셀렉트 바의 위치 전달 
        
            //선택바와 마우스 포인터로 클릭한 위치가 같을 때, 선택시 선택바의 크기 줄였다가 크게 하는 선택 표현 하기 
            SelectBar.localScale -= Vector3.one; 
            SelectBar.localScale += Vector3.one;
            return SelectBar.position; 
        }
        //Todo 선택바가 선택한 위치에 있는 아이템의 이미지를 아이템 status 이미지 부분에 출력 
        //Todo 선택바가 현재 위치에서 이동할 시, 이동된 위치에 있는 아이템이 비어있으면 냅두고,
        //Todo 아이템이 있을 때 변경된 위치에 있는 아이템의 이미지로 변경.
      
        private void Imgprint(Image itemChangeImg, GameObject itemTable)
        {
            MoveSelectBar(selectBar, itemTable);
            
            var thisImg = _itemthisImg;
                thisImg.sprite = _itemUnit.ItemImage.sprite;
            
            //Todo 선택바 위치가 현재 아이템이 있는 테이블 위치에 동일 할 때  
            // 그리고, 선택바의 위치가 바뀌면서 아이템의 아이디가 변경된 게 확인 되었을 때,
            // 현재 아이템의 아이디와 바뀐 아이템의 아이디를 변경 되었을 시, 이미지를 바꾼다. 
            if (selectBar.transform.position.Equals(Input.mousePosition) && _itemUnit.Id.Equals(_itemUnit.Id)) 
            {
                thisImg.sprite = _itemUnit.ItemImage.sprite;
                Debug.Log($"{thisImg}"); // 현재 이미지 출력 
            }
            else 
            {
                 // Todo 아이템의 아이디가 동일하지 않을 때, 아이템의 아이디에 따른 이미지로 변경
                 thisImg.sprite = itemChangeImg.sprite;
                 Debug.Log("현재 이미지 변경 ");
            }
        }

        //Todo Status 정보 설명창 변환 
        //Todo Status 현재 텍스트 오브젝트가 무엇인지 확인, 오브젝트를 받고 ,확인 한다. 
        //Todo Status 현재 텍스트 오브젝트의 내용을 변경할 수 있도록 한다. 
        void StatusTextChange(TMP_Text TextObj, string text)
        {
            if (_iStatusText == null) return;

            _iStatusText = TextObj; 

            _iStatusText = TextObj; // 현재 오브젝트를 변경 
            if (_iStatusText.CompareTag("Invnetory") || _iStatusText.CompareTag("Quest"))
            {
                _iStatusText.text = text;
            }
            
                print("텍스트 오브젝트 변경 완료");
           

            //Todo 퀘스트 와 합병 
        }
        
    }
} 


