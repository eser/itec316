﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace toh
{
    public class Pole : PictureBox
    {
        public SortedList<int, Disk> Disks { get; set; }
        public int Number { get; set; }

        public Pole(int number)
        {
            Disks = new SortedList<int, Disk>();
            this.Number = number;
            this.Image = toh.Properties.Resources.pole;
            this.Size = toh.Properties.Resources.pole.Size;
            int XPosition = GameConstants.BaseStartPositionX + ((number + 1) * GameConstants.SpaceBetweenPoles);
            int YPosition = GameConstants.BaseStartPositionY + toh.Properties.Resources._base.Size.Height - this.Size.Height;
            this.Location = new Point(XPosition, YPosition);
        }

        public bool IsEmpty()
        {
            return Disks.Count == 0;
        }

        public bool AllowDisk(Disk disk)
        {
            if (disk == null)
            {
                return false;
            }
            if (Disks.Count == 0)
            {
                return true;
            }
            return GetTopDisk().Number > disk.Number;
        }

        public Disk GetTopDisk()
        {
            if (Disks.Count > 0)
            {
                return Disks.First().Value;
            }
            return null;
        }

        public void RemoveDisk()
        {
            Disks.Remove(Disks.First().Key);
        }

        public void AddDisk(Disk disk)
        {
            if (disk == null)
            {
                return;
            }
            if (AllowDisk(disk))
            {
                disk.MoveToPole(this);
                Disks.Add(disk.Number, disk);
            }
        }

        override public string ToString()
        {
            return Convert.ToString(Number);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Pole pole = obj as Pole;
            if ((System.Object)pole == null)
            {
                return false;
            }
            return pole.Number == Number;
        }
    }
}

