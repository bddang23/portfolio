 /*CW0   
 * @author  Binh Dang
 * @version 1.0
 * @since   2020-03-14
 */
import java.util.*;
public class CW0_Dang {
		public static void main(String[] args) {
			// TODO Auto-generated method stub
			Scanner s = new Scanner(System.in);
			//scan for input then flush the first line to ready for the second line
			int n = s.nextInt();
			s.nextLine();

			//while loop to check if n is bigger than 0 else stop
			while (n!=0 && n>0) {
				appointment[] list = new appointment[n]; //array list that contain appointment object with amount of n
				int am=0;
				int pm=0;
				//Program will run if n is bigger than 1 and less than 100
				if (n>=1 && n <=100) {
					//for loop to add the obj appointment to the array
					//also keep track if it's in am or pm
					for (int i = 0;i<n;i++) {
						String time = s.nextLine();
						appointment a = new appointment(time);
						if (a.day.equals("a.m."))
							am++;
						else
							pm++;
						list[i]=a;
					}
					//create 2 new array - one keep track the morning and one keep trach the afternoon
					appointment[] amlist = new appointment[am];					
					appointment[] pmlist = new appointment[pm];
					
					//call sort function to sort the time then print out
					sort(amlist,pmlist,list,n);
				}
				
				//Check the next input for the next list
				n = s.nextInt();
				s.nextLine();
			}
		}
		
		//sort function include deviding the big list to 2 small list am and pm
		//Then sort each of them individually
		//then later print it out
		public static void sort(appointment[] amlist, appointment[] pmlist,appointment[] list,int n) {
			timeOfDaySort(amlist,pmlist,list,n);
			timeSort(amlist);
			timeSort(pmlist);
			printObj(amlist);
			printObj(pmlist);
			System.out.println();
		};
		
		//This function divide a big list to 2 smaller list call am and pm
		public static void timeOfDaySort (appointment[] amlist, appointment[] pmlist,appointment[] list,int n) {
			//two counter to keep track where should we add the appointment time in
			int ctrAM=0;
			int ctrPM=0;
			for (int i = 0;i<n;i++) {
				if (list[i].day.equals("a.m.")) {
					amlist[ctrAM] = list[i];
					ctrAM++;
				}
				else {
					pmlist[ctrPM] = list[i];
					ctrPM++;
				}	
			}			
		}
		
		//This function sort time and put it to the array 
		public static void timeSort(appointment[] list) {
			for (int i=0;i<list.length-1;i++) {
				for (int j=0;j<list.length-1-i;j++) {
					if (list[j].hour > list[j+1].hour ) {
						int hour = list[j].hour;
						int minute = list[j].minute;
						
						int hour1 = list[j+1].hour;
						int minute1 = list[j+1].minute;
						
						list[j].hour = hour1;
						list[j].minute=minute1;
						list[j+1].hour = hour;
						list[j+1].minute=minute;
					}
					else if (list[j].hour == list[j+1].hour) {
						if (list[j].minute > list[j+1].minute) {
							int minute = list[j].minute;
							int minute1 = list[j+1].minute;

							list[j].minute=minute1;
							list[j+1].minute=minute;
						}
					}
				}
			}
		}

		//This function use the obj array list then later print it out to the console
		public static void printObj(appointment[] list) {
			for (int i=0; i<list.length;i++) {
				if (list[i].hour == 0)
					list[i].hour =12;
				System.out.print(list[i].hour +":");
				//if the minute is less than 10 then add 0 in the minute part then print out the am and pm symbol
				if (list[i].minute <10)
					System.out.print("0" + list[i].minute  +" " + list[i].day);
				else
					System.out.print(list[i].minute +" " + list[i].day);
				
				System.out.println();
			}
		}
	}

//class for appointment object with hour, minute, and day parameter
	class appointment{
		int hour;
		int minute;
		String day;
		public appointment(String time) {
			 int colon = time.indexOf(':');
			 hour = Integer.parseInt(time.substring(0, colon));
			 if (hour==12) {
				 hour =0;
			 }
			 minute = Integer.parseInt(time.substring(colon+1,colon+3));
			 int space = time.indexOf(' ');
			 day = time.substring(space+1,space+5);
		}
	}

