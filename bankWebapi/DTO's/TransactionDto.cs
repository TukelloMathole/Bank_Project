﻿public class TransactionDto
{
    public int Transaction_ID { get; set; }
    public int Account_Number { get; set; }
    public string Transaction_Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Transaction_Date { get; set; }
    public string Customer_ID { get; set; }
}