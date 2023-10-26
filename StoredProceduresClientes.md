
Stored para operações do cliente

--Criar cliente
USE ClienteAPI;  
GO  
CREATE PROCEDURE DBO.CREATENewCliente   
    @Nome nvarchar(100),   
    @Email nvarchar(255),
    @Logotiponame  nvarchar(max),
    @Logo varbinary(max)
AS 
BEGIN  

INSERT into Clientes VALUES(@Nome,@Email, @Logotiponame, @logo)
END  
GO 

--Atualizar - cliente
USE ClienteAPI;  
GO  
CREATE PROCEDURE DBO.UpdateCliente  
    @Id int,
    @Nome nvarchar(100),   
    @Email nvarchar(255),
    @Logotiponame  nvarchar(max),
    @Logo varbinary(max)
AS 
BEGIN  

UPDATE Clientes SET Nome = @Nome, Email = @Email, LogotipoName = @Logotiponame, Logo = @Logo
where Id = @Id
END  
GO  

--Deletar cliente

USE ClienteAPI;  
GO  
CREATE PROCEDURE DBO.DeleteCliente   
    @Id INT
AS 
BEGIN  

DELETE FROM Clientes where Id = @Id
END  
GO  
