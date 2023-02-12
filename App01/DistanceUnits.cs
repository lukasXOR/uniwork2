// conversion units taken from google and uniconverters.net
namespace ConsoleAppProject.App01 { 
    public class DistanceUnits {
        static double MILE_FEET = 5280;
        static double MILE_METER = 1609.34;
        static double MILE_YARD = 1760;
        static double MILE_INCH = 63360;
        static double MILE_CENTIMETER = 160900;
        
        static double FEET_METER = 3.281;
        static double FEET_YARD = 3;
        static double FEET_INCH = 12;
        static double FEET_CENTIMETER = 30.48;

        static double METRE_YARD = 1.094;
        static double METRE_INCH = 39.37;
        static double METRE_CENTIMETER = 100;

        static double YARD_INCH = 36;
        static double YARD_CENTIMETER = 91.44;

        static double INCH_CENTIMETER = 2.54;

        public static double miles_feet(double a) {return a * MILE_FEET;}
        public static double miles_metre(double a) {return a * MILE_METER;}
        public static double miles_yard(double a) {return a * MILE_YARD;}
        public static double miles_inch(double a) {return a * MILE_INCH;}
        public static double miles_centimeter(double a) {return a * MILE_CENTIMETER;}

        public static double feet_mile(double a) {return a / MILE_FEET;}
        public static double feet_metre(double a) {return a / FEET_METER;}
        public static double feet_yard(double a) {return a / FEET_YARD;}
        public static double feet_inch(double a) {return a * FEET_INCH;}
        public static double feet_centimeter(double a) {return a * FEET_CENTIMETER;}

        public static double metre_mile(double a) {return a / MILE_METER;}
        public static double metre_feet(double a) {return a * FEET_METER;}
        public static double metre_yard(double a) {return a * METRE_YARD;}
        public static double metre_inch(double a) {return a * METRE_INCH;}
        public static double metre_centimeter(double a) {return a * METRE_CENTIMETER;}

        public static double yard_feet(double a) {return a * FEET_YARD;}
        public static double yard_metres(double a) {return a / METRE_YARD;}
        public static double yard_mile(double a) {return a / MILE_YARD;}
        public static double yard_inch(double a) {return a * YARD_INCH;}
        public static double yard_centimeter(double a) {return a * YARD_CENTIMETER;}

        public static double inch_feet(double a) {return a * FEET_INCH;}
        public static double inch_metres(double a) {return a / METRE_INCH;}
        public static double inch_yard(double a) {return a / YARD_INCH;}
        public static double inch_mile(double a) {return a / MILE_INCH;}
        public static double inch_centimeter(double a) {return a * INCH_CENTIMETER;}

        public static double centimetre_mile(double a) {return a / MILE_CENTIMETER;}
        public static double centimetre_feet(double a) {return a / FEET_CENTIMETER;}
        public static double centimetre_metres(double a) {return a / METRE_CENTIMETER;}
        public static double centimetre_yard(double a) {return a / YARD_CENTIMETER;}
        public static double centimetre_inch(double a) {return a / INCH_CENTIMETER;}
    }
}
