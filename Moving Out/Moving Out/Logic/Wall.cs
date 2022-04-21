using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Moving_Out.Logic
{
    public class Wall : GameItem
    {
        private int displayWidth;
        private int displayHeight;

        public Wall(int displayWidth, int displayHeight)
        {
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
        }

        public override Geometry Area
        {
            get
            {
                GeometryGroup gg = new GeometryGroup();
                //főfal
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), (int)(displayHeight / 8.843478)-20, displayWidth-(int)(displayWidth / 12.631578)*2, 5)));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), 5, displayHeight-(int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect(displayWidth-(int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), 5, displayHeight - (int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), displayHeight- (int)(displayHeight / 9.685714), displayWidth - (int)(displayWidth / 12.631578) * 2, 5)));
                //nappali és dínó
                gg.Children.Add(new RectangleGeometry(new Rect(806, (int)(displayHeight / 8.843478), 40, 148)));
                gg.Children.Add(new RectangleGeometry(new Rect(806, 345, 40, 308)));
                gg.Children.Add(new RectangleGeometry(new Rect(806, 712, 40, 180)));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), 510, 654, 20)));
                gg.Children.Add(new RectangleGeometry(new Rect(575, (int)(displayHeight / 8.843478), 40, 88)));
                gg.Children.Add(new RectangleGeometry(new Rect(615, 183, 191, 20)));
                //előszoba és fürdő
                gg.Children.Add(new RectangleGeometry(new Rect(921, 850, 40, 35)));
                gg.Children.Add(new RectangleGeometry(new Rect(921, 508, 40, 285)));
                gg.Children.Add(new RectangleGeometry(new Rect(961, 508, 499, 20)));
                gg.Children.Add(new RectangleGeometry(new Rect(961, 692, 77, 102)));
                gg.Children.Add(new RectangleGeometry(new Rect(1112, 774, 119, 20)));
                gg.Children.Add(new RectangleGeometry(new Rect(1229, 876, 40, 20)));
                gg.Children.Add(new RectangleGeometry(new Rect(1229, 650, 40, 162)));
                gg.Children.Add(new RectangleGeometry(new Rect(1269, 650, 500, 20)));
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 480, 40, 150)));
                //hálószoba/konyha
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 347, 40, 80)));
                gg.Children.Add(new RectangleGeometry(new Rect(1500, 347, 268, 38)));
                //tárgyak - nappali
                gg.Children.Add(new RectangleGeometry(new Rect(195, 175, 65, 52))); //zongora
                gg.Children.Add(new RectangleGeometry(new Rect(155, 350, 150, 52))); //könyvespolc
                gg.Children.Add(new RectangleGeometry(new Rect(210, 422, 45, 25))); //könyvolvasó
                gg.Children.Add(new RectangleGeometry(new Rect(152, 470, 45, 25))); //rádió
                gg.Children.Add(new RectangleGeometry(new Rect(575, 345, 225, 105))); //kanapé
                //gg.Children.Add(new RectangleGeometry(new Rect(745, 470, 50, 20))); //orgona
                gg.Children.Add(new RectangleGeometry(new Rect(690, 225, 75, 20))); //kandalló
                gg.Children.Add(new RectangleGeometry(new Rect(352, 95, 60, 20))); //ruhásszekrény
                //tárgyak - konyha
                gg.Children.Add(new RectangleGeometry(new Rect(1117, 245, 185, 105))); //ebédlőasztal
                gg.Children.Add(new RectangleGeometry(new Rect(1145, 450, 110, 30))); //telefonasztal
                gg.Children.Add(new RectangleGeometry(new Rect(1225, 100, 110, 20))); //hűtő
                gg.Children.Add(new RectangleGeometry(new Rect(1342, 120, 40, 55))); //konyhapult1
                gg.Children.Add(new RectangleGeometry(new Rect(1382, 100, 345, 20))); //konyhapult2
                gg.Children.Add(new RectangleGeometry(new Rect(1728, 120, 35, 85))); //konyhapult3
                gg.Children.Add(new RectangleGeometry(new Rect(1690, 295, 65, 30))); //növény
                //tárgyak - hálószoba1
                gg.Children.Add(new RectangleGeometry(new Rect(1683, 405, 83, 10))); //ágy
                gg.Children.Add(new RectangleGeometry(new Rect(1695, 617, 60, 10))); //könyvek
                gg.Children.Add(new RectangleGeometry(new Rect(1500, 600, 75, 30))); //sarok
                //tárgyak - hálószoba2
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 690, 113, 10))); //ágy
                gg.Children.Add(new RectangleGeometry(new Rect(1574, 670, 75, 10))); //éjjeliszekrény
                gg.Children.Add(new RectangleGeometry(new Rect(1705, 743, 45, 20))); //növény
                gg.Children.Add(new RectangleGeometry(new Rect(1620, 825, 138, 47))); //könyvessarok
                gg.Children.Add(new RectangleGeometry(new Rect(1550, 883, 45, 30))); //könyv
                gg.Children.Add(new RectangleGeometry(new Rect(1270, 670, 40, 15))); //lámpa
                //tárgyak - fürdőszoba
                gg.Children.Add(new RectangleGeometry(new Rect(1000, 528, 70, 12))); //wc
                gg.Children.Add(new RectangleGeometry(new Rect(1090, 548, 65, 5))); //mosógép
                gg.Children.Add(new RectangleGeometry(new Rect(1195, 528, 75, 12))); //polc
                gg.Children.Add(new RectangleGeometry(new Rect(1310, 528, 75, 20))); //kézmosó
                gg.Children.Add(new RectangleGeometry(new Rect(1165, 650, 50, 30))); //tükör
                gg.Children.Add(new RectangleGeometry(new Rect(1153, 710, 76, 10))); //ülő
                //tárgyak - dínószoba
                gg.Children.Add(new RectangleGeometry(new Rect(200, 550, 70, 25))); //polc
                gg.Children.Add(new RectangleGeometry(new Rect(345, 550, 168, 40))); //dínó1
                gg.Children.Add(new RectangleGeometry(new Rect(530, 550, 122, 5))); //koponyák
                gg.Children.Add(new RectangleGeometry(new Rect(690, 530, 115, 20))); //sarok
                gg.Children.Add(new RectangleGeometry(new Rect(420, 660, 80, 55))); //betört téma
                gg.Children.Add(new RectangleGeometry(new Rect(155, 820, 60, 40))); //fotel
                gg.Children.Add(new RectangleGeometry(new Rect(285, 800, 135, 60))); //dínó2
                gg.Children.Add(new RectangleGeometry(new Rect(420, 790, 40, 20))); //farok
                gg.Children.Add(new RectangleGeometry(new Rect(500, 810, 110, 35))); //dínó3
                //tárgyak - egyéb
                gg.Children.Add(new RectangleGeometry(new Rect(846, 900, 75, 10))); //ajtó
                return gg;
            }
        }
    }
}
