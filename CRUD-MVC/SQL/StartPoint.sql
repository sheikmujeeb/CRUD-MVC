create table StartPoint
(
LocationID bigint not null Primary key identity(1,1),
Location nvarchar(50) not null,
)


------------------------Created Stored Procedure--------------------------------------------------------------
create procedure Pick
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
exec Pick Madurai
exec Pick Coimbatore
exec Pick Chennai
exec Pick Bangalore
exec Pick Trichy

select * from StartPoint

delete StartPoint
where 
Location
