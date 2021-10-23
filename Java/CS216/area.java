public class area {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		System.out.println("Area of the Square is " + area(5.0));
		System.out.println("Area of the Rectangle is " + area(9.0,8.0));
		System.out.println("Area of the Triangle is " + area(10.0,7.0,6.0));
		 
		
	}
	public static double area(double side) {
		double SquareArea = side*side;
		return SquareArea;
	}
	public static double area(double length, double width) {
		double RectangleArea = length*width;
		return RectangleArea;
	}
	public static double area(double a, double b, double c ) {
		double s = (a + b + c)/2 ; //Half Perimeter
		double TriangleArea = Math.sqrt(s*(s-a)*(s-b)*(s-c));
		return TriangleArea;
	}


}
