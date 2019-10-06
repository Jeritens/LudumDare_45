using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shop : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    
    //Rigidbody2D player;
    public Product[] products;
    public BallProduct[] ballProducts;
    public float heightUpgrade;
    public float initHeight;
    public float initialVelUpgrade;
    public Button inVelBut;
    public Button heightBut;
    //public Transform Canvas;
    public scoring score;
    public PlayerStats pS;
    public GameObject panel;
    public TextMeshProUGUI price;
    public TextMeshProUGUI description;
    List<Button> balls = new List<Button>();
    public Transform ballContainer;
    public Color boughtColor;
    public Color selectedColor;
    // Start is called before the first frame update
    [System.Serializable]
    public struct Product
    {
        public float start;
        public float baseNumber;
        [TextArea(2,5)]
        public string description;
    }
    [System.Serializable]
    public struct BallProduct
    {
        public string name;
        public float start;
        [TextArea(2,5)]
        public string description;
        public int state;
    }
    public void hover(int index){
        panel.SetActive(true);
        float price = products[index].start;
        int count = 0;
        switch (index)
        {
            case 0:
                count = PlayerPrefs.GetInt("heightUpgradeCount");
                price = price*Mathf.Pow(products[index].baseNumber,count);
                description.text = products[index].description.Replace("<value>",((count+1)*heightUpgrade+initHeight).ToString());
                break;
            case 1:
                count = PlayerPrefs.GetInt("initVelUpgradeCount");
                price = price*Mathf.Pow(products[index].baseNumber,count);
                description.text = products[index].description.Replace("<value>",((count+1)*initialVelUpgrade).ToString());
                break;
        }
        this.price.text = price.ToString();
    }
    public void hoverBall(int index){
        panel.SetActive(true);
        float price = ballProducts[index].start;
        switch (ballProducts[index].state){
            case 0:
                description.text = "buy a "+ballProducts[index].name+"\n";
                this.price.text = price.ToString();
                break;
            case 1:
                description.text = "select the "+ballProducts[index].name +"\n";
                this.price.text="/";
                break;
            case 2:
                description.text= "";
                panel.SetActive(false);
            break;
        }
        description.text += ballProducts[index].description;
        
    }
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        ballz();
        
        if(!PlayerPrefs.HasKey("initVelUpgradeCount")){
            PlayerPrefs.SetInt("initVelUpgradeCount",0);
        }
        else{
            int count = PlayerPrefs.GetInt("initVelUpgradeCount");
            pS.SetInitVel(count*initialVelUpgrade);
            if(pS.GetMaxInk()<(products[1].start*Mathf.Pow(products[1].baseNumber,count))){
                inVelBut.interactable = false;
            }
        }
        if(!PlayerPrefs.HasKey("heightUpgradeCount")){
                PlayerPrefs.SetInt("heightUpgradeCount",0);
        }
        else{
            int count = PlayerPrefs.GetInt("heightUpgradeCount");
            pS.SetStartPosition(Vector2.up* (count *heightUpgrade+initHeight));
            if(pS.GetMaxInk()<(products[0].start*Mathf.Pow(products[0].baseNumber,count))){
                heightBut.interactable = false;
            }
            //Canvas.position = new Vector2(Canvas.position.x,player.position.y);
        } 
    }
    void ballz(){
        for(int i = 0; i<ballContainer.childCount;i++){
            balls.Add(ballContainer.GetChild(i).GetComponent<Button>());
            if(PlayerPrefs.HasKey("ball"+i.ToString())){
                if(PlayerPrefs.GetInt("ball"+i.ToString())==1){
                    markAsBought(i);

                }
                else if(PlayerPrefs.GetInt("ball"+i.ToString())==2){
                    markAsSelected(i);
                }
                else if(pS.GetMaxInk()<ballProducts[i].start){
                    balls[i].interactable = false;

                }
            }
        }
    }
    void markAsBought(int index){
        ballProducts[index].state = 1;
        PlayerPrefs.SetInt("ball"+index.ToString(),1);
        ColorBlock col = balls[index].colors;
        col.normalColor = boughtColor;
        balls[index].colors = col;
    }
    void markAsSelected(int index){
        for(int i = 0; i< ballProducts.Length;i++){
            if(ballProducts[i].state==2){
                markAsBought(i);
            }
        }
        ballProducts[index].state = 2;
        PlayerPrefs.SetInt("ball"+index.ToString(),2);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GameObject g = GameObject.Instantiate(ballPrefabs[index],pS.GetStartPosition(),Quaternion.identity);
        pS.SetPlayer(g);
        ColorBlock col = balls[index].colors;
        col.normalColor = selectedColor;
        balls[index].colors = col;
        
    }
    public void AddInitVel(){
        
        int newCount= PlayerPrefs.GetInt("initVelUpgradeCount")+1;
        if(Pay(products[1],newCount-1)){
            PlayerPrefs.SetInt("initVelUpgradeCount",newCount);
            pS.SetInitVel(PlayerPrefs.GetInt("initVelUpgradeCount")*initialVelUpgrade);
        }
        if(pS.GetMaxInk()<(products[1].start*Mathf.Pow(products[1].baseNumber,newCount))){
                inVelBut.interactable = false;
            }
        

    }
    public void AddHeight(){
        int newCount= PlayerPrefs.GetInt("heightUpgradeCount")+1;
        if(Pay(products[0],newCount-1)){
            PlayerPrefs.SetInt("heightUpgradeCount",newCount);
            pS.SetStartPosition(Vector2.up* (PlayerPrefs.GetInt("heightUpgradeCount")*heightUpgrade+initHeight));
            //Canvas.position = new Vector2(Canvas.position.x,player.position.y);
        }
        if(pS.GetMaxInk()<(products[0].start*Mathf.Pow(products[0].baseNumber,newCount))){
            heightBut.interactable = false;
        }
        
    }
    public void BuyBall(int index){
        switch (ballProducts[index].state)
        {
            case 0:
                if(Pay(ballProducts[index])){
                    markAsSelected(index);
                }
                

                break;
            case 1:
                markAsSelected(index);
                break;
            default:
                return;
        }
        hoverBall(index);
    }

    // Update is called once per frame
    void Update()
    {
        if(pS.GetPlayer().GetComponent<Rigidbody2D>().isKinematic == false){
            closeShop();
        }
    }
    void closeShop(){
        gameObject.SetActive(false);
    }
    bool Pay(Product c, int exponent){
        float price =-(c.start*Mathf.Pow(c.baseNumber,exponent));
        if(pS.GetMaxInk()>-price){
            score.changeHS(price);
            return true;
        }
        else{
            return false;
        }
    }
    bool Pay(BallProduct c){
        float price =-c.start;
        if(pS.GetMaxInk()>-price){
            score.changeHS(price);
            return true;
        }
        else{
            return false;
        }
    }
}
