use swati
go

create login [Administrador] with password = '123456' ,
default_language=Espa�ol , check_expiration=on

create user [Alvaro] for login [Administrador] with default_schema=dbo