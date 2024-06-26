﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class PropertyManager
    {
        public static PropertyManager m_propertyManager { get; private set; }
        public static Property[] properties= new Property[40];//40 pol - 4 kwadraty - 8 do oplaty, 3xSkrzynka, 3xSzansa
        int g_CurrentPropertyIndex = -1;
        public static string[] nazwy = Extensions.GetPropNameTable();//22 elem. tablica nazw
        public PropertyManager()
        {
            //fill Properties
            m_propertyManager = this;
            var b_Manager = BoardManager.m_boardManager;
            int j = 0;
            for (int i = 0; i < 40; i++)
            {
                Cell cell = b_Manager.findCellById(i);
                if (cell.getCellType() == Cell.fieldType.Property)
                {
                    properties[i] = new Property(i, nazwy[j], i * 25 + 25);
                    j++;
                }
                else
                {
                    properties[i] = null;
                }
            }
        }

        public void setCurrentPropertyIndex(int index)
        {
            g_CurrentPropertyIndex = index;
        }

        public int getCurrentPropertyIndex()
        {
            return g_CurrentPropertyIndex;
        }

        public Property findPropertyById(int propertyId)
        {
            Console.WriteLine("findPropertyById: " + propertyId);
            return properties[propertyId];
        }
    }
}
