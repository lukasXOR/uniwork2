// conversion units taken from google and uniconverters.net
namespace ConsoleAppProject.App01 { 
    public class DistanceUnits {
        static double MILE_FEET = 5280;
        static double MILE_METER = 1609.34;
        static double MILE_YARD = 1760;
        static double MILE_INCH = 63360;
        static double MILE_CENTIMETRES = 160900;

        static double FEET_METER = 3.281;
        static double FEET_YARD = 3;
        static double FEET_INCH = 12;
        static double FEET_CENTIMETRES = 30.48;

        static double METRE_YARD = 1.094;
        static double METRE_INCH = 39.37;
        static double METRE_CENTIMETRES = 100;

        static double YARD_INCH = 36;
        static double YARD_CENTIMETRES = 91.44;

        static double INCH_CENTIMETRES = 2.54;

        public static double miles_feet(double a) {return a * MILE_FEET;}
        public static double miles_metres(double a) {return a * MILE_METER;}
        public static double miles_yards(double a) {return a * MILE_YARD;}
        public static double miles_inches(double a) {return a * MILE_INCH;}
        public static double miles_centimetres(double a) {return a * MILE_CENTIMETRES;}

        public static double feet_miles(double a) {return a / MILE_FEET;}
        public static double feet_metres(double a) {return a / FEET_METER;}
        public static double feet_yards(double a) {return a / FEET_YARD;}
        public static double feet_inches(double a) {return a * FEET_INCH;}
        public static double feet_centimetres(double a) {return a * FEET_CENTIMETRES;}

        public static double metres_miles(double a) {return a / MILE_METER;}
        public static double metres_feet(double a) {return a * FEET_METER;}
        public static double metres_yards(double a) {return a * METRE_YARD;}
        public static double metres_inches(double a) {return a * METRE_INCH;}
        public static double metres_centimetres(double a) {return a * METRE_CENTIMETRES;}

        public static double yards_feet(double a) {return a * FEET_YARD;}
        public static double yards_metres(double a) {return a / METRE_YARD;}
        public static double yards_miles(double a) {return a / MILE_YARD;}
        public static double yards_inches(double a) {return a * YARD_INCH;}
        public static double yards_centimetres(double a) {return a * YARD_CENTIMETRES;}

        public static double inches_feet(double a) {return a * FEET_INCH;}
        public static double inches_metres(double a) {return a / METRE_INCH;}
        public static double inches_yards(double a) {return a / YARD_INCH;}
        public static double inches_miles(double a) {return a / MILE_INCH;}
        public static double inches_centimetres(double a) {return a * INCH_CENTIMETRES;}

        public static double centimetres_miles(double a) {return a / MILE_CENTIMETRES;}
        public static double centimetres_feet(double a) {return a / FEET_CENTIMETRES;}
        public static double centimetres_metres(double a) {return a / METRE_CENTIMETRES;}
        public static double centimetres_yards(double a) {return a / YARD_CENTIMETRES;}
        public static double centimetres_inches(double a) {return a / INCH_CENTIMETRES;}
    }
}
