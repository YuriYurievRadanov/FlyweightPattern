﻿using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    class Program
    {
        enum SoldierType
        {
            Private,
            Sergeant
        }

        // FlyWeight Class
        abstract class Soldier
        {
            #region Intrinsic Fields

            protected string UnitName;
            protected string Guns;
            protected string Health;

            #endregion

            #region Extrinsic Fields

            protected int X;
            protected int Y;

            #endregion

            public abstract void MoveTo(int x, int y);
        }

        // Concrete FlyWeight
        class Private
            : Soldier
        {
            public Private()
            {
                UnitName = "SWAT";
                Guns = "Machine Gun";
                Health = "Good";
            }
            public override void MoveTo(int x, int y)
            {
                X = x;
                Y = y;
                Console.WriteLine("Er ({0}:{1}) noktasına hareket etti", X, Y);
            }
        }

        // Concrete FlyWeight
        class Sergeant
            : Soldier
        {
            public Sergeant()
            {
                UnitName = "SWAT";
                Guns = "Sword";
                Health = "Good";
            }
            public override void MoveTo(int x, int y)
            {
                X = x;
                Y = y;
                Console.WriteLine("Çavuş ({0}:{1}) noktasına hareket etti", X, Y);
            }
        }

        // FlyWeight Factory
        class SoldierFactory
        {
            private Dictionary<SoldierType, Soldier> _soldiers;

            public SoldierFactory()
            {
                _soldiers = new Dictionary<SoldierType, Soldier>();
            }

            public Soldier GetSoldier(SoldierType sType)
            {
                Soldier soldier = null;

                if (_soldiers.ContainsKey(sType))
                    soldier = _soldiers[sType];
                else
                {
                    if (sType == SoldierType.Private)
                        soldier = new Private();
                    else if (sType == SoldierType.Sergeant)
                        soldier = new Sergeant();
                    _soldiers.Add(sType, soldier);
                }

                return soldier;
            }
        }


        static void Main(string[] args)
        {
            SoldierType[] soldiers = { SoldierType.Private, SoldierType.Private, SoldierType.Sergeant, SoldierType.Private, SoldierType.Sergeant };

            SoldierFactory factory = new SoldierFactory();

            int localtionX = 10;
            int locationY = 10;

            foreach (SoldierType soldier in soldiers)
            {
                localtionX += 10;
                locationY += 5;
                Soldier sld = factory.GetSoldier(soldier);
                sld.MoveTo(localtionX, locationY);
            }
        }
    }
}
