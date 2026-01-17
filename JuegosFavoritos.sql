-- ============================================
-- PASO 1: CREAR Y SELECCIONAR LA BASE DE DATOS
-- ============================================

-- CREATE DATABASE crea una nueva base de datos en el servidor SQL
-- Piensa en esto como crear una carpeta principal para guardar todo
CREATE DATABASE JuegosFavoritos;

-- USE le dice a SQL Server que queremos trabajar dentro de esta base de datos
-- Es como abrir la carpeta que acabamos de crear
USE JuegosFavoritos;

-- ============================================
-- PASO 2: TABLA PRINCIPAL - JUEGOS
-- ============================================

-- Esta es tu tabla original mejorada
-- Aquí guardamos la información básica de cada juego
CREATE TABLE Juegos
(
    -- IdJuego: Identificador único para cada juego
    -- INT: Tipo de dato numérico entero
    -- PRIMARY KEY: Esta columna identifica de manera única cada registro (no puede repetirse)
    -- IDENTITY(1,1): Auto-incrementa automáticamente (empieza en 1, suma de 1 en 1)
    IdJuego INT PRIMARY KEY IDENTITY(1,1),
    
    -- NombreDelJuego: El nombre del videojuego
    -- NVARCHAR(100): Texto de hasta 100 caracteres (la N permite caracteres especiales como ñ, á, etc.)
    -- NOT NULL: Este campo es obligatorio, no puede estar vacío
    NombreDelJuego NVARCHAR(100) NOT NULL,
    
    -- Creador: Quién creó o desarrolló el juego
    Creador NVARCHAR(100) NOT NULL,
    
    -- AnioLanzamiento: Año en que salió el juego
    -- INT en lugar de DATETIME porque solo necesitamos el año (ej: 2015)
    AnioLanzamiento INT NOT NULL,
    
    -- Distribuidora: La empresa que publicó/distribuyó el juego
    Distribuidora NVARCHAR(100) NOT NULL,
    
    -- FechaRegistro: Cuándo agregaste este juego a tu base de datos
    -- DATETIME: Guarda fecha y hora completa
    -- DEFAULT GETDATE(): Si no especificas una fecha, usa la fecha/hora actual automáticamente
    FechaRegistro DATETIME DEFAULT GETDATE(),
    
    -- CONSTRAINT: Una regla que debe cumplirse
    -- CHECK: Valida que el año esté entre 1950 y el año actual
    -- Esto evita que alguien ponga años inválidos como 1800 o 3000
    CONSTRAINT CK_AnioValido CHECK (AnioLanzamiento >= 1950 AND AnioLanzamiento <= YEAR(GETDATE()))
);

-- ============================================
-- PASO 3: TABLA DE GÉNEROS
-- ============================================

-- Esta tabla guarda los diferentes géneros de videojuegos
-- Ejemplos: Acción, RPG, Aventura, Deportes, etc.
CREATE TABLE Generos
(
    -- Identificador único para cada género
    IdGenero INT PRIMARY KEY IDENTITY(1,1),
    
    -- Nombre del género
    -- UNIQUE: No puede haber dos géneros con el mismo nombre
    NombreGenero NVARCHAR(50) NOT NULL UNIQUE,
    
    -- Descripción opcional del género
    -- Al no tener NOT NULL, este campo puede quedar vacío
    Descripcion NVARCHAR(200)
);

-- ============================================
-- PASO 4: TABLA INTERMEDIA - JUEGOS Y GÉNEROS
-- ============================================

-- Esta tabla conecta Juegos con Géneros (relación muchos a muchos)
-- ¿Por qué? Porque un juego puede tener varios géneros (ej: Acción + Aventura)
-- Y un género puede tener muchos juegos
CREATE TABLE JuegosGeneros
(
    -- ID único de esta relación
    IdJuegoGenero INT PRIMARY KEY IDENTITY(1,1),
    
    -- IdJuego: Hace referencia a un juego específico de la tabla Juegos
    IdJuego INT NOT NULL,
    
    -- IdGenero: Hace referencia a un género específico de la tabla Generos
    IdGenero INT NOT NULL,
    
    -- FOREIGN KEY (Llave foránea): Crea una dependencia con otra tabla
    -- Esto significa: "IdJuego debe existir en la tabla Juegos"
    -- ON DELETE CASCADE: Si eliminas un juego, también elimina sus relaciones aquí
    CONSTRAINT FK_JuegosGeneros_Juegos FOREIGN KEY (IdJuego) 
        REFERENCES Juegos(IdJuego) ON DELETE CASCADE,
    
    -- Similar al anterior pero para géneros
    CONSTRAINT FK_JuegosGeneros_Generos FOREIGN KEY (IdGenero) 
        REFERENCES Generos(IdGenero) ON DELETE CASCADE,
    
    -- UNIQUE: Evita que agregues el mismo juego con el mismo género dos veces
    -- Por ejemplo, no puedes poner "Zelda - Aventura" dos veces
    CONSTRAINT UQ_JuegoGenero UNIQUE(IdJuego, IdGenero)
);

