using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class Menu_StarGroup : MonoBehaviour
{
    //public BBUIButton btnAddCoin;
    public Text txtStar;
    
    void Start()
    {
    //    btnAddCoin.OnPointerClickCallBack_Completed.AddListener(TouchAddCoin);
        //Config.OnChangeCoin += OnChangeCoin;
        ShowCoin();
    }

    //private void OnDestroy()
    //{
    //    Config.OnChangeCoin -= OnChangeCoin;
    //}


    //public void OnChangeCoin(int coinValue)
    //{
    //    ShowCoin();
    //}

    public void ShowCoin()
    {
        DOTween.Kill(txtStar.transform);

        //txtCoin.text = $"{Config.currCoin}";
        txtStar.text = PrefsManager.ShowStars().ToString();
        txtStar.transform.localScale = Vector3.one;
        txtStar.transform.DOPunchScale(Vector3.one * 0.3f, 0.2f, 10, 2f).SetEase(Ease.InOutBack).SetRelative(true).SetLoops(3, LoopType.Restart);
    }

    //public void TouchAddCoin()
    //{
    //    MenuManager.instance.OpenShopCoin();
    //}
}
