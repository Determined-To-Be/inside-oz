using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventController : MonoBehaviour
{
    public TMP_Text body;
    private const string playerPlaceholder = "[Alex]", choicePlaceholder = "[choice]";
    private string[][] text;
    
    void Start()
    {
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
        text[1][10] = "“If we walk far enough, we shall sometime come to someplace.”";

        // 1st encounter
        text[2][0] = "The party stumbles upon a fork in the road and there is but one signpost.";
        text[2][1] = "The signpost, damaged and twisted, reads “Danger”, indicating the correct path.";
        text[2][2] = "Since the sign is twisted, the wizard wants to cast a spell to untwist it to its original position.";
        text[2][3] = "This act would cost the wizard some of his mana.";
        // prompt
        text[2][4] = "Would you spend the magic to confirm the correct path (-1 Magic Power)? Or guess (Chance of -2 Max Life)?";
        // options
        text[2][5] = "cast “arreglo letrero”";
        text[2][6] = "left";
        text[2][7] = "right";
        // results
        text[2][8] = "The wizard untwists the signpost to reveal the correct path. -1 MP";
        text[2][9] = "The party decides to go [choice]. There is no trouble and they proceed unscathed!";
        text[2][10] = "The party decides to go [choice]. They stumble upon a bandit camp whilst the princess becomes injured on their flight. -2 Max HP";

        // 2nd encounter
        text[3][0] = "The party finds a mysterious weapon in the sands.";
        text[3][1] = "The warrior wishes to attempt to repair it and use it.";
        text[3][2] = "In doing this, the warrior may injure himself and not be able to swing his sword as effectively.";
        // prompt
        text[3][3] = "Would you allow him to attempt it (Success: +2 Max Attack, Fail: -1 Max Attack)?";
        // options
        text[3][4] = "yes";
        text[3][5] = "no";
        // results
        text[3][6] = "The warrior succeeds in repairing the weapon, and now uses the superior tool for destruction. +2 AP";
        text[3][7] = "The warrior fails in repairing the weapon, injuring his arm. -1 AP";
        text[3][8] = "The party leaves the weapon in the sands.";

        // 3rd encounter
        text[4][0] = "A merchant appears in the path of the travelers.";
        text[4][1] = "He wants to buy the wizard's spell book for healing; “arreglo letrero”.";
        text[4][2] = "";
        text[4][3] = "";
        // prompt
        text[4][4] = "";
        // options
        text[4][5] = "";
        text[4][6] = "";
        text[4][7] = "";
        // results
        text[4][8] = "";
        text[4][9] = "";
        text[4][10] = "";

        // 3rd encounter
        text[4][0] = "";
        text[4][1] = "";
        text[4][2] = "";
        text[4][3] = "";
        // prompt
        text[4][4] = "";
        // options
        text[4][5] = "";
        text[4][6] = "";
        text[4][7] = "";
        // results
        text[4][8] = "";
        text[4][9] = "";
        text[4][10] = "";
    }

    void Update()
    {
        // value.text = ...
    }


}
