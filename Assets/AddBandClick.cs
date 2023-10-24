using UnityEngine;
using UnityEngine.UI;

public class AddBandClick : MonoBehaviour
{
    public int activeBand;
    public LayerMask Rayast;

    public GameObject addButton;

    private void Start()
    {
        addButton = GameObject.Find("Add Machine");
    }

    void Update()
    {
        // Ekran dokunmalarýný kontrol et
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Dokunma baþladýysa ve dokunma pozisyonu Quad'a temas ediyorsa
            if (touch.phase == TouchPhase.Began && IsTouchOverQuad(touch.position))
            {
                // Tetiklenecek fonksiyonu burada çaðýrabilirsiniz
                QuadTouched();
            }
        }
    }

    bool IsTouchOverQuad(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        // Raycasting kullanarak Quad'a dokunmanýn kontrolünü yap
        if (Physics.Raycast(ray, out hit, 10000, Rayast))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log(hit.collider.gameObject.name);
                return true;
            }
        }

        return false;
    }

    void QuadTouched()
    {
        BandActiveSave resetBand = GameObject.Find("Band List Manager").GetComponent<BandActiveSave>();
        resetBand.activeBandCount = activeBand;
        
        transform.parent.GetComponent<AddBand>().BandActive();
        transform.parent.GetComponent<AddBand>().BandDeActive();

        addButton.GetComponent<EnoughMoney>().CanInteract = true;
        MatchCMList.matchCMList.MatchList();
        BandPanelControl panelControl = GameObject.Find("Band Panel Manager").GetComponent<BandPanelControl>();
        panelControl.PanelActivator();

    }
}
