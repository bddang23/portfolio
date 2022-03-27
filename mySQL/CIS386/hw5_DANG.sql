DROP DATABASE hw5_Dang;
CREATE DATABASE hw5_Dang;
USE hw5_Dang;
CREATE TABLE Patient (
			PatientNum	INT	PRIMARY KEY UNIQUE NOT NULL,
            LastName	VARCHAR(255) NOT NULL,
            FirstName	VARCHAR(255) NOT NULL,
            Address		VARCHAR(255),
            City		VARCHAR(255),
            State		VARCHAR(255),
            ZipCode		INT(8),
            Balance		DECIMAL(9,2) NOT NULL);
CREATE TABLE Therapist (
			TherapistID	VARCHAR(10) PRIMARY KEY UNIQUE NOT NULL,
            LastName	VARCHAR(255) NOT NULL,
            FirstName	VARCHAR(255) NOT NULL,
            Street		VARCHAR(255),
            City		VARCHAR(255),
            State		VARCHAR(255),
            ZipCode		INT(8));
CREATE TABLE Therapies(
			TherapyCode INT PRIMARY KEY UNIQUE NOT NULL,
            Dscription VARCHAR(255) NOT NULL,
            UnitTime INT);
CREATE TABLE Sessions (
			SessionNum	 INT PRIMARY KEY UNIQUE NOT NULL,
            Session_Date DATE NOT NULL,
            PatientNum 	 INT NOT NULL,
            LengthOfSession INT,
            TherapistID VARCHAR(255) NOT NULL,
            TherapyCode INT NOT NULL,
            FOREIGN KEY(PatientNum) REFERENCES Patient(PatientNum) ON UPDATE CASCADE ON DELETE CASCADE,
            FOREIGN KEY(TherapistID) REFERENCES Therapist(TherapistID) ON UPDATE CASCADE ON DELETE CASCADE,
            FOREIGN KEY(TherapyCode) REFERENCES Therapies(TherapyCode) ON UPDATE CASCADE ON DELETE CASCADE);

INSERT INTO Patient VALUES
('1010','Koehler','Robbie','119 West Bay Dr.','San Vista','TX','72510',1535.15),
('1011','King','Joseph','941 Treemont','Oak Hills','TX','74081',212.80),
('1012','Houghland','Susan','7841 Lake Side Dr.','Munster','TX','72380',1955.40),
('1013','Falls','Tierra','44 Applewood Ave.','Palm Rivers','TX','72511',1000.35),
('1014','Odepaul','Ben','546 WCR 150 South','Munster','TX','74093',525.00),
('1015','Venable','Isaiah','37 High School Road','Waterville','TX','74183',432.30),
('1016','Waggoner','Brianna','2691 Westgrove St.','Delbert','TX','72381',714.25),
('1017','Short','Tobey','1928 10th Ave.','Munster','TX','72512',967.60),
('1018','Baptist','Joseph','300 Erin Dr.','Waterville','TX','76658',1846.75),
('1019','Culling','Latisha','4238 East 71st St.','San Vista','TX','74071',1988.50),
('1020','Marino','Andre','919 Horton Ave.','Georgetown','TX','72379',688.95),
('1021','Wilson','Tammy','424 October Blvd.','Waterville','TX','76658',2015.30);

INSERT INTO Therapies VALUES
(90901,'Biofeedback training by any modality',NULL),
(92240,'Shoulder strapping',NULL),
(92507,'Treatment of speech',15),
(92530,'Knee strapping',NULL),
(92540,'Ankle and/or foot strapping',NULL),
(95831,'Extremity or trunk muscle testing',NULL),
(97010,'Hot or cold pack application',NULL),
(97012,'Mechanical traction',NULL),
(97014,'Electrical stimulation',NULL),
(97016,'Vasopneumatic devices',NULL),
(97018,'Paraffin bath',NULL),
(97022,'Whirlpool',NULL),
(97026,'Infrared',NULL),
(97032,'Electrical stimulation',15),
(97033,'Iontophoresis ',15),
(97035,'Ultrasound',15),
(97039,'Unlisted modality',15),
(97110,'Therapeutic exercises to develop strength and endurance, range of motion, and flexibility',15),
(97112,'Neuromuscular re-education of movement, balance, coordination, etc.',15),
(97113,'Aquatic therapy with therapeutic exercises',15),
(97116,'Gait training',15),
(97124,'Massage',15),
(97139,'Unlisted therapeutic procedure',NULL),
(97140,'Manual therapy techniques',15),
(97150,'Group therapeutic procedure',15),
(97530,'Dynamic activities to improve functional performance, direct (one-on-one) with the patient',15),
(97535,'Self-care/home management training',15),
(97750,'Physical performance test or measurement',15),
(97799,'Unlisted physical medicine/rehabilitation service or procedure',NULL),
(98941,'CMT of the spine',NULL),
(98960,'Education and training for patient self-management',30);

INSERT INTO Therapist VALUES
('AS648','Shields','Anthony','5222 Eagle Court','Palm Rivers','TX','72511'),
('BM273','McClain','Bridgette','385 West Mill St.','Waterville','TX','76658'),
('JR085','Risk','Jonathan','1010 650 North','Palm Rivers','TX','72511'),
('SN852','Nair','Saritha','25 North Elm St.','Livewood','TX','72512'),
('SW124','Wilder','Steven','7354 Rockville Road','San Vista','TX','72510');
INSERT INTO Sessions VALUES
(27,'2018-10-10','1011',45,'JR085',92507),
(28,'2018-10-11','1016',30,'AS648',97010),
(29,'2018-10-11','1014',60,'SW124',97014),
(30,'2018-10-12','1013',30,'BM273',97033),
(31,'2018-10-15','1016',90,'AS648',98960),
(32,'2018-10-16','1018',15,'JR085',97035),
(33,'2018-10-17','1017',60,'SN852',97039),
(34,'2018-10-17','1015',45,'BM273',97112),
(35,'2018-10-18','1010',30,'SW124',97113),
(36,'2018-10-18','1019',75,'SN852',97116),
(37,'2018-10-19','1020',30,'BM273',97124),
(38,'2018-10-19','1021',60,'AS648',97535);


CREATE VIEW HighBalancePatients AS 
	SELECT PatientNum, CONCAT(FirstName,' ',LastName) AS PatientName,Balance
    FROM Patient
    WHERE Balance > 1000;
    
CREATE VIEW LowBalancePatients AS 
	SELECT PatientNum, CONCAT(FirstName,' ',LastName) AS PatientName,Balance
    FROM Patient
    WHERE Balance > (SELECT AVG(Balance) FROM Patient);

SELECT PatientNum, COUNT(PatientNum) AS TherapyCount
FROM Sessions
GROUP BY PatientNum
HAVING TherapyCount > 1;

SELECT SessionNum, Session_Date
FROM Sessions
WHERE Session_Date > '2018-10-15';

SELECT TherapistID, SUM(LengthOfSession) As TotalTime
FROM Sessions
GROUP BY TherapistID
ORDER BY TotalTime DESC; 