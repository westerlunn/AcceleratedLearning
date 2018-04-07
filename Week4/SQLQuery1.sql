--update Track
--set TrackNumber = (Track.TrackId - 14) from Track
--inner join Album ON Track.AlbumId = Album.AlbumId
--where Album.Title = 'Let There Be Rock';


select Track.TrackNumber from Track