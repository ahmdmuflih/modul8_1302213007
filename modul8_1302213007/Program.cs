using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection.Metadata;

class Program
{
    static void Main()
    {
        BankTransferConfig config = new BankTransferConfig.Load("D:\\Dokumen\\Kuliah\\Semester 4\\Konstruksi Perangkat Lunak\\modul8_1302213007\\modul8_1302213007\\bank_transfer_config.json");

        Console.WriteLine(config.Lang == "en" ? "Please insert the amount of money to transfer : " : "Masukkan jumlah uang yang akan di transfer : ");
        int amount = int.Parse(Console.ReadLine());

        int transferFee = amount <= config.Transfer.Threshold ? config.Transfer.HighFee : config.Transfer.LowFee;
        int totalAmount = amount + transferFee;

        Console.WriteLine(config.Lang == "en" ? $"Transfer fee = {transferFee}" : $"Biaya transfer = {transferFee}");
        Console.WriteLine(config.Lang == "en" ? $"Total amount = {totalAmount}" : $"Total biaya = {totalAmount}");

        Console.WriteLine(config.Lang == "en" ? "Select Transfer Method : " : "Pilih metode transfer : ");
        for (int i = 0; i < config.Methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        Console.Write(config.Lang == "en" ? $"Please type \"{config.Confirmation.En}\" to confirm the transaction : " : $"Ketik \"{config.Confirmation.Id}\" untuk mengkonfimasi transaksi : ");
        string confirmation = Console.ReadLine();

        if (confirmation == config.Confirmation.En || confirmation == config.Confirmation.Id)
        {
            Console.WriteLine(config.Lang == "en" ? "The transfer is complet " : "Proses transaksi berhasil");
        } else
        {
            Console.WriteLine(config.Lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
        }
    }
}