-- ============================================
-- PASO 5: TABLA DE PLATAFORMAS
-- ============================================

-- Aquí guardamos las diferentes plataformas/consolas
-- Ejemplos: PlayStation 5, Xbox Series X, PC, Nintendo Switch, etc.
CREATE TABLE Plataformas
(
    -- Identificador único de cada plataforma
    IdPlataforma INT PRIMARY KEY IDENTITY(1,1),
    
    -- Nombre de la plataforma (no puede repetirse)
    NombrePlataforma NVARCHAR(50) NOT NULL UNIQUE,
    
    -- Quién fabricó la plataforma (opcional)
    -- Ejemplos: Sony, Microsoft, Nintendo
    Fabricante NVARCHAR(50)
);

-- ============================================
-- PASO 6: TABLA INTERMEDIA - JUEGOS Y PLATAFORMAS
-- ============================================

-- Conecta juegos con plataformas (muchos a muchos)
-- Un juego puede estar en varias plataformas (ej: GTA V en PS4, Xbox, PC)
-- Una plataforma tiene muchos juegos
CREATE TABLE JuegosPlataformas
(
    -- ID único de esta relación
    IdJuegoPlataforma INT PRIMARY KEY IDENTITY(1,1),
    
    -- Referencia al juego
    IdJuego INT NOT NULL,
    
    -- Referencia a la plataforma
    IdPlataforma INT NOT NULL,
    
    -- Fecha en que el juego salió para esa plataforma específica
    -- DATE: Solo guarda la fecha (día/mes/año), sin hora
    -- Un juego puede salir en diferentes fechas para diferentes plataformas
    FechaLanzamientoPlataforma DATE,
    
    -- Llave foránea hacia Juegos
    CONSTRAINT FK_JuegosPlataformas_Juegos FOREIGN KEY (IdJuego) 
        REFERENCES Juegos(IdJuego) ON DELETE CASCADE,
    
    -- Llave foránea hacia Plataformas
    CONSTRAINT FK_JuegosPlataformas_Plataformas FOREIGN KEY (IdPlataforma) 
        REFERENCES Plataformas(IdPlataforma) ON DELETE CASCADE,
    
    -- Evita duplicados: no puedes agregar el mismo juego en la misma plataforma dos veces
    CONSTRAINT UQ_JuegoPlataforma UNIQUE(IdJuego, IdPlataforma)
);

-- ============================================
-- PASO 7: TABLA DE RAZONES (TU IDEA ORIGINAL)
-- ============================================

-- Esta tabla guarda TUS opiniones y razones sobre por qué te gusta cada juego
-- Aquí es donde puedes escribir libremente sobre cada juego
CREATE TABLE Razones
(
    -- ID único de cada razón/opinión
    IdRazon INT PRIMARY KEY IDENTITY(1,1),
    
    -- IdJuego: A qué juego se refiere esta razón
    -- NOT NULL: Obligatorio, toda razón debe estar asociada a un juego
    IdJuego INT NOT NULL,
    
    -- Razon: Tu opinión, comentario o razón por la que te gusta el juego
    -- NVARCHAR(500): Hasta 500 caracteres para escribir tu opinión
    Razon NVARCHAR(500) NOT NULL,
    
    -- Calificacion: Tu puntuación del juego
    -- CHECK: Solo acepta números del 1 al 10
    Calificacion INT CHECK (Calificacion >= 1 AND Calificacion <= 10),
    
    -- FechaOpinion: Cuándo escribiste esta opinión
    -- Se llena automáticamente con la fecha actual
    FechaOpinion DATETIME DEFAULT GETDATE(),
    
    -- Llave foránea: Esta razón debe pertenecer a un juego que existe
    -- ON DELETE CASCADE: Si borras el juego, también borra todas sus razones
    CONSTRAINT FK_Razones_Juegos FOREIGN KEY (IdJuego) 
        REFERENCES Juegos(IdJuego) ON DELETE CASCADE
);