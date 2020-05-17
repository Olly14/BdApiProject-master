--Insert into [dbo].[Products] Values (NEWID(), 'Strawberry Pie', 'Pie with sliced strawberries laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Apple Pie', 'Pie with sliced apples laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Plum Pie', 'Pie with sliced plum laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Pawpaw Pie', 'Pie with sliced Pawpaw laced with with yolk, honey and creme fresh sauce','false','false');

--Insert into [dbo].[Products] Values (NEWID(), 'Vigan Pie', 'Pie with sliced mixed vegs with with yolk, honey and creme fresh sauce','false','false');



--Insert into dbo.Prices Values (NEWID(), 'XXSmallType', 10.99);
--Insert into dbo.Prices Values (NEWID(), 'XSmallType', 20.99);
--Insert into dbo.Prices Values (NEWID(), 'SmallType', 35.99);
--Insert into dbo.Prices Values (NEWID(), 'XXMediumType', 55.99);
--Insert into dbo.Prices Values (NEWID(), 'XMediumType', 110.99);
--Insert into dbo.Prices Values (NEWID(), 'MediumType', 210.99);
--Insert into dbo.Prices Values (NEWID(), 'XXLargeType', 1500.99);
--Insert into dbo.Prices Values (NEWID(), 'XLargeType', 1000.99);
--Insert into dbo.Prices Values (NEWID(), 'LargeType', 500.99);

--Insert into dbo.Genders Values (NEWID(), 'Male');
--Insert into dbo.Genders Values (NEWID(), 'Female');

--Insert into [dbo].[AppUsers] Values (NEWID(), '7DABAAB9-C671-4905-AC4F-C5DD81E41D65', 'Johnny', '07898765432', '1 Love Avenue', 'Colchester', 'Essex','password','password', 'SS23 6TY','false','false');

select * from dbo.Products 

select * from dbo.Prices

select * from dbo.Genders

select * from dbo.AppUsers



select * from dbo.OrderProducts

select * from dbo.Orders

select * from dbo.OrderItems

select * from dbo.OrderProducts

select * from OrderHistories

select * from OrderItemHistories

--delete from dbo.Orders

--delete from dbo.OrderItems

--delete from OrderHistories

--delete from OrderItemHistories


--exec sp_rename 'OrderHistories', 'OrderHistories'