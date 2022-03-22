--create user joel identified by 1234;
--grant dba to joel;

CREATE TABLE Empleado(
	id_empleado INT PRIMARY KEY,
    nombres VARCHAR2(50),
    ape_paterno VARCHAR2(50),
    ape_materno VARCHAR2(50),
    genero CHAR(1),
    fecha_nacimiento DATE,
    fecha_registro DATE,
    correo VARCHAR2(60),
    sueldo DECIMAL(8,2)
);

INSERT INTO EMPLEADO VALUES(1 , 'Juan Alberto' , 'Caceres' , 'Sanchez' ,'M' , '12/12/2021' , SYSDATE,'juan-32@gmail.com' , 3500);
INSERT INTO EMPLEADO VALUES(2 , 'Xiomara' , 'Guzman' , 'Salvatierra' ,'F' , '11/02/2001' , SYSDATE,'xiomi-guzman@gmail.com' , 1950);
INSERT INTO EMPLEADO VALUES(3 , 'Rodrigo' , 'Paucar' , 'Guispe' ,'M' , '14/01/2000' , SYSDATE,'rodrigo-54@gmail.com' , 2875); 
commit;
-- LISTAR TODOS LOS EMPLEADOS

CREATE OR REPLACE PROCEDURE SP_ListarTodos
(
TABLA OUT SYS_REFCURSOR
)
AS
BEGIN
   OPEN TABLA FOR
   SELECT * FROM Empleado;
END;

/*
SET AUTOPRINT ON;
VAR X REFCURSOR;
EXECUTE SP_ListarTodos(:X);
*/

-- CREAR NUEVO EMPLEADO

CREATE OR REPLACE PROCEDURE SP_Agregar
(
nombres IN Empleado.nombres%Type,
ape_paterno IN Empleado.ape_paterno%Type,
ape_materno IN Empleado.ape_materno%Type,
genero IN Empleado.genero%Type,
fecha_nacimiento IN Empleado.fecha_nacimiento%Type,
correo IN Empleado.correo%Type,
sueldo IN Empleado.sueldo%Type
)
AS
IdEmpleado INT := 0;
BEGIN
   SELECT NVL(MAX(ID_Empleado),0) + 1 INTO IdEmpleado FROM Empleado;
   INSERT INTO Empleado VALUES(IdEmpleado,nombres,ape_paterno,ape_materno,genero,fecha_nacimiento,SYSDATE,correo,sueldo);
   COMMIT;
END;

--EXECUTE SP_Agregar('Luciana' , 'Fernandez' , 'Quispe' , 'F' ,  '16/07/2002' , 'luciana.fernandez@gmail.com' , 2300);

-- ACTUALIZAR EMPLEADO

CREATE OR REPLACE PROCEDURE SP_Actualizar
(
pNombres IN Empleado.nombres%Type,
pApe_paterno IN Empleado.ape_paterno%Type,
pApe_materno IN Empleado.ape_materno%Type,
pGenero IN Empleado.genero%Type,
pFecha_nacimiento IN Empleado.fecha_nacimiento%Type,
pCorreo IN Empleado.correo%Type,
pSueldo IN Empleado.sueldo%Type,
pId_empleado IN Empleado.id_empleado%Type
)
AS
BEGIN
   UPDATE Empleado SET Nombres = pNombres , Ape_Paterno = pApe_paterno , Ape_Materno = pApe_materno , 
   Genero = pGenero , Fecha_Nacimiento = pFecha_nacimiento , Correo = pCorreo , Sueldo = pSueldo
   Where Id_Empleado = pId_empleado;
   COMMIT;
END;

-- BUSCAR POR ID

CREATE OR REPLACE PROCEDURE SP_BuscarPorId
(
TABLA OUT SYS_REFCURSOR,
pIdEmp IN Empleado.id_empleado%Type
)
AS
BEGIN
   OPEN TABLA FOR
   SELECT * FROM Empleado
   Where Id_Empleado = pIdEmp;
END;

/*
SET AUTOPRINT ON;
VAR X REFCURSOR;
EXECUTE SP_BuscarPorId(:X, 1);
*/

-- ELIMINAR POR ID
CREATE OR REPLACE PROCEDURE SP_Eliminar
(
pId_empleado IN Empleado.id_empleado%Type
)
AS
BEGIN
   DELETE FROM Empleado 
   Where Id_Empleado = pId_empleado;
   COMMIT;
END;


COMMIT;


