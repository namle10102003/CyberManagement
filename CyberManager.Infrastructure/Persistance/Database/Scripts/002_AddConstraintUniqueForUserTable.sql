
CREATE TABLE IF NOT EXISTS "Users_news" (
	"Id" INTEGER NOT NULL UNIQUE,
	"UserName" VARCHAR NOT NULL UNIQUE,
	"Password" VARCHAR NOT NULL,
	"Credit" INTEGER NOT NULL,
	PRIMARY KEY("Id")
);

INSERT INTO "Users_news" (Id, UserName, Password, Credit)
SELECT Id, UserName, Password, Credit FROM "Users";

DROP TABLE "Users";

ALTER TABLE "Users_news" RENAME TO "Users";