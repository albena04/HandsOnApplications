Create table StudentInfomations(
		StudentId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		StudentName varchar(50) NOT Null,
		Branch varchar(25) Not Null,
		StartDate DateTime Not Null,
		GraduatedDate DateTime Not Null,
		OverallPercentage float Not Null,
		EmailId Varchar(300)
		)

		drop table StudentInfomations

		select DATEADD(YEAR,4,getdate())
		select * from StudentInfomations

		Insert into StudentInfomations values('Barbie', 'ComputerScience', '1/1/2002','1/1/2006',76.09,'Barbie@gmail.com')
		
		Insert into StudentInfomations values('Mickey', 'Electronics', getdate(),DATEADD(YEAR,4,getdate()),79,'Mickey@gmail.com')
		
		Insert into StudentInfomations values('Minnie', 'Civil', getdate(),DATEADD(YEAR,4,getdate()),85,'Minnie@gmail.com')
		
		Insert into StudentInfomations values('Tom', 'Electronics', getdate(),DATEADD(YEAR,4,getdate()),88.43,'Tom@gmail.com')
		
		Insert into StudentInfomations values('Jerry', 'Electronics', getdate(),DATEADD(YEAR,4,getdate()),70.88,'Jerry@gmail.com')


		