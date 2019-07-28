using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public Slider hp, mp, ap;
    private const string hpkey = "maxHP", mpkey = "maxMP", apkey = "maxAP";
    private TMP_Text numHP, numMP, numAP;
    public static HUDController instance;

    void Start()
    {
        numHP = hp.GetComponent<TMP_Text>();
        numMP = mp.GetComponent<TMP_Text>();
        numAP = ap.GetComponent<TMP_Text>();
        instance = GetComponent<HUDController>();
    }

    public void setHP(int val)
    {
        hp.value = val;
        numHP.text = val.ToString();
    }

    public void setMP(int val)
    {
        mp.value = val;
        numMP.text = val.ToString();
    }

    public void setAP(int val)
    {
        ap.value = val;
        numAP.text = val.ToString();
    }

    public int getHP()
    {
        return Mathf.FloorToInt(hp.value);
    }

    public int getMP()
    {
        return Mathf.FloorToInt(mp.value);
    }

    public int getAP()
    {
        return Mathf.FloorToInt(ap.value);
    }

    public void setMaxHP(int val)
    {
        int temp = Mathf.FloorToInt(hp.maxValue);
        hp.maxValue = val;
        PlayerPrefs.SetInt(hpkey, val);
        setHP(getHP() + val - temp);
    }

    public void setMaxMP(int val)
    {
        int temp = Mathf.FloorToInt(mp.maxValue);
        mp.maxValue = val;
        PlayerPrefs.SetInt(mpkey, val);
        setHP(getMP() + val - temp);
    }

    public void setMaxAP(int val)
    {
        int temp = Mathf.FloorToInt(ap.maxValue);
        ap.maxValue = val;
        PlayerPrefs.SetInt(apkey, val);
        setHP(getAP() + val - temp);
    }

    public void decrementHP()
    {
        setHP(Mathf.FloorToInt(hp.value--));
    }

    public void decrementMP()
    {
        setMP(Mathf.FloorToInt(mp.value--));
    }

    public void decrementAP()
    {
        setAP(Mathf.FloorToInt(ap.value--));
    }
}
