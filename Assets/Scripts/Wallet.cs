using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField]
    GameObject WalletPanel;

    public void walletOpen()
    {
        WalletPanel.SetActive(true);
    }

    public void walletClose()
    {
        WalletPanel.SetActive(false);
    }


}
