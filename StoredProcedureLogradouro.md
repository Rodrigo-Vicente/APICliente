Stored Procedures relacionadas ao logradouro

---- Pegar todos os logradouros cadastro para um determinado cliente
USE ClienteAPI;  
GO  
CREATE PROCEDURE DBO.GetLogradouroByCliente   
    @ClienteId int
AS 
BEGIN  

select * from Logradouros WHERE ClienteId = @ClienteId
END  
GO  

-- Criar Logradouro

USE ClienteAPI;  
GO  
CREATE PROCEDURE DBO.CreateLogradouro   
    @Endereco nvarchar(max),
    @Bairro  nvarchar(max), 
    @Numero nvarchar(max),
    @Cidade  nvarchar(max),
    @Estado nvarchar(max),
    @Pais nvarchar(max),
    @Cep nvarchar(max),
    @ClienteId int
AS 
BEGIN  

INSERT into Logradouros VALUES( @Endereco,@Bairro,@Numero, @Cidade, @Estado, @Pais,@Cep, @ClienteId)
END  
GO  

-- Atualizar logradouro

USE ClienteAPI;  
GO  
CREATE PROCEDURE DBO.UpdateLogradouro
    @Id int,
    @Endereco nvarchar(max),
    @Bairro  nvarchar(max),   
    @Numero nvarchar(max),
    @Cidade  nvarchar(max),
    @Estado nvarchar(max),
    @Pais nvarchar(max),
    @Cep nvarchar(max)
    
AS 
BEGIN  

update Logradouros SET Endereco =@Endereco, Bairro= @Bairro,Numero = @Numero, Cidade = @Cidade, Estado = @Estado, Pais=@Pais, Cep =@Cep
WHERE Id = @Id
END  
GO 

-- Deletar logradouro

USE ClienteAPI;  
GO  
CREATE PROCEDURE DBO.DeleteLogradouro   
    @Id Int
AS 
BEGIN  

DELETE from Logradouros where Id = @Id
END  
GO  
