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
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), (int)(displayHeight / 10.705263), displayWidth-(int)(displayWidth / 12.631578)*2, (int)(displayHeight / 203.4))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), (int)(displayWidth / 384), displayHeight-(int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect(displayWidth-(int)(displayWidth / 12.631578), (int)(displayHeight / 8.843478), (int)(displayWidth / 384), displayHeight - (int)(displayHeight / 4.730232))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/12.631578), displayHeight- (int)(displayHeight / 9.685714), displayWidth - (int)(displayWidth / 12.631578) * 2, (int)(displayHeight / 203.4))));
                //nappali és dínó
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.382134), (int)(displayHeight / 8.843478), (int)(displayWidth / 48), (int)(displayHeight / 6.871622))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.382134), (int)(displayHeight / 2.947826), (int)(displayWidth / 48), (int)(displayHeight / 3.301948))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.382134), (int)(displayHeight / 1.428371), (int)(displayWidth / 48), (int)(displayHeight / 5.65))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631578), (int)(displayHeight / 1.994118), (int)(displayWidth / 2.93578), (int)(displayHeight / 50.85))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 3.33913), (int)(displayHeight / 8.843478), (int)(displayWidth / 8.347826), (int)(displayHeight / 11.556818))));
                //előszoba és fürdő
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.084691), (int)(displayHeight / 1.196471), (int)(displayWidth / 48), (int)(displayHeight / 29.057143))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.084691), (int)(displayHeight / 2.001969), (int)(displayWidth / 48), (int)(displayHeight / 3.568421))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.997919), (int)(displayHeight / 2.001969), (int)(displayWidth / 3.847695), (int)(displayHeight / 50.85))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.997919), (int)(displayHeight / 1.469653), (int)(displayWidth / 24.935065), (int)(displayHeight / 9.970588))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.726619), (int)(displayHeight / 1.313953), (int)(displayWidth / 16.134454), (int)(displayHeight / 50.85))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.562246), (int)(displayHeight / 1.160959), (int)(displayWidth / 48), (int)(displayHeight / 50.85))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.562246), (int)(displayHeight / 1.564615), (int)(displayWidth / 48), (int)(displayHeight / 6.277778) + (int)(displayHeight / 50.85))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.513002), (int)(displayHeight / 1.564615), (int)(displayWidth / 3.84), (int)(displayHeight / 50.85))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.315068), (int)(displayHeight / 2.11875), (int)(displayWidth / 48), (int)(displayHeight / 6.78))));
                //hálószoba/konyha
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.315068), (int)(displayHeight / 2.930836), (int)(displayWidth / 48), (int)(displayHeight / 12.7125))));
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.28), (int)(displayHeight / 2.930836), (int)(displayWidth / 7.164179), (int)(displayHeight / 26.763158))));
                //tárgyak - nappali
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 9.846154), (int)(displayHeight / 5.811429), (int)(displayWidth / 29.538462), (int)(displayHeight / 19.557692)))); //zongora
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.387097), (int)(displayHeight / 2.905714), (int)(displayWidth / 12.8), (int)(displayHeight / 19.557692)))); //könyvespolc
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 9.142857), (int)(displayHeight / 2.409953), (int)(displayWidth / 42.666667), (int)(displayHeight / 40.68) - (int)(displayHeight / 101.7)))); //könyvolvasó
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.631579), (int)(displayHeight / 2.16383), (int)(displayWidth / 42.666667), (int)(displayHeight / 40.68)))); //rádió
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 3.33913) + (int)(displayWidth / 48), (int)(displayHeight / 2.947826)+ (int)(displayHeight / 108), (int)(displayWidth / 8.533333) - (int)(displayWidth / 25.6), (int)(displayHeight / 9.685714) - (int)(displayHeight / 21.6)))); //kanapé
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 3.33913), (int)(displayHeight / 2.947826)+ (int)(displayHeight / 30.857143), (int)(displayWidth / 8.533333)- (int)(displayWidth / 11.294118), (int)(displayHeight / 9.685714) - (int)(displayHeight / 36)))); //kanapé2
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth/2.577181), (int)(displayHeight / 2.311364) - (int)(displayHeight / 15.428571), (int)(displayWidth / 38.4), (int)(displayHeight / 21.6) + (int)(displayHeight / 27)))); //hangszer
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.782609), (int)(displayHeight / 4.52), (int)(displayWidth / 25.6), (int)(displayHeight / 50.85)))); //kandalló
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 5.454545), (int)(displayHeight / 10.705263), (int)(displayWidth / 32), (int)(displayHeight / 50.85)))); //ruhásszekrény
                //tárgyak - konyha
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.71889), (int)(displayHeight / 4.15102), (int)(displayWidth / 10.378378), (int)(displayHeight / 9.685714)))); //ebédlőasztal
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.676856), (int)(displayHeight / 2.26), (int)(displayWidth / 17.454545), (int)(displayHeight / 33.9)))); //telefonasztal
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.567347), (int)(displayHeight / 10.17), (int)(displayWidth / 17.454545), (int)(displayHeight / 50.85)))); //hűtő
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.4307), (int)(displayHeight / 8.475), (int)(displayWidth / 48), (int)(displayHeight / 18.490909)))); //konyhapult1
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.389291), (int)(displayHeight / 10.17), (int)(displayWidth / 5.565217), (int)(displayHeight / 50.85)))); //konyhapult2
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.111111), (int)(displayHeight / 8.475), (int)(displayWidth / 54.857143), (int)(displayHeight / 11.964706)))); //konyhapult3
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.136095), (int)(displayHeight / 3.447458), (int)(displayWidth / 29.538462), (int)(displayHeight / 33.9)))); //növény
                //tárgyak - hálószoba1
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.14082), (int)(displayHeight / 2.511111), (int)(displayWidth / 23.13253), (int)(displayHeight / 101.7)))); //ágy
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.132743), (int)(displayHeight / 1.648298), (int)(displayWidth / 32), (int)(displayHeight / 101.7)))); //könyvek
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.28), (int)(displayHeight / 1.695), (int)(displayWidth / 51.891892), (int)(displayHeight / 33.9)))); //sarok
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.248375), (int)(displayHeight / 1.614286), (int)(displayWidth / 51.891892), (int)(displayHeight / 101.7)))); //sarok2
                //tárgyak - hálószoba2
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.315068), (int)(displayHeight / 1.473913), (int)(displayWidth / 16.99115), (int)(displayHeight / 101.7)))); //ágy
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.219822), (int)(displayHeight / 1.51791), (int)(displayWidth / 25.6), (int)(displayHeight / 101.7)))); //éjjeliszekrény
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.1261), (int)(displayHeight / 1.368775), (int)(displayWidth / 42.666667), (int)(displayHeight / 50.85)))); //növény
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.185185), (int)(displayHeight / 1.232727), (int)(displayWidth / 13.913043), (int)(displayHeight / 36)))); //könyvessarok
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.185185)+ (int)(displayWidth / 60), (int)(displayHeight / 1.232727)+ (int)(displayHeight / 27), (int)(displayWidth / 13.913043)- (int)(displayWidth / 19.2), (int)(displayHeight / 36)- (int)(displayHeight / 54)))); //könyvessarok2
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.185185)+ (int)(displayWidth / 15.737705), (int)(displayHeight / 1.232727)+ (int)(displayHeight / 36), (int)(displayWidth / 13.913043)- (int)(displayHeight / 9), (int)(displayHeight / 36)+ (int)(displayHeight / 36)))); //könyvessarok3
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.23871), (int)(displayHeight / 1.151755), (int)(displayWidth / 42.666667), (int)(displayHeight / 33.9)))); //könyv
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.511811), (int)(displayHeight / 1.51791), (int)(displayWidth / 48), (int)(displayHeight / 67.8)))); //lámpa
                //tárgyak - fürdőszoba
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.92), (int)(displayHeight / 1.926136), (int)(displayWidth / 27.428571), (int)(displayHeight / 84.75)))); //wc
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.761468), (int)(displayHeight / 1.855839), (int)(displayWidth / 29.538462), (int)(displayHeight / 203.4)))); //mosógép
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.606695), (int)(displayHeight / 1.926136), (int)(displayWidth / 25.6), (int)(displayHeight / 84.75)))); //polc
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.465649), (int)(displayHeight / 1.926136), (int)(displayWidth / 25.6), (int)(displayHeight / 50.85)))); //kézmosó
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.648069), (int)(displayHeight / 1.564615), (int)(displayWidth / 38.4), (int)(displayHeight / 33.9)))); //tükör
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 1.665221), (int)(displayHeight / 1.432394), (int)(displayWidth / 25.263158), (int)(displayHeight / 101.7)))); //ülő
                //tárgyak - dínószoba
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 9.6), (int)(displayHeight / 1.849091), (int)(displayWidth / 27.428571), (int)(displayHeight / 40.68)))); //polc
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 5.565217), (int)(displayHeight / 1.849091), (int)(displayWidth / 11.428571), (int)(displayHeight / 25.425)))); //dínó1
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 3.622642), (int)(displayHeight / 1.849091), (int)(displayWidth / 15.737705), (int)(displayHeight / 203.4)))); //koponyák
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.782609), (int)(displayHeight / 1.918868), (int)(displayWidth / 16.695652), (int)(displayHeight / 50.85)))); //sarok
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 4.571429), (int)(displayHeight / 1.540909), (int)(displayWidth / 24), (int)(displayHeight / 18.490909)))); //betört téma
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 12.387097), (int)(displayHeight / 1.240244), (int)(displayWidth / 32), (int)(displayHeight / 25.425)))); //fotel
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 6.736842), (int)(displayHeight / 1.27125), (int)(displayWidth / 14.222222), (int)(displayHeight / 16.95)))); //dínó2
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 4.571429), (int)(displayHeight / 1.287342) + (int)(displayHeight / 101.7), (int)(displayWidth/48), (int)(displayHeight / 101.7)))); //farok
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 3.84), (int)(displayHeight / 1.255556), (int)(displayWidth / 17.454545), (int)(displayHeight / 29.057143)))); //dínó3
                //tárgyak - egyéb
                gg.Children.Add(new RectangleGeometry(new Rect((int)(displayWidth / 2.269504), (int)(displayHeight / 1.13), (int)(displayWidth / 25.6), (int)(displayHeight / 101.7)))); //ajtó
                return gg;
            }
        }
    }
}
