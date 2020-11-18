using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TestApp.ViewModels
{
    public class DisplayItem:BaseViewModel
    {
        private Color areaColor;
        private int cellHeight = 80;
        private bool isDisplayed = true;
        private bool isNotRead = false;
        private bool selected;
        private DateTime? terminationDate;
        private string todoKind;

        public DisplayItem(string title)
        {
            Title = title;
        }

        public int CellHeight
        {
            get => cellHeight;
            set => this.SetProperty(ref cellHeight, value);
        }
        public bool IsDisplayed
        {
            get => isDisplayed;
            set
            {
                this.SetProperty(ref isDisplayed, value);

                if (value)
                {
                    CellHeight = 80;
                }
                else
                {
                    CellHeight = 0;
                }
            }
        }
    }
}
