IF OBJECT_ID (N'[DESCONOCIDOS4].TR_ACTUALIZAR_INTENTOS_FALLIDOS', N'TR') IS NOT NULL
		DROP TRIGGER  [DESCONOCIDOS4].TR_ACTUALIZAR_INTENTOS_FALLIDOS;
GO

CREATE TRIGGER  [DESCONOCIDOS4].TR_ACTUALIZAR_INTENTOS_FALLIDOS ON [DESCONOCIDOS4].USUARIO
AFTER UPDATE
AS
BEGIN
TRANSACTION
	DECLARE @Usu_Id INT
	SELECT @Usu_Id = (SELECT I.Usu_Id FROM INSERTED I)
	IF ([DESCONOCIDOS4].FN_OBTENER_CANTIDAD_INTENTOS_FALLIDOS_DE_INGRESO(@Usu_Id)) = 3
	BEGIN
		UPDATE [DESCONOCIDOS4].USUARIO SET Usu_cantIntentosLoginFallidos = 0, Usu_Habilitado = 0 WHERE Usu_Id=@Usu_Id
	END
COMMIT
GO

IF OBJECT_ID (N'[DESCONOCIDOS4].PRC_OBTENER_DATOS_USUARIOS', N'P') IS NOT NULL
		DROP PROCEDURE  [DESCONOCIDOS4].PRC_OBTENER_DATOS_USUARIOS;
GO
CREATE PROC [DESCONOCIDOS4].PRC_OBTENER_DATOS_USUARIOS
(
	@TipoUsuario VARCHAR(10)
)
AS
BEGIN
IF (@TipoUsuario = 'Cliente')
	BEGIN
		SELECT USUARIO.Usu_Nombre_Usuario, CLIENTE.Cliente_Id, PERSONA.* FROM DESCONOCIDOS4.CLIENTE LEFT JOIN DESCONOCIDOS4.PERSONA ON Cliente_Per_ID=Persona_Id LEFT JOIN DESCONOCIDOS4.USUARIO ON Usu_Per_Id=Persona_Id
	END
ELSE
	BEGIN
		SELECT USUARIO.Usu_Nombre_Usuario, CHOFER.Chofer_Id, PERSONA.* FROM DESCONOCIDOS4.CHOFER LEFT JOIN DESCONOCIDOS4.PERSONA ON Chofer_Per_ID=Persona_Id LEFT JOIN DESCONOCIDOS4.USUARIO ON Usu_Per_Id=Persona_Id
	END
END

IF OBJECT_ID (N'[DESCONOCIDOS4].PRC_OBTENER_ID_CLIENTE_O_CHOFER', N'P') IS NOT NULL
		DROP PROCEDURE  [DESCONOCIDOS4].PRC_OBTENER_ID_CLIENTE_O_CHOFER;
GO
CREATE PROC [DESCONOCIDOS4].PRC_OBTENER_ID_CLIENTE_O_CHOFER
(
	@IdUsuario INT,
	@IdRol INT
)
AS
BEGIN
DECLARE @TipoUsuario VARCHAR(50)
SET @TipoUsuario = (SELECT ROL_NOMBRE FROM DESCONOCIDOS4.ROL WHERE Rol_Id=@IdRol)
IF (@TipoUsuario = 'CLIENTE')
	BEGIN
		SELECT Cliente_Id [id] FROM DESCONOCIDOS4.Usuario U join [DESCONOCIDOS4].USUARIO_ROL on U.Usu_Id=UsuRol_Usu_Id
			join DESCONOCIDOS4.ROL on UsuRol_Rol_Id = Rol_Id join DESCONOCIDOS4.Cliente C on c.cliente_Per_Id=U.Usu_Per_Id
			WHERE Rol_Habilitado=1 and UsuRol_Usu_Id=@IdUsuario and Rol_Id=@IdRol and c.cliente_Habilitado=1
	END
ELSE
	BEGIN
		IF (@TipoUsuario = 'CHOFER')
		BEGIN
			SELECT Chofer_Id [id] FROM DESCONOCIDOS4.Usuario U join [DESCONOCIDOS4].USUARIO_ROL on U.Usu_Id=UsuRol_Usu_Id 
				join DESCONOCIDOS4.ROL on UsuRol_Rol_Id = Rol_Id join DESCONOCIDOS4.CHOFER C on c.Chofer_Per_Id=U.Usu_Per_Id
				WHERE Rol_Habilitado=1 and UsuRol_Usu_Id =@IdUsuario and Rol_Id=@IdRol and c.Chofer_Habilitado=1
		END
		ELSE
			SELECT -1 [id]
	END
