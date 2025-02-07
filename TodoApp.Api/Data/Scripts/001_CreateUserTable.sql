CREATE TABLE Users
(
    Id             TEXT PRIMARY KEY,
    FirstName      TEXT NOT NULL,
    LastName       TEXT NOT NULL,
    Email          TEXT NOT NULL UNIQUE,
    Password       TEXT NOT NULL,
    CreatedAt      TEXT NOT NULL,
    UpdatedAt      TEXT NOT NULL,
    LastLoggedInAt TEXT
);
