CREATE TABLE IF NOT EXISTS "Bills" (
	"Id" INTEGER NOT NULL UNIQUE,
	"Title" VARCHAR NOT NULL,
	"Type" VARCHAR NOT NULL CHECK(type IN ('Deposit', 'Withdraw')),
	"Description" TEXT NOT NULL,
	"Cash" INTEGER NOT NULL,
	"DateTime" DATETIME NOT NULL,
	PRIMARY KEY("Id")
);

CREATE TABLE IF NOT EXISTS "Computers" (
	"Id" INTEGER NOT NULL UNIQUE,
	"Name" VARCHAR NOT NULL,
	"CostPerHour" INTEGER NOT NULL,
	"Status" VARCHAR NOT NULL CHECK(status IN ('Online', 'Offline', 'Error')),
	PRIMARY KEY("Id")
);

CREATE TABLE IF NOT EXISTS "ComputerErrors" (
	"Id" INTEGER NOT NULL UNIQUE,
	"ComputerId" INTEGER NOT NULL,
	"Device" VARCHAR NOT NULL CHECK(device IN ('Monitor', 'Keyboard', 'Mouse', 'CPU')),
	"Description" TEXT NOT NULL,
	"IsSolve" BOOLEAN NOT NULL DEFAULT false,
	PRIMARY KEY("Id"),
	FOREIGN KEY ("ComputerId") REFERENCES "Computers"("Id")
	ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS "Softwares" (
	"Id" INTEGER NOT NULL UNIQUE,
	"Name" VARCHAR NOT NULL,
	"Path" TEXT NOT NULL,
	PRIMARY KEY("Id")
);

CREATE TABLE IF NOT EXISTS "Users" (
	"Id" INTEGER NOT NULL UNIQUE,
	"UserName" VARCHAR NOT NULL,
	"Password" VARCHAR NOT NULL,
	"Credit" INTEGER NOT NULL,
	PRIMARY KEY("Id")
);
