CREATE TABLE IF NOT EXISTS "bills" (
	"id" INTEGER NOT NULL UNIQUE,
	"title" VARCHAR NOT NULL,
	"type" VARCHAR NOT NULL CHECK(type IN ('Deposit', 'Withdraw')),
	"description" TEXT NOT NULL,
	"cash" INTEGER NOT NULL,
	"dateTime" DATETIME NOT NULL,
	PRIMARY KEY("id")
);

CREATE TABLE IF NOT EXISTS "computers" (
	"id" INTEGER NOT NULL UNIQUE,
	"name" VARCHAR NOT NULL,
	"costPerHour" INTEGER NOT NULL,
	"status" VARCHAR NOT NULL CHECK(status IN ('Online', 'Offline', 'Error')),
	PRIMARY KEY("id")
);

CREATE TABLE IF NOT EXISTS "computerErrors" (
	"id" INTEGER NOT NULL UNIQUE,
	"computerId" INTEGER NOT NULL,
	"device" VARCHAR NOT NULL CHECK(device IN ('Monitor', 'Keyboard', 'Mouse', 'CPU')),
	"description" TEXT NOT NULL,
	"isSolve" BOOLEAN NOT NULL DEFAULT false,
	PRIMARY KEY("id"),
	FOREIGN KEY ("computerId") REFERENCES "computers"("id")
	ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE IF NOT EXISTS "softwares" (
	"id" INTEGER NOT NULL UNIQUE,
	"name" VARCHAR NOT NULL,
	"path" TEXT NOT NULL,
	PRIMARY KEY("id")
);

CREATE TABLE IF NOT EXISTS "users" (
	"id" INTEGER NOT NULL UNIQUE,
	"userName" VARCHAR NOT NULL,
	"password" VARCHAR NOT NULL,
	"credit" INTEGER NOT NULL,
	PRIMARY KEY("id")
);
