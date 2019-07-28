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

    void Update()
    {
        // TODO regen hp, mp, and ap
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

    public int getMaxHP()
    {
        return Mathf.FloorToInt(hp.maxValue);
    }

    public int getMaxMP()
    {
        return Mathf.FloorToInt(mp.maxValue);
    }

    public int getMaxAP()
    {
        return Mathf.FloorToInt(ap.maxValue);
    }

    public void setHP(int val)
    {
        if (val > getMaxHP())
        {
            return;
        }
        hp.value = val;
        numHP.text = val.ToString();
    }

    public void setMP(int val)
    {
        if (val > getMaxMP())
        {
            return;
        }
        mp.value = val;
        numMP.text = val.ToString();
    }

    public void setAP(int val)
    {
        if (val > getMaxAP())
        {
            return;
        }
        ap.value = val;
        numAP.text = val.ToString();
    }

    public void setMaxHP(int val)
    {
        int temp = getMaxHP();
        hp.maxValue = val;
        PlayerPrefs.SetInt(hpkey, val);
        setHP(getHP() + val - temp);
    }

    public void setMaxMP(int val)
    {
        int temp = getMaxMP();
        mp.maxValue = val;
        PlayerPrefs.SetInt(mpkey, val);
        setHP(getMP() + val - temp);
    }

    public void setMaxAP(int val)
    {
        int temp = getMaxAP();
        ap.maxValue = val;
        PlayerPrefs.SetInt(apkey, val);
        setHP(getAP() + val - temp);
    }

    public void decrementHP()
    {
        setHP(getHP() - 1);
    }

    public void decrementMP()
    {
        setMP(getMP() - 1);
    }

    public void decrementAP()
    {
        setAP(getAP() - 1);
    }

    public void incrementHP()
    {
        setHP(getHP() + 1);
    }

    public void incrementMP()
    {
        setMP(getMP() + 1);
    }

    public void incrementAP()
    {
        setMP(getMP() + 1);
    }

    public bool amidead()
    {
        return getHP() <= 0;
    }
}
