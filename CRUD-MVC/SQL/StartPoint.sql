create table StartPoint
(
LocationID bigint not null Primary key identity(1,1),
Location nvarchar(50) unique,
)


------------------------Created Stored Procedure--------------------------------------------------------------
create procedure Pickup
(
@Location nvarchar(50)
)
as begin
insert into [dbo].[StartPoint]([Location])
values(
@Location
)
end


------------------Adding Records-------------------------------------------------------------------------
exec Pickup Madurai
exec Pickup Coimbatore
exec Pickup Chennai
exec Pickup Bangalore
exec Pickup Trichy

select * from StartPoint


