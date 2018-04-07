--V3
Select Personer.Namn, Kyrkor.Namn AS KyrkpreferensID, Kyrkor.Byggnadsår AS Byggår from Personer
INNER JOIN Kyrkor ON Kyrkor.ID = Personer.KyrkpreferensID

--V2
--select Kyrkor.Namn, Byggnadsår, Städer.Namn AS StadID from Kyrkor
--INNER JOIN Städer ON Städer.ID = Kyrkor.StadID

