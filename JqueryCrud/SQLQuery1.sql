Create database JqueryCrud
Use JqueryCrud

Create table tblEmployee(
    EmpId int primary key identity(1,1),
    EmpName varchar(30),
    EmpAddress varchar(30),
    EmpAge int
)

/* Stored Procedure for  Insert Data into tblEmployee*/
create proc sp_tblEmployee_Insert
@EmpName varchar(30),
@EmpAge int,
@EmpAddress varchar(40)
as
begin
insert into tblEmployee(EmpName,EmpAge,EmpAddress) 
values(@EmpName,@EmpAge,@EmpAddress)
end
 
/* Stored Procedure for  Edit record */
create proc sp_tblEmployee_Edit
@EmpId int
as
begin
select * from tblEmployee where EmpId=@EmpId
end
/* Stored Procedure for  Update Record */
create proc sp_tblEmployee_Update
@EmpId int,
@EmpName varchar(40),
@EmpAge int,
@EmpAddress varchar(30)
as
begin
update tblEmployee set EmpName=@EmpName, EmpAge=@EmpAge,EmpAddress=@EmpAddress where EmpId=@EmpId
end
/* Stored Procedure for  Delete Data from tblEmployee*/
create proc sp_tblEmployee_Delete
@EmpId int
as
begin
Delete from tblEmployee where EmpId=@EmpId
end
 
/* Stored Procedure for  Retrieve Data from tblEmployee*/
 
create proc sp_tblEmployee_Select
as
begin
select * from tblEmployee
end

select * from tblEmployee