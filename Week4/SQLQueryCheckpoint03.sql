--V3
Select Personer.Namn, Kyrkor.Namn AS KyrkpreferensID, Kyrkor.Byggnads�r AS Bygg�r from Personer
INNER JOIN Kyrkor ON Kyrkor.ID = Personer.KyrkpreferensID

--V2
--select Kyrkor.Namn, Byggnads�r, St�der.Namn AS StadID from Kyrkor
--INNER JOIN St�der ON St�der.ID = Kyrkor.StadID

