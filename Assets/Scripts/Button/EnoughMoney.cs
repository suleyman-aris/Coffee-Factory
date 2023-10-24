using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnoughMoney : TextPrint, IButtonPrice
{
    private int enough;

    public bool CanInteract = true;

    Button button;

    public int startPrice;
    public float increasePrice = 5;
    public int clickCount;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            clickCount = PlayerPrefs.GetInt(transform.name);
        }

        NewPrice();
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(DecreaseMoney);
        button.onClick.AddListener(NewPrice);
    }

    // Update is called once per frame
    void Update()
    {
        if (MoneyManager.moneyManager.totalMoney >= enough && CanInteract)
        {
            transform.GetComponent<ButtonActive>().ActiveButton();
        }
        else
        {
            transform.GetComponent<ButtonActive>().DeActivateButton();
        }
    }

    private void NewPrice()
    {
        enough = CalculatePrice(startPrice, increasePrice, clickCount);
        string moneyPrint = enough.ToString();
        //string moneyPrint = gameObject.name + "\n" + enough;
        ButtonPrint(enough);
        clickCount += 1;
    }

    private void DecreaseMoney()
    {
        MoneyManager.moneyManager.DecreaseTotalMoney(enough);
    }

    public int CalculatePrice(int startPrice, float increasePrice, int clickCount)
    {
        if (gameObject.name == "Add Machine" && clickCount > 4)
        {
            increasePrice = 10;
            return enough + (int)increasePrice;
        }
        if (gameObject.name == "Merge" && clickCount > 1)
        {
            increasePrice = 200;
            return enough + (int)increasePrice;
        }
        return startPrice + (int)(increasePrice * clickCount);
    }

    private void OnApplicationQuit()
    {
        //clickCount = 1;
        PlayerPrefs.SetInt(transform.name, clickCount - 1);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class EnoughMoney : ButtonPrice
//{
//    float enough;

//    Button button;

//    public float startPrice;
//    public float increasePrice = 5;
//    private float clickCount;
//    // Start is called before the first frame update
//    void Start()
//    {
//        NewPrice(); 
//        button = transform.GetComponent<Button>();
//        button.onClick.AddListener(NewPrice);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (MoneyManager.moneyManager.totalMoney <= enough)
//        {
//            transform.GetComponent<ButtonActive>().ActiveButton();
//        }
//        else
//        {
//            transform.GetComponent<ButtonActive>().DeActivateButton();
//        }
//    }

//    private void NewPrice()
//    {
//        enough = Price(startPrice, increasePrice, clickCount);
//    }
//}