END
select * from  DESCONOCIDOS4.PERSONA where Persona_Nombre like '%sha%'
	go
	select * from  DESCONOCIDOS4.usuario where Usu_Per_Id=44
	go
	select * from  DESCONOCIDOS4.cliente where Cliente_Per_ID=44
	go
	select * from  DESCONOCIDOS4.cliente where Cliente_Per_ID=90
	go
	SELECT Cliente_Id [id] FROM DESCONOCIDOS4.Usuario U join [DESCONOCIDOS4].USUARIO_ROL on U.Usu_Id=UsuRol_Usu_Id
			join DESCONOCIDOS4.ROL on UsuRol_Rol_Id = Rol_Id join DESCONOCIDOS4.Cliente C on c.cliente_Per_Id=U.Usu_Per_Id
			WHERE Rol_Habilitado=1 and UsuRol_Usu_Id=90 and Rol_Id=3 and c.cliente_Habilitado=1
			go
exec [DESCONOCIDOS4].PRC_OBTENER_ID_CLIENTE_O_CHOFER 90,3

exec [DESCONOCIDOS4].PRC_OBTENER_DATOS_USUARIOS 'Cliente', 'Sumaj', '',null
SELECT ROL_NOMBRE FROM DESCONOCIDOS4.ROL WHERE Rol_Id=1
SELECT Chofer_Id [id] FROM DESCONOCIDOS4.Usuario U join [DESCONOCIDOS4].USUARIO_ROL on U.Usu_Id=UsuRol_Usu_Id 
			join DESCONOCIDOS4.ROL on UsuRol_Rol_Id = Rol_Id join DESCONOCIDOS4.CHOFER C on c.Chofer_Per_Id=U.Usu_Per_Id
			WHERE Rol_Habilitado=1 and UsuRol_Usu_Id =89 and Rol_Id=2 and c.Chofer_Habilitado=1

SELECT Chofer_Id [id] FROM DESCONOCIDOS4.Usuario U join [DESCONOCIDOS4].USUARIO_ROL on U.Usu_Id=UsuRol_Usu_Id join DESCONOCIDOS4.ROL on UsuRol_Rol_Id = Rol_Id join DESCONOCIDOS4.CHOFER C on c.Chofer_Per_Id=U.Usu_Per_Id
	WHERE Rol_Habilitado=1 and UsuRol_Usu_Id=48 and Rol_Id=2 and c.Chofer_Habilitado=1

SELECT Cliente_Id FROM DESCONOCIDOS4.Usuario U join [DESCONOCIDOS4].USUARIO_ROL on U.Usu_Id=UsuRol_Usu_Id join DESCONOCIDOS4.ROL on UsuRol_Rol_Id = Rol_Id join DESCONOCIDOS4.Cliente C on c.cliente_Per_Id=U.Usu_Per_Id
	WHERE Rol_Habilitado=1 and UsuRol_Usu_Id=46 and Rol_Id=3 and c.cliente_Habilitado=1
	WHERE Rol_Habilitado=1 @Habilitado and UsuRol_Usu_Id=40@Usu_Id

	select * from DESCONOCIDOS4.CHOFER where Chofer_Per_Id=32 or Chofer_Per_Id=16
	select * from DESCONOCIDOS4.PERSONA where Persona_Id=48
	go
	select * from DESCONOCIDOS4.CHOFER where Chofer_Per_Id=48
	go = 
	select * from DESCONOCIDOS4.USUARIO where Usu_Per_Id=48
	go
	select * from DESCONOCIDOS4.Usuario where Usu_Id=1
	select * from DESCONOCIDOS4.USUARIO_ROL order by UsuRol_Usu_Id where UsuRol_Usu_Id=48
	select * from  DESCONOCIDOS4.PERSONA where Persona_Nombre like '%AAAAA%' on Usu_Id=UsuRol_Usu_Id join DESCONOCIDOS4.cliente on cliente_Per_Id=UsuRol_Usu_Id where UsuRol_Rol_Id=3
	go
	select * from DESCONOCIDOS4.CHOFER where Chofer_Per_Id=47
	insert into DESCONOCIDOS4.USUARIO_ROL (UsuRol_Rol_Id,UsuRol_Usu_Id) values('2','49')
	select * from DESCONOCIDOS4.rol

	select * from  DESCONOCIDOS4.PERSONA where Persona_Nombre like '%AAAAA%'
	go
	select * from  DESCONOCIDOS4.cliente where Cliente_Per_ID=90