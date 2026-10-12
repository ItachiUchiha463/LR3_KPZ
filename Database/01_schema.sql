/* Скрипт 1 з 4. Створення бази PCClub і таблиць.
   Увага: якщо база вже існує, вона видаляється разом з усіма даними. */

USE master;
GO

IF DB_ID(N'PCClub') IS NOT NULL
BEGIN
    ALTER DATABASE PCClub SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PCClub;
END;
GO

CREATE DATABASE PCClub;
GO

USE PCClub;
GO
SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE Role (
    role_id INT IDENTITY PRIMARY KEY,
    name    NVARCHAR(30) NOT NULL
);

CREATE TABLE UserAccount (
    user_id       INT IDENTITY PRIMARY KEY,
    role_id       INT          NOT NULL,
    login         NVARCHAR(30) NOT NULL UNIQUE,
    password_hash VARCHAR(64)  NOT NULL,
    CONSTRAINT FK_UserAccount_Role FOREIGN KEY (role_id) REFERENCES Role (role_id)
        ON UPDATE CASCADE ON DELETE NO ACTION
);

CREATE TABLE Employee (
    employee_id INT IDENTITY PRIMARY KEY,
    user_id     INT          NULL,
    last_name   NVARCHAR(50) NOT NULL,
    first_name  NVARCHAR(50) NOT NULL,
    phone       NVARCHAR(20) NULL,
    shift       NVARCHAR(20) NULL,
    CONSTRAINT FK_Employee_User FOREIGN KEY (user_id) REFERENCES UserAccount (user_id)
        ON UPDATE CASCADE ON DELETE SET NULL
);
CREATE UNIQUE INDEX UX_Employee_User ON Employee (user_id) WHERE user_id IS NOT NULL;

CREATE TABLE Client (
    client_id     INT IDENTITY PRIMARY KEY,
    user_id       INT           NULL,
    last_name     NVARCHAR(50)  NOT NULL,
    first_name    NVARCHAR(50)  NOT NULL,
    phone         NVARCHAR(20)  NULL,
    birth_date    DATE          NULL,
    registered_at DATE          NOT NULL CONSTRAINT DF_Client_registered DEFAULT GETDATE(),
    balance       DECIMAL(8,2)  NOT NULL CONSTRAINT DF_Client_balance DEFAULT 0,
    CONSTRAINT CK_Client_balance CHECK (balance >= 0),
    CONSTRAINT FK_Client_User FOREIGN KEY (user_id) REFERENCES UserAccount (user_id)
        ON UPDATE NO ACTION ON DELETE SET NULL
);
CREATE UNIQUE INDEX UX_Client_User ON Client (user_id) WHERE user_id IS NOT NULL;

CREATE TABLE Hall (
    hall_id        INT IDENTITY PRIMARY KEY,
    name           NVARCHAR(50) NOT NULL,
    price_per_hour DECIMAL(8,2) NOT NULL
);

CREATE TABLE Computer (
    computer_id INT IDENTITY PRIMARY KEY,
    hall_id     INT          NOT NULL,
    number      INT          NOT NULL,
    gpu         NVARCHAR(50) NULL,
    monitor_hz  INT          NULL,
    status      NVARCHAR(20) NOT NULL CONSTRAINT DF_Computer_status DEFAULT N'Справний',
    CONSTRAINT CK_Computer_status CHECK (status IN (N'Справний', N'Несправний')),
    CONSTRAINT UQ_Computer_HallNumber UNIQUE (hall_id, number),
    CONSTRAINT FK_Computer_Hall FOREIGN KEY (hall_id) REFERENCES Hall (hall_id)
        ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Genre (
    genre_id INT IDENTITY PRIMARY KEY,
    name     NVARCHAR(50) NOT NULL
);

CREATE TABLE Game (
    game_id   INT IDENTITY PRIMARY KEY,
    genre_id  INT           NOT NULL,
    title     NVARCHAR(100) NOT NULL,
    age_limit INT           NOT NULL CONSTRAINT DF_Game_age DEFAULT 0,
    CONSTRAINT FK_Game_Genre FOREIGN KEY (genre_id) REFERENCES Genre (genre_id)
        ON UPDATE CASCADE ON DELETE NO ACTION
);

CREATE TABLE ComputerGame (
    computer_id INT NOT NULL,
    game_id     INT NOT NULL,
    PRIMARY KEY (computer_id, game_id),
    CONSTRAINT FK_CG_Computer FOREIGN KEY (computer_id) REFERENCES Computer (computer_id)
        ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_CG_Game FOREIGN KEY (game_id) REFERENCES Game (game_id)
        ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE Tariff (
    tariff_id        INT IDENTITY PRIMARY KEY,
    name             NVARCHAR(50) NOT NULL,
    hours            INT          NOT NULL,
    discount_percent INT          NOT NULL CONSTRAINT DF_Tariff_discount DEFAULT 0,
    CONSTRAINT CK_Tariff_discount CHECK (discount_percent BETWEEN 0 AND 100)
);

CREATE TABLE Session (
    session_id  INT IDENTITY PRIMARY KEY,
    client_id   INT          NOT NULL,
    computer_id INT          NOT NULL,
    employee_id INT          NOT NULL,
    tariff_id   INT          NOT NULL,
    game_id     INT          NULL,
    started_at  DATETIME     NOT NULL,
    ended_at    DATETIME     NULL,
    total_price DECIMAL(8,2) NULL,
    CONSTRAINT CK_Session_period CHECK (ended_at IS NULL OR ended_at > started_at),
    CONSTRAINT FK_Session_Client FOREIGN KEY (client_id) REFERENCES Client (client_id)
        ON UPDATE NO ACTION ON DELETE CASCADE,
    CONSTRAINT FK_Session_Computer FOREIGN KEY (computer_id) REFERENCES Computer (computer_id)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_Session_Employee FOREIGN KEY (employee_id) REFERENCES Employee (employee_id)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT FK_Session_Tariff FOREIGN KEY (tariff_id) REFERENCES Tariff (tariff_id)
        ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT FK_Session_Game FOREIGN KEY (game_id) REFERENCES Game (game_id)
        ON UPDATE NO ACTION ON DELETE SET NULL
);

CREATE TABLE Deposit (
    deposit_id  INT IDENTITY PRIMARY KEY,
    client_id   INT          NOT NULL,
    employee_id INT          NOT NULL,
    amount      DECIMAL(8,2) NOT NULL,
    paid_at     DATETIME     NOT NULL CONSTRAINT DF_Deposit_paid DEFAULT GETDATE(),
    method      NVARCHAR(20) NOT NULL,
    CONSTRAINT CK_Deposit_amount CHECK (amount > 0),
    CONSTRAINT CK_Deposit_method CHECK (method IN (N'Готівка', N'Картка')),
    CONSTRAINT FK_Deposit_Client FOREIGN KEY (client_id) REFERENCES Client (client_id)
        ON UPDATE NO ACTION ON DELETE CASCADE,
    CONSTRAINT FK_Deposit_Employee FOREIGN KEY (employee_id) REFERENCES Employee (employee_id)
        ON UPDATE NO ACTION ON DELETE NO ACTION
);
GO
