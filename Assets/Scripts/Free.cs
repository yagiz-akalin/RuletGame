using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Free : MonoBehaviour
{
    // A list to store 14 yellow boxes while the roulette mechanism is working  
    [SerializeField]
    GameObject[] objectsYellow;

    // A list to store 14 blue boxes while the roulette mechanism chooses certain reward
    [SerializeField]
    GameObject[] objectsBlue;

    // A list to store 14 grey boxes while the roulette mechanism stops after choosing certain reward
    [SerializeField]
    GameObject[] objectsGrey;

    // A list to store tick shaped win sign
    [SerializeField]
    GameObject[] objectsIcon;

    // A list to store 14 different rewards, i.e. foods
    [SerializeField]
    GameObject[] objectsRewards;

    //A button object to indicate Free Button to start the roulette
    [SerializeField]
    Button freeButton;

    //A button to indicate our Wallet
    [SerializeField]
    Button walletButton;

    //A list of 14 different locations which indicate each reward's location in our wallet
    [SerializeField]
    GameObject[] Loc1, Loc2, Loc3, Loc4, Loc5, Loc6, Loc7, Loc8, Loc9, Loc10, Loc11, Loc12, Loc13, Loc14;

    //A variable to keep indexes of images. We determine which reward the relevant point corresponds to in our wallet
    public List<int> numbers;

    //A counter variable used to indicate which round of roulette is in 
    public int counter;

    public IEnumerator Play()
    {

        //The game resets when the roulette reaches the last round. 
        if (numbers.Count == 14)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            freeButton.interactable = false; //Free Button is inactive while roulette keeps spinning
            walletButton.interactable = false; //Wallet Button is inactive while roulette keeps spinning

            //Random numbers from 1 to 3 are generated and the roulette is initially turned by this random number
            int randomNumber = Random.Range(1, 4); 
            // print(randomNumber);
            Debug.Log(randomNumber);

            for (int i = 0; i < randomNumber; i++)
            {
                foreach (var item in objectsYellow)
                {
                    item.SetActive(true);
                    yield return new WaitForSeconds(.2f);
                    item.SetActive(false);
                }
            }

            //A random reward will be chosen according to this random number.
            int randomRewards = Random.Range(0, 14);

            // print("RANDOM REWARDS = " + randomRewards);
            Debug.Log("RANDOM REWARDS = " + randomRewards);

            if (numbers.Contains(randomRewards))
            {
                print("There is a same number");
                freeButton.interactable = true;
            }
            else
            {
                counter++;
                print("Counter" + counter);
                numbers.Add(randomRewards);
                //In this switch case, the chosen reward will be sent to the wallet.
                switch (counter)
                {
                    case 1:  Loc1[randomRewards].SetActive(true); break;
                    case 2:  Loc2[randomRewards].SetActive(true); break;
                    case 3:  Loc3[randomRewards].SetActive(true); break;
                    case 4:  Loc4[randomRewards].SetActive(true); break;
                    case 5:  Loc5[randomRewards].SetActive(true); break;
                    case 6:  Loc6[randomRewards].SetActive(true); break;
                    case 7:  Loc7[randomRewards].SetActive(true); break;
                    case 8:  Loc8[randomRewards].SetActive(true); break;
                    case 9:  Loc9[randomRewards].SetActive(true); break;
                    case 10: Loc10[randomRewards].SetActive(true); break;
                    case 11: Loc11[randomRewards].SetActive(true); break;
                    case 12: Loc12[randomRewards].SetActive(true); break;
                    case 13: Loc13[randomRewards].SetActive(true); break;
                    case 14: Loc14[randomRewards].SetActive(true); break;
                }
                //The roulette keeps spinning until we reach the index of the chosen reward
                for (int i = 0; i < randomRewards; i++)
                {
                    objectsYellow[i].SetActive(true);
                    yield return new WaitForSeconds(.2f);
                    objectsYellow[i].SetActive(false);
                }
                //The yellow box glows twice after we reach the certain reward
                for (int i = 0; i < 2; i++)
                {
                    objectsYellow[randomRewards].SetActive(true);
                    yield return new WaitForSeconds(.2f);
                    objectsYellow[randomRewards].SetActive(false);
                    yield return new WaitForSeconds(.2f);
                    objectsYellow[randomRewards].SetActive(true);
                    yield return new WaitForSeconds(.2f);
                    objectsYellow[randomRewards].SetActive(false);
                    yield return new WaitForSeconds(.2f);
                }
                //The yellow box becomes blue, then the tick sign appears.
                objectsBlue[randomRewards].SetActive(true);
                objectsIcon[randomRewards].SetActive(true);
                yield return new WaitForSeconds(2f);
                objectsBlue[randomRewards].SetActive(false);
                objectsRewards[randomRewards].SetActive(false);
                //Finally the box become dark grey and the reward has been chosen
                objectsGrey[randomRewards].SetActive(true);
                freeButton.interactable = true;
                walletButton.interactable = true;
            }
        }

    }

    public void EnumPlay()
    {
        StartCoroutine(Play());
    }
    
}
