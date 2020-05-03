USE [BerrasBioDb]
GO

INSERT INTO [dbo].[Auditoria]([Name],[AvailableSeats])VALUES('Hitchcock',50)
INSERT INTO [dbo].[Auditoria]([Name],[AvailableSeats])VALUES('Scorsese',100)
                                           
GO

INSERT INTO [dbo].[Movies] VALUES
           ('Psycho',
           'https://www.imdb.com/title/tt0054215/?ref_=nm_knf_i1',
		   'https://m.media-amazon.com/images/M/MV5BNTQwNDM1YzItNDAxZC00NWY2LTk0M2UtNDIwNWI5OGUyNWUxXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,672,1000_AL_.jpg')

		   INSERT INTO [dbo].[Movies] VALUES
           ('Vertigo',
           'https://www.imdb.com/title/tt0052357/?ref_=nm_knf_i2',
		   'https://m.media-amazon.com/images/M/MV5BYTE4ODEwZDUtNDFjOC00NjAxLWEzYTQtYTI1NGVmZmFlNjdiL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SY1000_CR0,0,645,1000_AL_.jpg')

		   INSERT INTO [dbo].[Movies] VALUES
           ('Taxi Driver',
           'https://www.imdb.com/title/tt0075314/?ref_=nm_knf_i1',
		   'https://m.media-amazon.com/images/M/MV5BM2M1MmVhNDgtNmI0YS00ZDNmLTkyNjctNTJiYTQ2N2NmYzc2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,658,1000_AL_.jpg')

		   INSERT INTO [dbo].[Movies] VALUES
           ('Goodfellas',
           'https://www.imdb.com/title/tt0099685/?ref_=nm_knf_i3',
		   'https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX667_CR0,0,667,999_AL_.jpg')

		   INSERT INTO [dbo].[Movies] VALUES
           ('Reservoir Dogs',
           'https://www.imdb.com/title/tt0105236/?ref_=nm_knf_i1',
		   'https://m.media-amazon.com/images/M/MV5BZmExNmEwYWItYmQzOS00YjA5LTk2MjktZjEyZDE1Y2QxNjA1XkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg')

		   INSERT INTO [dbo].[Movies] VALUES
           ('Pulp Fiction',
           'https://www.imdb.com/title/tt0054215/?ref_=nm_knf_i1',
		   'https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,686,1000_AL_.jpg')

		   INSERT INTO [dbo].[Movies] VALUES
           ('Inception',
           'https://www.imdb.com/title/tt1375666/?ref_=nm_knf_i4',
		   'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg')

		   INSERT INTO [dbo].[Movies] VALUES
           ('Interstellar',
           'https://www.imdb.com/title/tt0816692/?ref_=nm_knf_i1',
		   'https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_SX675_AL_.jpg')

GO

DECLARE @date1 DATETIME = '2020-04-20 18:00'
DECLARE @date2 DATETIME = '2020-04-20 20:00'
DECLARE @date3 DATETIME = '2020-04-21 18:00'
DECLARE @date4 DATETIME = '2020-04-21 20:00'
DECLARE @date5 DATETIME = '2020-04-22 18:00'
DECLARE @date6 DATETIME = '2020-04-22 20:00'
DECLARE @date7 DATETIME = '2020-04-23 18:00'
DECLARE @date8 DATETIME = '2020-04-23 20:00'


INSERT INTO [dbo].[Showings]VALUES(@date1,1,1,25)
INSERT INTO [dbo].[Showings]VALUES(@date2,2,2,76)
INSERT INTO [dbo].[Showings]VALUES(@date3,3,1,47)
INSERT INTO [dbo].[Showings]VALUES(@date4,4,2,98)
INSERT INTO [dbo].[Showings]VALUES(@date5,5,1,50)
INSERT INTO [dbo].[Showings]VALUES(@date6,6,2,64)
INSERT INTO [dbo].[Showings]VALUES(@date7,7,1,12)
INSERT INTO [dbo].[Showings]VALUES(@date8,8,2,100)

GO