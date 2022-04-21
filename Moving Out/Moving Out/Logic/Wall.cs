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
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), (int)(displayHeight / 8.843478), displayWidth-(int)(displayWidth / 12.631578)*2, 5)));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), 5, displayHeight-(int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect(displayWidth-(int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), 5, displayHeight - (int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), displayHeight- (int)(displayHeight / 9.685714), displayWidth - (int)(displayWidth / 12.631578) * 2, 5)));
                //nappali és dínó
                gg.Children.Add(new RectangleGeometry(new Rect(806, (int)(displayHeight / 8.843478), 40, 168)));
                gg.Children.Add(new RectangleGeometry(new Rect(806, 345, 40, 328)));
                gg.Children.Add(new RectangleGeometry(new Rect(806, 712, 40, 200)));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), 510, 654, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(575, (int)(displayHeight / 8.843478), 40, 108)));
                gg.Children.Add(new RectangleGeometry(new Rect(615, 183, 191, 40)));
                //előszoba és fürdő
                gg.Children.Add(new RectangleGeometry(new Rect(921, 850, 40, 55)));
                gg.Children.Add(new RectangleGeometry(new Rect(921, 508, 40, 305)));
                gg.Children.Add(new RectangleGeometry(new Rect(961, 508, 499, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(961, 692, 77, 122)));
                gg.Children.Add(new RectangleGeometry(new Rect(1112, 774, 119, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(1229, 876, 40, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(1229, 650, 40, 202)));
                gg.Children.Add(new RectangleGeometry(new Rect(1269, 650, 500, 40)));
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 480, 40, 170)));
                //hálószoba/konyha
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 347, 40, 100)));
                gg.Children.Add(new RectangleGeometry(new Rect(1500, 347, 268, 58)));
                //tárgyak - nappali
                gg.Children.Add(new RectangleGeometry(new Rect(195, 175, 65, 72))); //zongora
                gg.Children.Add(new RectangleGeometry(new Rect(155, 350, 150, 72))); //könyvespolc
                gg.Children.Add(new RectangleGeometry(new Rect(210, 422, 45, 45))); //könyvolvasó
                gg.Children.Add(new RectangleGeometry(new Rect(152, 470, 45, 45))); //rádió
                gg.Children.Add(new RectangleGeometry(new Rect(575, 345, 225, 125))); //kanapé
                gg.Children.Add(new RectangleGeometry(new Rect(745, 470, 50, 20))); //orgona
                gg.Children.Add(new RectangleGeometry(new Rect(690, 225, 75, 40))); //kandalló
                //tárgyak - konyha
                gg.Children.Add(new RectangleGeometry(new Rect(1117, 235, 185, 125))); //ebédlőasztal
                gg.Children.Add(new RectangleGeometry(new Rect(1145, 450, 110, 50))); //telefonasztal
                gg.Children.Add(new RectangleGeometry(new Rect(1225, 120, 110, 20))); //hűtő
                gg.Children.Add(new RectangleGeometry(new Rect(1342, 120, 40, 75))); //konyhapult1
                gg.Children.Add(new RectangleGeometry(new Rect(1382, 120, 345, 20))); //konyhapult2
                gg.Children.Add(new RectangleGeometry(new Rect(1728, 120, 35, 105))); //konyhapult3
                gg.Children.Add(new RectangleGeometry(new Rect(1690, 295, 65, 50))); //növény
                //tárgyak - hálószoba1
                gg.Children.Add(new RectangleGeometry(new Rect(1683, 405, 83, 30))); //ágy
                gg.Children.Add(new RectangleGeometry(new Rect(1695, 617, 60, 30))); //könyvek
                gg.Children.Add(new RectangleGeometry(new Rect(1500, 600, 75, 50))); //sarok
                //tárgyak - hálószoba2
                gg.Children.Add(new RectangleGeometry(new Rect(1460, 690, 113, 30))); //ágy
                gg.Children.Add(new RectangleGeometry(new Rect(1574, 690, 75, 10))); //éjjeliszekrény
                gg.Children.Add(new RectangleGeometry(new Rect(1705, 743, 45, 40))); //növény
                gg.Children.Add(new RectangleGeometry(new Rect(1550, 825, 218, 87))); //könyvessarok
                gg.Children.Add(new RectangleGeometry(new Rect(1270, 690, 40, 15))); //lámpa
                //tárgyak - fürdőszoba
                gg.Children.Add(new RectangleGeometry(new Rect(1000, 548, 70, 12))); //wc
                gg.Children.Add(new RectangleGeometry(new Rect(1090, 548, 65, 25))); //mosógép
                gg.Children.Add(new RectangleGeometry(new Rect(1195, 548, 75, 12))); //polc
                gg.Children.Add(new RectangleGeometry(new Rect(1310, 548, 75, 20))); //kézmosó
                gg.Children.Add(new RectangleGeometry(new Rect(1165, 650, 50, 50))); //tükör
                gg.Children.Add(new RectangleGeometry(new Rect(1153, 710, 76, 30))); //ülő
                //tárgyak - dínószoba
                gg.Children.Add(new RectangleGeometry(new Rect(200, 550, 70, 45))); //polc
                gg.Children.Add(new RectangleGeometry(new Rect(345, 550, 168, 60))); //dínó1
                gg.Children.Add(new RectangleGeometry(new Rect(530, 550, 122, 25))); //koponyák
                gg.Children.Add(new RectangleGeometry(new Rect(690, 550, 115, 20))); //sarok
                gg.Children.Add(new RectangleGeometry(new Rect(420, 660, 80, 75))); //betört téma
                gg.Children.Add(new RectangleGeometry(new Rect(155, 820, 60, 60))); //fotel
                gg.Children.Add(new RectangleGeometry(new Rect(285, 800, 135, 80))); //dínó2
                gg.Children.Add(new RectangleGeometry(new Rect(420, 810, 40, 20))); //farok
                gg.Children.Add(new RectangleGeometry(new Rect(500, 810, 110, 55))); //dínó3
                //tárgyak - egyéb
                gg.Children.Add(new RectangleGeometry(new Rect(846, 900, 75, 10))); //ajtó
                return gg;
            }
        }
    }
}
