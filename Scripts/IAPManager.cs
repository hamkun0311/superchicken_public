using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class IAPManager : MonoBehaviour, IStoreListener
{

    public List<CatalogItem> Catalog;
    public List<string> StoreItemID = new List<string>();
    public List<string> StoreItemIDValue = new List<string>();
    public List<string> StoreItemIDCurrency = new List<string>();
    private static IStoreController m_StoreController;

    public Text txt_Ruby50_Btn;
    public Text txt_Ruby300_Btn;

    // Start is called before the first frame update
    void Start()
    {
        RefreshIAPItems();
    }

    // Update is called once per frame
    void Update()
    {
        if(StoreItemID.Count < 1 && Catalog.Count > 1 && StoreItemIDValue.Count < 1)
        {
            InitializePurchasing2();
        }

    }

    public bool IsInitialized {
        get {
            return m_StoreController != null && Catalog != null;
        }
    }

    private void RefreshIAPItems() {
        PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(){CatalogVersion = "MONEY"}, result => {
            Catalog = result.Catalog;

            // Make UnityIAP initialize
            InitializePurchasing();
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void InitializePurchasing() {
        // If IAP is already initialized, return gently
        if (IsInitialized) return;

        // Create a builder for IAP service
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(AppStore.GooglePlay));
        // Register each item from the catalog
        foreach (var item in Catalog) {
            StoreItemID.Add(item.ItemId);
            builder.AddProduct(item.ItemId, ProductType.Consumable);
        }
        // Trigger IAP service initialization
        UnityPurchasing.Initialize(this, builder);
    }
    public void InitializePurchasing2() {

        // Create a builder for IAP service
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(AppStore.GooglePlay));
        // Register each item from the catalog
        foreach (var item in Catalog) {
            StoreItemID.Add(item.ItemId);
            builder.AddProduct(item.ItemId, ProductType.Consumable);
        }
        // Trigger IAP service initialization
        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
        m_StoreController = controller;
        txt_Ruby50_Btn.text = m_StoreController.products.WithID(StoreItemID[0]).metadata.localizedPrice.ToString() + " " 
                            + m_StoreController.products.WithID(StoreItemID[0]).metadata.isoCurrencyCode.ToString() ;
        txt_Ruby300_Btn.text = m_StoreController.products.WithID(StoreItemID[1]).metadata.localizedPrice.ToString() + " " 
                            + m_StoreController.products.WithID(StoreItemID[1]).metadata.isoCurrencyCode.ToString() ;
    }
    public void OnInitializeFailed(InitializationFailureReason error) {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e) {
        // NOTE: this code does not account for purchases that were pending and are
        // delivered on application start.
        // Production code should account for such case:
        // More: https://docs.unity3d.com/ScriptReference/Purchasing.PurchaseProcessingResult.Pending.html

        if (!IsInitialized) {
            return PurchaseProcessingResult.Complete;
        }

        // Test edge case where product is unknown
        if (e.purchasedProduct == null) {
            Debug.LogWarning("Attempted to process purchase with unknown product. Ignoring");
            return PurchaseProcessingResult.Complete;
        }

        // Test edge case where purchase has no receipt
        if (string.IsNullOrEmpty(e.purchasedProduct.receipt)) {
            Debug.LogWarning("Attempted to process purchase with no receipt: ignoring");
            return PurchaseProcessingResult.Complete;
        }

        Debug.Log("Processing transaction: " + e.purchasedProduct.transactionID);

        // Deserialize receipt
        var googleReceipt = GooglePurchase.FromJson(e.purchasedProduct.receipt);

        // Invoke receipt validation
        // This will not only validate a receipt, but will also grant player corresponding items
        // only if receipt is valid.
        PlayFabClientAPI.ValidateGooglePlayPurchase(new ValidateGooglePlayPurchaseRequest() {
            // Pass in currency code in ISO format
            CurrencyCode = e.purchasedProduct.metadata.isoCurrencyCode,
            // Convert and set Purchase price
            PurchasePrice = (uint)(e.purchasedProduct.metadata.localizedPrice * 100),
            // Pass in the receipt
            ReceiptJson = googleReceipt.PayloadData.json,
            // Pass in the signature
            Signature = googleReceipt.PayloadData.signature
            }, result => {
                    Debug.Log("Validation successful!");
            },
           error => Debug.Log("Validation failed: " + error.GenerateErrorReport())
        );

        return PurchaseProcessingResult.Complete;
    }

    public Product GetProductValue(string productId)
    {
        return m_StoreController.products.WithID(productId);
    }

    void BuyProductID(string productId) {
            // If IAP service has not been initialized, fail hard
            if (!IsInitialized) throw new Exception("IAP Service is not initialized!");

            // Pass in the product id to initiate purchase
            m_StoreController.InitiatePurchase(productId);
        }

    public void onClickBuyRB1btn()
    {
        BuyProductID(StoreItemID[0]);
    }

    public void onClickBuyRB2btn()
    {
        BuyProductID(StoreItemID[1]);
    }

    public void grantUserMoney(int sellRubyCnt)
    {
        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest() {
                VirtualCurrency = "EG", Amount = sellRubyCnt * 100}
                            , (result) => {
                                        print("success");
                            }
                            
                            , (error) => {
                                        print("fail");        
                            });
    }



    public class JsonData {
        // JSON Fields, ! Case-sensitive

        public string orderId;
        public string packageName;
        public string productId;
        public long purchaseTime;
        public int purchaseState;
        public string purchaseToken;
    }

    public class PayloadData {
        public JsonData JsonData;

        // JSON Fields, ! Case-sensitive
        public string signature;
        public string json;

        public static PayloadData FromJson(string json) {
            var payload = JsonUtility.FromJson<PayloadData>(json);
            payload.JsonData = JsonUtility.FromJson<JsonData>(payload.json);
            return payload;
        }
    }

    public class GooglePurchase {
        public PayloadData PayloadData;

        // JSON Fields, ! Case-sensitive
        public string Store;
        public string TransactionID;
        public string Payload;

        public static GooglePurchase FromJson(string json) {
            var purchase = JsonUtility.FromJson<GooglePurchase>(json);
            purchase.PayloadData = PayloadData.FromJson(purchase.Payload);
            return purchase;
        }

    }
}
