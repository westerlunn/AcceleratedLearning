--Uppgift 6
select Title from Album
where Title like '_ar%'

--7.
select Title from Album
where Title like '[aeiouyåäö]%'

--8.
select Album.Title, Artist.Name
from Artist
inner join Album on Album.ArtistId = Artist.ArtistId

--10, dålig lösning
SELECT TOP 10 Album.ArtistId, 
COUNT(Album.ArtistId) AS NrOfAlbums 
FROM Album
INNER JOIN Artist ON Album.ArtistId = Artist.ArtistId
GROUP BY Album.ArtistId
ORDER BY NrOfAlbums DESC
--bra lösning
SELECT TOP 10 Artist.Name, 
COUNT(*) AS NrOfAlbums 
FROM Album
INNER JOIN Artist ON Album.ArtistId = Artist.ArtistId
GROUP BY Artist.Name
ORDER BY NrOfAlbums DESC

--11 start
select * from Track
Inner Join Genre ON Track.AlbumId = Genre.GenreId
where Genre.Name like 'Jazz' OR Genre.Name like 'Blues'
--11klar
select distinct Album.Title from Track
Inner Join Album ON Album.AlbumId = Track.AlbumId
Inner Join Genre ON Track.GenreId = Genre.GenreId
where Genre.Name like 'Jazz' OR Genre.Name like 'Blues'

--12
--alter tABLE	Track
--Add TrackNumber INT;

update Track
set TrackNumber = (Track.TrackId - 14) from Track
inner join Album ON Track.AlbumId = Album.AlbumId
where Album.Title = 'Let There Be Rock';

select Track.TrackNumber from Track 

--13
select Genre.Name, count(Genre.Name) as NumberOfAlbums
from Genre
join Track ON Track.GenreId = Genre.GenreId
Group by Genre.Name
having count(*) > 100
order by NumberOfAlbums desc;

--Checkpoint03
select Kyrkor.Namn, Byggnadsår, Städer.Namn AS StadID from Kyrkor
INNER JOIN Städer ON Städer.ID = Kyrkor.StadID

Select Personer.Namn, Kyrkor.Namn AS KyrkpreferensID, Kyrkor.Byggnadsår AS Byggår from Personer
INNER JOIN Kyrkor ON Kyrkor.ID = Personer.KyrkpreferensID

