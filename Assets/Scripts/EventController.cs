using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public TMP_Text body, choice1, choice2, choice3;
    private const string playerPlaceholder = "[Alex]", evilPlaceholder = "[Xela]", choicePlaceholder = "[choice]", characterPlaceholder = "[char]";
    private string[][] text;
    private string alex = "ALEX", xela = "XELA", chari = "PRINCESS";
    private int page = 0, eventNum = 0, charSelect = 0;
    public Image next, icon, icon2;
    public Sprite mc, villain, princess, warrior, wizard;
    private Sprite charmi;
    public GameObject monologue, dialogue;

    // contains literally all the text
    void Start()
    {
        charmi = princess;

        // intro
        text[0][0] = "On a cold, rainy night...";
        text[0][1] = "[Alex], an accountant, comes home from a long day at work.";
        text[0][2] = "After a series of internal battles with their self, [Alex] begins to question who or what they are.";
        text[0][3] = "They fall asleep, and dream of the conflicts between a warrior, a princess, and a wizard.";
        
        // start
        text[1][0] = "A warrior, a princess, and a wizard are on camelback to venture through the Sahara desert.";
        text[1][1] = "The warrior and wizard have been hired to protect the princess on this journey.";
        text[1][2] = "While the warrior and wizard are fighting over their ideals (brains or brawn), the princess attempts to diffuse the situation.";
        text[1][3] = "However...";
        text[1][4] = "Things get out of hand when the warrior threatens to attack the wizard’s camel.";
        text[1][5] = "The wizard also threatens to cast a spell on the warrior’s camel.";
        text[1][6] = "After the empty threats were made, all three camels miraculously disappear.";
        text[1][7] = "The warrior raises his weapon at the wizard, blaming him for the disappearance...";
        text[1][8] = "But the princess orders him to stop as the wizard claims it was not his doing.";
        text[1][9] = "They decide to venture forth with the princess' encouragement...";
        text[1][10] = "“We'll get there if we walk far enough.”";

        // 1st encounter
        text[2][0] = "The party stumbles upon a fork in the road and there is but one signpost.";
        text[2][1] = "The signpost, damaged and twisted, reads “Danger”, indicating the correct path.";
        text[2][2] = "Since the sign is twisted, the wizard wants to cast a spell to untwist it to its original position.";
        text[2][3] = "This act would cost the wizard some of his mana.";
        // prompt
        text[2][4] = "Would you spend the mana to confirm the correct path? Or guess?";
        // options
        text[2][5] = "cast “arreglo letrero”";
        text[2][6] = "left";
        text[2][7] = "right";
        // results
        text[2][8] = "The wizard untwists the signpost to reveal the correct path. -1 MP";
        text[2][9] = "The party decides to go [choice]. There is no trouble and they proceed unscathed!";
        text[2][10] = "The party decides to go [choice]. They stumble upon a bandit camp whilst the princess becomes injured on their flight. -2 HP";

        // 2nd encounter
        text[3][0] = "The party finds a mysterious weapon in the sands.";
        text[3][1] = "The warrior wishes to attempt to repair it and use it.";
        text[3][2] = "In doing this, the warrior may injure himself and not be able to swing his sword as effectively.";
        // prompt
        text[3][3] = "Would you allow him to attempt it?";
        // options
        text[3][4] = "yes";
        text[3][5] = "no";
        // results
        text[3][6] = "The warrior succeeds in repairing the weapon, and now uses the superior tool for destruction. +2 Max AP";
        text[3][7] = "The warrior fails in repairing the weapon, injuring his arm. -1 Max AP";
        text[3][8] = "The party leaves the weapon in the sands.";

        // 3rd encounter
        text[4][0] = "A merchant appears in the path of the travelers.";
        text[4][1] = "He wants to buy the wizard's spell book for healing; “curo.”";
        // prompt
        text[4][2] = "Do you trade the book for an elixir of life?";
        // options
        text[4][3] = "yes";
        text[4][4] = "no";
        // results
        text[4][5] = "The merchant laughs in glee once he has his hands on the book. He trades them for the elixir. -2 Max MP, +1 Max HP.";
        text[4][6] = "The merchant stomps angrily as the party rejects his offer and moves on.";

        // 4th encounter
        text[5][0] = "The party finds a very deep hole in their path.";
        text[5][1] = "The wizard inspects it and sees some silver chainmail at the bottom.";
        text[5][2] = "The warrior offers to venture down the hole to retrieve it.";
        // prompt
        text[5][3] = "Do you let the warrior climb down?";
        // options
        text[5][4] = "yes";
        text[5][5] = "no";
        // results
        text[5][6] = "The warrior successfully retrieves the chainmail to protect the princess from harm. +2 Max HP";
        text[5][7] = "The warrior climbs down the hole and it collapses. The wizard uses “aleja” to save the warrior from death. -1 MP, -1 AP";
        text[5][8] = "The party does not take the risk.";

        // 5th encounter
        text[6][0] = "Another wizard crosses the path of the travelers.";
        text[6][1] = "He wants to challenge the party’s wizard in a duel.";
        text[6][2] = "If party’s wizard wins, the other wizard will teach them a new spell.";
        // prompt
        text[6][3] = "Do you want the wizards to duel?";
        // options
        text[6][4] = "yes";
        text[6][5] = "no";
        // results
        text[6][6] = "The party’s wizard is triumphant! They learn the “enfrio” spell to cool their tea. 2+ Max MP";
        text[6][7] = "The other wizard is victorious. He learns your “entreno dragon.” -2 Max MP";
        text[6][8] = "The party attempts to flee. The other wizard casts “heria” and it hits the warrior as he defends the princess. -1 HP, -1 AP";
        
        // 6th encounter
        text[7][0] = "The party has found an oasis.";
        text[7][1] = "The warrior and princess are dreadfully tired and want to rest, but the wizard is skeptical.";
        text[7][2] = "He can cast a charm to alert them of any enemies.";
        // prompt
        text[7][3] = "Will you stay or will you go?";
        // options
        text[7][4] = "stay and cast “despierto”";
        text[7][5] = "go";
        text[7][6] = "stay and rest";
        // results
        text[7][7] = "The wizard uses the charm. They rest peacefully. +3 HP, +3 AP, -2 MP";
        text[7][8] = "The wizard uses the charm, revealing a cespool of malefic pixie dust. They leave. -2 MP";
        text[7][9] = "The party enjoyed their beach day without interruption. +3 HP, +3 AP, +3 MP";
        text[7][10] = "The party rests in the cool of the pool. They are quietly engulfed by a strange haze as they sleep.";
        text[7][11] = "They leave, leaving the princess and warrior exhausted. -1 HP, -1 AP";

        // 7th encounter
        text[8][0] = "An injured vagrant is lying aside the road.";
        text[8][1] = "The party calls out to him, but he does not respond.";
        // prompt
        text[8][2] = "Does the warrior carry him to the next town?";
        // options
        text[8][3] = "yes";
        text[8][4] = "no";
        // results
        text[8][5] = "Your benevolence rewards you as the now healty traveler repays you with bottled ether. +2 Max MP, -2 AP";
        text[8][6] = "You forsake your fellow man.";

        // last encounter
        text[9][0] = "Alas, the kingdom gates are in sight!";
        text[9][1] = "They all rejoice in their victory over the desert.";
        text[9][2] = "But, before they could enter, they are stopped by a mysterious figure.";
        text[9][3] = "With the combined appearance of all three members, [Xela] says...";
        text[9][4] = "“Did you think that the desert had an end?”";
        // prompt
        text[9][5] = "“Give me the princess, or I will drown you in the sand!”";
        // options
        text[9][6] = "Okay";
        text[9][7] = "No way!!";
        // hidden no text option
        // results
        text[9][8] = "“You fools!”";
        text[9][9] = "“You imbeciles!”";
        text[9][10] = "** AAAACK!!! ** “You %@$!@^&s!”";

        // end
        text[10][0] = "After defeating [Xela], the party enters the kingdom.";
        text[10][1] = "[Xela] shouts at them as it sinks into the dust it came from...";
        text[10][2] = "“How could you have defeated us?!?”";
        text[10][3] = "“[Alex] . . .”";
        text[10][4] = "“W  E    A  R  E  --”";
        text[10][5] = "** GARBLED **";
        text[10][6] = "The party paused...";
        text[10][7] = "** y  o  u    a  c  c  e  p  t    r  e  a  l  i  t  y **";
        // credits

        // outro
        text[11][0] = "[Alex] abruptly falls out of bed.";
        text[11][1] = "Realizing it was a dream, [Alex] wonders about the three party members.";
        text[11][2] = "The [char] closely parallels [Alex]'s own struggles.";
        text[11][3] = "With the determination to follow the [char]'s example, [Alex] found some peace of mind, despite the rough night.";
        text[11][4] = "They are prepared for existential combat in the future.";
        text[11][5] = "The party did indeed find [Alex], in the desert.";
    }

    // starts the new event dialogue
    public EventController(int eventNum)
    {
        page = 0;
        this.eventNum = eventNum;
        body.text = fillMe(text[eventNum][page]);
        setPortrait();
    }

    private string fillMe(string words)
    {
        return words.Replace(playerPlaceholder, alex).Replace(evilPlaceholder, xela).Replace(characterPlaceholder, chari);
    }

    // call before first nextPage() and after new EventController(eventNum)
    public void setName(string name)
    {
        alex = name;
        List<char> temp = new List<char>(name.ToCharArray());
        temp.Reverse();
        xela = temp.ToArray().ToString();
    }

    // call when starting "scene11", sets the character the player won as 0 = princess, 1 = warrior, 2 = wizard
    public void setCharacter(int num)
    {
        charSelect = num;
        if (num == 1)
        {
            chari = "WARRIOR";
            charmi = warrior;
        } else if (num == 2)
        {
            charmi = wizard;
            chari = "WIZARD";
        }
    }

    // call after making a new EventController(eventNum)
    public void nextPage()
    {
        StartCoroutine("doNext");
    }
    
    private IEnumerator doNext()
    {
        next.gameObject.SetActive(false);
        body.gameObject.SetActive(false);
        setPortrait();
        body.text = fillMe(text[eventNum][page++]);
        yield return new WaitForSeconds(0.5f);
        body.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        next.gameObject.SetActive(true);
    }
    
    // call after the last nextPage()
    public void choose(bool isThree)
    {
        monologue.gameObject.SetActive(false);
        setPortrait();
        choice1.text = text[eventNum][page++];
        choice2.text = text[eventNum][page++];
        choice3.gameObject.SetActive(isThree);
        if (isThree)
        {
            choice3.text = text[eventNum][page++];
        }
        dialogue.gameObject.SetActive(true);
    }

    /* number result for that event index 0, not the actual text[][] index
     * call after choose() */
    public void choiceResult(int resultNum)
    {
        dialogue.gameObject.SetActive(false);
        setPortrait();
        resultNum = page + resultNum;
        string temp = fillMe(text[eventNum][resultNum]);
        body.text = eventNum == 2 ? temp.Replace(choicePlaceholder, text[eventNum][resultNum]) : temp;
        monologue.gameObject.SetActive(true);
    }

    private void setPortrait()
    {
        Sprite temp = mc;
        switch (eventNum)
        {
            case 1:
                temp = princess;
                break;
            case 2:
            case 4:
            case 6:
            case 7:
                temp = wizard;
                break;
            case 3:
            case 5:
            case 8:
                temp = warrior;
                break;
            case 9:
                if (page >= 0  && page <= 1)
                {
                    temp = princess;
                } else if ((page >= 2 && page <= 5) || (page >= 8 && page <= 10))
                {
                    temp = villain;
                }
                break;
            case 10:
                if(page >= 1 && page <= 5)
                {
                    temp = villain;
                }
                break;
            case 11:
                if (page == 5)
                {
                    temp = villain;
                } else if (page == 2 || page == 3)
                {
                    temp = charmi;
                }
                break;
            default:
                break;
        }
        icon.sprite = icon2.sprite = temp;
    }
}
