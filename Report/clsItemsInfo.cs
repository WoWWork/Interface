using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Manage;
using AxMMMARKLib;
using SYN_TEK;

namespace Report
{
    class clsItemsInfo
    {
        public string Name = string.Empty;
        public string CursorItem { set; get; }

        public string[] ItemsName { set; get; }
        public string[] ItemsType { set; get; }
        public string[] ItemsSpeed { set; get; }
        public string[] ItemsPower { set; get; }
        public string[] ItemsFreq { set; get; }
        public string[] ItemsContent { set; get; }

        public clsItemsInfo(int ItemNumber, AxMMMark face)
        {
            if ((string)face.Tag == "ForeView")
                Name = "Fore";
            else if ((string)face.Tag == "BackView")
                Name = "Back";
            else return;
            ItemsName = new string[ItemNumber];
            ItemsType = new string[ItemNumber];
            ItemsSpeed = new string[ItemNumber];
            ItemsPower = new string[ItemNumber];
            ItemsFreq = new string[ItemNumber];
            ItemsContent = new string[ItemNumber];
            AddName(ItemNumber);
            LoadType(face, ItemNumber);
            LoadInfo(face, ItemNumber);
            GetContext(ItemNumber);
        }

        public void ReLoad(AxMMMark Name)
        {
            LoadType(Name, ItemsName.Length);
            LoadInfo(Name, ItemsName.Length);
            GetContext(ItemsName.Length);
        }
        public void AddName(int ItemNumber)
        {
            string ItemName;
            for(int i = 0; i < ItemNumber; i++)
            {
                ItemName = Enum.GetName(typeof(Items), i);
                ItemsName[i] = ItemName;
            }
        }
        public void GetContext(int ItemNumber)
        {
            string ItemName;
            for(int i = 0; i < ItemNumber; i++)
            {
                ItemName = Enum.GetName(typeof(Items), i);
                LASER.Get_Text(ItemName, ref ItemsContent[i], ItemsType[i]);
            }
        }
        public void LoadType(AxMMMark Name, int ItemNumber)
        {
            string Item;
            for(int i = 0; i < ItemNumber; i++)
            {
                Item = Enum.GetName(typeof(Items), i);
                ItemsType[i] = LASER.Get_Type(Name, Item);
            }
        }

        public void LoadInfo(AxMMMark Name, int ItemNumber)
        {
            for (int x = 0; x < ItemNumber; x++)
            {
                LASER.Get_Speed(Name, ItemsName[x], ref ItemsSpeed[x]);
                LASER.Get_Power(Name, ItemsName[x], ref ItemsPower[x]);
                LASER.Get_Frequency(Name, ItemsName[x], ref ItemsFreq[x]);
            }
        }

    }
}
